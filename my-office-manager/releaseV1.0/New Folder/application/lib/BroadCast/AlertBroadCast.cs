using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using System.Data;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using DevExpress.XtraEditors;
using System.Drawing;

namespace office
{
    public class AlertBroadCast
    {
        AlertControl controlBroadCast;       
        Form formMain;
        int delay = 3600000;
        Timer timer;
        public LabelControl lblthongbao;
        AlertButton btnDelete;
        ToolTipController toolTipStyleController;
        #region Khởi tạo
        public AlertBroadCast(Form frmMain, int TimeDelay)
        {
            if (CheckShowThongBao())
            {
                init(frmMain, TimeDelay);
                timer.Start();
            }
        }
        private void init(Form formMain, int MinuteForDelaying)
        {
            //init toolTipStyleController
            toolTipStyleController = new ToolTipController();
            toolTipStyleController.Active = true;
            toolTipStyleController.AllowHtmlText = true;
            toolTipStyleController.Rounded = true;
            toolTipStyleController.ShowBeak = true;
            toolTipStyleController.ToolTipType = ToolTipType.SuperTip;

            //controlBroadCast        
            controlBroadCast = new AlertControl();
            controlBroadCast.ButtonClick += new AlertButtonClickEventHandler(controlBroadCast_ButtonClick);
            btnDelete = new AlertButton(HelpImage.getImage2020("stop.png"));
            btnDelete.Hint = "Không xem lại thông báo lần sau";
            btnDelete.Name = "btnDelete";
            controlBroadCast.Buttons.Add(btnDelete);
            this.formMain = formMain;
            this.delay = MinuteForDelaying * 60000;
            this.timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
        }
        #endregion

        #region Xử lý các sự kiện          

        void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            ShowAlert();
            if (timer.Interval < delay) timer.Interval = delay;
        }
        void controlBroadCast_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "btnDelete") // click vao nut nay thi thong bao hien thoi khong hien vao lan sau
            {
                long id = HelpNumber.ParseInt64(((DataRow)e.AlertForm.Tag)["ID"]);
                CloseThongBao(id);
                e.AlertForm.Close();
            }
        } 
       // xử lý khi click chuột lên control thì hiện thông báo
        void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType().FullName == "DevExpress.XtraBars.Alerter.AlertForm")
            {
                //AlertForm alert = (AlertForm)sender;
                //ToolTipControllerShowEventArgs args = toolTipStyleController.CreateShowArgs();
                
                //args.SuperTip = SetStyleTooltip((DataRow)alert.Tag);
                //toolTipStyleController.ShowHint(args, alert.PointToScreen(new Point(e.X, e.Y)));
                toolTipStyleController.HideHint();
            }
            else 
                if (sender.GetType().FullName == "DevExpress.XtraEditors.LabelControl")
            {
                LabelControl lbl = (LabelControl)sender;
                ToolTipControllerShowEventArgs args = toolTipStyleController.CreateShowArgs();
                args.SuperTip = SetStyleTooltip((DataRow)lbl.Tag);
                toolTipStyleController.ShowHint(args, lbl.PointToScreen(new Point(e.X, e.Y)));
            }
        }
        #endregion

        #region Các hàm bổ trợ
        private bool CheckShowThongBao()
        {
            return pl.office.AppGetSysParam.GetCHO_PHEP_THONG_BAO;
        }
        public void ShowAlert()
        {
            try
            {
                DataTable dtTB=GetThongBao();
                foreach (DataRow rowtb in dtTB.Rows)
                {
                    AlertForm alert = new AlertForm(controlBroadCast);
                    alert.Name = "lert " + rowtb["ID"].ToString();
                    alert.Text = rowtb["CHU_DE"].ToString();
                    alert.MouseDown += new MouseEventHandler(control_MouseDown);
                    lblthongbao = new LabelControl();
                    lblthongbao.Location = new System.Drawing.Point(10, 23);
                    lblthongbao.AutoSizeMode = LabelAutoSizeMode.None;
                    lblthongbao.Size = new System.Drawing.Size(230, 52);
                    lblthongbao.ImageAlignToText = ImageAlignToText.LeftCenter;
                    lblthongbao.AllowHtmlString = true;
                    lblthongbao.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
                    lblthongbao.Appearance.Image = HelpImage.getImage4848("broadcast.png");
                    lblthongbao.ForeColor = Color.Blue;
                    lblthongbao.Cursor = Cursors.Hand;
                    lblthongbao.Text = rowtb["CHU_DE"].ToString();
                    lblthongbao.MouseDown += new MouseEventHandler(control_MouseDown);
                    lblthongbao.Tag = rowtb;
                    alert.Controls.Add(lblthongbao);
                    alert.Tag = rowtb;
                    alert.ShowForm(formMain);
                }
            }
            catch { }         
        } 
        // load len cac thong bao cua nguoi dang nhap
        private DataTable GetThongBao()
        {
            return HelpDB.getDBService().LoadDataSet("select * from ALERT_BROADCAST("+
                FrameworkParams.currentUser.employee_id+")", "THONG_BAO").Tables[0];
        }
        // dong thong bao khong hien lai lan sau
        private bool CloseThongBao(long ID)
        {
            try
            {
                FWDBService dbb = HelpDB.getDBService();
                DbCommand cmdd = dbb.GetSQLStringCommand(string.Format("select nguoi_nhan from fw_broadcast where id={0}", ID));
                object obj = dbb.ExecuteScalar(cmdd);
                if (obj != null && !(obj is DBNull) && obj.ToString() != "")
                {
                    string currentNguoiNhan = obj.ToString();
                    string[] arrayCurrentNguoiNhan = currentNguoiNhan.Split(',');
                    string newNguoiNhan = "";
                    foreach (string s in arrayCurrentNguoiNhan)
                    {
                        if (s != FrameworkParams.currentUser.employee_id.ToString())
                            newNguoiNhan += s + ",";
                    }
                    if (newNguoiNhan == "") newNguoiNhan = "-1";
                    newNguoiNhan = newNguoiNhan.TrimEnd(',');
                    string str = "update fw_broadcast set nguoi_nhan=@nguoinhan where id=@id";
                    FWDBService db = HelpDB.getDBService();
                    DbCommand cmd = db.GetSQLStringCommand(str);
                    db.AddInParameter(cmd, "@NGUOINHAN", DbType.String, newNguoiNhan);
                    db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                    if (db.ExecuteNonQuery(cmd) > 0) return true;
                    else return false;
                }
                return true;

            }
            catch { return false; }
        }
        SuperToolTip SetStyleTooltip(DataRow rowtb)
        {
            SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            ToolTipItem toolTipItemContent = new DevExpress.Utils.ToolTipItem();
            ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            ToolTipTitleItem toolTipTitleItemFooter = new DevExpress.Utils.ToolTipTitleItem();
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.Text = "<color=DarkSlateGray>" + rowtb["CHU_DE"].ToString();
            toolTipTitleItem1.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            toolTipTitleItem1.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            toolTipItemContent.LeftIndent = 6;
            toolTipItemContent.Image = HelpImage.getImage4848("broadcast.png");
            toolTipItemContent.Text = "<color=Black>" + HelpByte.BytesToUTF8String((byte[])rowtb["NOI_DUNG"]);
            toolTipItemContent.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            toolTipItemContent.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            toolTipTitleItemFooter.LeftIndent = 6;
            toolTipTitleItemFooter.Text = "<color=DarkGray><i>Do: " + rowtb["TEN_NGUOI_NHAP"].ToString() + "  gửi lúc: " +
               rowtb["NGAY_NHAP"].ToString();
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItemContent);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItemFooter);
            superToolTip1.FixedTooltipWidth = false;
            return superToolTip1;
        }
        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Stop();
                foreach (AlertForm form in controlBroadCast.AlertFormList)
                    form.Close();
            }
        }
        #endregion

    }
}
