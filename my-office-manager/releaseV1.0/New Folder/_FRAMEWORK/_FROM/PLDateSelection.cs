namespace ProtocolVN.Framework.Win.Office
{
    using DevExpress.Data;
    using DevExpress.Utils;
    using DevExpress.Utils.Controls;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using ProtocolVN.Framework.Win.Trial;

    public class PLDateSelection : XtraUserControl, IXtraResizableControl
    {
        private SelectionTypes _Default;
        private TimeType _ReturnType;
        private SelectionTypes _Types;
        private IContainer components;
        private BasicControl DateTimeControl;
        private LookUpEdit LookUpEditFrom;
        private bool allowNull=true;
        private int orginWith;
        
        public event EventHandler Changed;

        public PLDateSelection()
        {
            this._Types = SelectionTypes.All;
            this._ReturnType = TimeType.Date;
            this.InitializeComponent();
            this.SetLookup();
        }

        public PLDateSelection(SelectionTypes SelectionTypes, SelectionTypes Default, TimeType ReturnType)
        {
            this._Types = SelectionTypes.All;
            this._ReturnType = TimeType.Date;
            this.InitializeComponent();
            this._Types = SelectionTypes;
            this._Default = Default;
            this._ReturnType = ReturnType;
            this.SetLookup();
        }

        object bkWith = null;
        private void ChangeSelection(SelectionTypes Selection)
        {
            BasicControl control;
            DateTime dateTo = DateTime.Now;
            //DateTime dateFrom = this.DateTimeControl.DateFrom;
            if (this.bkWith != null)
            {
                this.LookUpEditFrom.Width = (Int32)bkWith;
            }
            switch (Selection)
            {
                case SelectionTypes.None:
                    if (bkWith == null)
                        bkWith = this.LookUpEditFrom.Width;
                    this.LookUpEditFrom.Width = this.orginWith;
                    control = new BasicControl();
                    control.Visible = false;
                    break;
                case SelectionTypes.OneDate:
                    control = new DayControl(dateTo);
                    break;

                case SelectionTypes.OneMonth:
                    control = new PLMonthControl(dateTo);
                    break;

                case SelectionTypes.OneQuarter:
                    control = new PLQuarterControl(dateTo);
                    break;

                case SelectionTypes.OneYear:
                    control = new PLYearControl(dateTo);
                    break;

                case SelectionTypes.SixMonths:
                    control = new PLSixMonths(dateTo);
                    break;

                case SelectionTypes.FromQuarterToQuarter:
                    control = new PLFromToQuarter(dateTo.AddMonths(-9), dateTo);
                    break;

                case SelectionTypes.FromYearToYear:
                    control = new PLFromToYearDateTime(new DateTime(dateTo.Year - 1, 1, 1), new DateTime(dateTo.Year, 1, 1));
                    break;

                case SelectionTypes.FromDateToDate:
                    control = new PLFromToDay(dateTo.AddDays(-7), dateTo);
                    break;

                case SelectionTypes.FromMonthToMonth:
                    control = new PLFromToMonth(dateTo.AddMonths(-2), dateTo);
                    break;

                default:
                    control = new DayControl(dateTo);
                    break;
            }
            this.ShowControl(control);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<KeyValuePair<SelectionTypes, string>> GetList(short LanguageId)
        {
            List<KeyValuePair<SelectionTypes, string>> list = new List<KeyValuePair<SelectionTypes, string>>();
            if (allowNull)
            {
                if ((this._Types & SelectionTypes.None) == SelectionTypes.None)
                {
                    list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.None, ""));
                }
            }
            switch (LanguageId)
            {
                case 0:                   
                    if ((this._Types & SelectionTypes.OneDate) == SelectionTypes.OneDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneDate, "Ngày"));
                    }
                    if ((this._Types & SelectionTypes.OneMonth) == SelectionTypes.OneMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneMonth, "Tháng"));
                    }
                    if ((this._Types & SelectionTypes.OneQuarter) == SelectionTypes.OneQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneQuarter, "Quý"));
                    }
                    if ((this._Types & SelectionTypes.SixMonths) == SelectionTypes.SixMonths)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.SixMonths, "Sáu tháng"));
                    }
                    if ((this._Types & SelectionTypes.OneYear) == SelectionTypes.OneYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneYear, "Năm"));
                    }
                    if ((this._Types & SelectionTypes.FromDateToDate) == SelectionTypes.FromDateToDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromDateToDate, "Từ ngày"));
                    }
                    if ((this._Types & SelectionTypes.FromMonthToMonth) == SelectionTypes.FromMonthToMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromMonthToMonth, "Từ tháng"));
                    }
                    if ((this._Types & SelectionTypes.FromQuarterToQuarter) == SelectionTypes.FromQuarterToQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromQuarterToQuarter, "Từ quý"));
                    }
                    if ((this._Types & SelectionTypes.FromYearToYear) == SelectionTypes.FromYearToYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromYearToYear, "Từ năm"));
                    }
                    return list;

                case 1:
                    if ((this._Types & SelectionTypes.OneDate) == SelectionTypes.OneDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneDate, "Date"));
                    }
                    if ((this._Types & SelectionTypes.OneMonth) == SelectionTypes.OneMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneMonth, "Month"));
                    }
                    if ((this._Types & SelectionTypes.OneQuarter) == SelectionTypes.OneQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneQuarter, "Quarter"));
                    }
                    if ((this._Types & SelectionTypes.SixMonths) == SelectionTypes.SixMonths)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.SixMonths, "Six months"));
                    }
                    if ((this._Types & SelectionTypes.OneYear) == SelectionTypes.OneYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneYear, "Year"));
                    }
                    if ((this._Types & SelectionTypes.FromDateToDate) == SelectionTypes.FromDateToDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromDateToDate, "From date"));
                    }
                    if ((this._Types & SelectionTypes.FromMonthToMonth) == SelectionTypes.FromMonthToMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromMonthToMonth, "From month"));
                    }
                    if ((this._Types & SelectionTypes.FromQuarterToQuarter) == SelectionTypes.FromQuarterToQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromQuarterToQuarter, "From quarter"));
                    }
                    if ((this._Types & SelectionTypes.FromYearToYear) == SelectionTypes.FromYearToYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromYearToYear, "From year"));
                    }
                    return list;

                case 2:
                    if ((this._Types & SelectionTypes.OneDate) == SelectionTypes.OneDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneDate, "Date"));
                    }
                    if ((this._Types & SelectionTypes.OneMonth) == SelectionTypes.OneMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneMonth, "Month"));
                    }
                    if ((this._Types & SelectionTypes.OneQuarter) == SelectionTypes.OneQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneQuarter, "Quarter"));
                    }
                    if ((this._Types & SelectionTypes.SixMonths) == SelectionTypes.SixMonths)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.SixMonths, "Six months"));
                    }
                    if ((this._Types & SelectionTypes.OneYear) == SelectionTypes.OneYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneYear, "Year"));
                    }
                    if ((this._Types & SelectionTypes.FromDateToDate) == SelectionTypes.FromDateToDate)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromDateToDate, "From date"));
                    }
                    if ((this._Types & SelectionTypes.FromMonthToMonth) == SelectionTypes.FromMonthToMonth)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromMonthToMonth, "From month"));
                    }
                    if ((this._Types & SelectionTypes.FromQuarterToQuarter) == SelectionTypes.FromQuarterToQuarter)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromQuarterToQuarter, "From quarter"));
                    }
                    if ((this._Types & SelectionTypes.FromYearToYear) == SelectionTypes.FromYearToYear)
                    {
                        list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromYearToYear, "From year"));
                    }
                    return list;
            }
            if ((this._Types & SelectionTypes.OneDate) == SelectionTypes.OneDate)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneDate, "Ngày"));
            }
            if ((this._Types & SelectionTypes.OneMonth) == SelectionTypes.OneMonth)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneMonth, "Tháng"));
            }
            if ((this._Types & SelectionTypes.OneQuarter) == SelectionTypes.OneQuarter)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneQuarter, "Quý"));
            }
            if ((this._Types & SelectionTypes.SixMonths) == SelectionTypes.SixMonths)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.SixMonths, "Sáu tháng"));
            }
            if ((this._Types & SelectionTypes.OneYear) == SelectionTypes.OneYear)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.OneYear, "Năm"));
            }
            if ((this._Types & SelectionTypes.FromDateToDate) == SelectionTypes.FromDateToDate)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromDateToDate, "Từ ngày"));
            }
            if ((this._Types & SelectionTypes.FromMonthToMonth) == SelectionTypes.FromMonthToMonth)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromMonthToMonth, "Từ tháng"));
            }
            if ((this._Types & SelectionTypes.FromQuarterToQuarter) == SelectionTypes.FromQuarterToQuarter)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromQuarterToQuarter, "Từ quý"));
            }
            if ((this._Types & SelectionTypes.FromYearToYear) == SelectionTypes.FromYearToYear)
            {
                list.Add(new KeyValuePair<SelectionTypes, string>(SelectionTypes.FromYearToYear, "Từ năm"));
            }
            return list;
        }

        private void InitializeComponent()
        {
            this.LookUpEditFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.DateTimeControl = new ProtocolVN.Framework.Win.Trial.BasicControl();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LookUpEditFrom
            // 
            this.LookUpEditFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.LookUpEditFrom.EnterMoveNextControl = true;
            this.LookUpEditFrom.Location = new System.Drawing.Point(0, 0);
            this.LookUpEditFrom.Name = "LookUpEditFrom";
            this.LookUpEditFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.LookUpEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value")});
            this.LookUpEditFrom.Properties.DisplayMember = "Value";
            this.LookUpEditFrom.Properties.DropDownRows = 9;
            this.LookUpEditFrom.Properties.NullText = "";
            this.LookUpEditFrom.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.LookUpEditFrom.Properties.ShowFooter = false;
            this.LookUpEditFrom.Properties.ShowHeader = false;
            this.LookUpEditFrom.Properties.ShowLines = false;
            this.LookUpEditFrom.Properties.ValueMember = "Key";
            this.LookUpEditFrom.Size = new System.Drawing.Size(72, 20);
            this.LookUpEditFrom.TabIndex = 0;
            this.LookUpEditFrom.EditValueChanged += new System.EventHandler(this.LookUpEditFrom_EditValueChanged);
            // 
            // DateTimeControl
            // 
            this.DateTimeControl.DateFrom = new System.DateTime(2011, 2, 24, 9, 35, 38, 592);
            this.DateTimeControl.DateTo = new System.DateTime(2011, 2, 24, 9, 35, 38, 592);
            this.DateTimeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimeControl.Location = new System.Drawing.Point(72, 0);
            this.DateTimeControl.Name = "DateTimeControl";
            this.DateTimeControl.Size = new System.Drawing.Size(257, 20);
            this.DateTimeControl.TabIndex = 1;
            // 
            // PLDateSelection
            // 
            this.Controls.Add(this.DateTimeControl);
            this.Controls.Add(this.LookUpEditFrom);
            this.Name = "PLDateSelection";
            this.Size = new System.Drawing.Size(329, 20);
            this.Load += new System.EventHandler(this.PLDateSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        void PLDateSelection_Load(object sender, EventArgs e)
        {
            orginWith = this.Width;
            AutoSize();
        }

        private void LookUpEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            this.ChangeSelection((SelectionTypes) this.LookUpEditFrom.EditValue);
        }

        private void SetLookup()
        {
            List<KeyValuePair<SelectionTypes, string>> list = this.GetList(0);
            this.LookUpEditFrom.Properties.DataSource = list;
            if (allowNull == false)
            {
                if (this._Default == SelectionTypes.None)
                {
                    KeyValuePair<SelectionTypes, string> pair = list[0];
                    this.LookUpEditFrom.EditValue = pair.Key;
                }
                else
                {
                    this.LookUpEditFrom.EditValue = this._Default;
                }
            }
            else
            {
                this.LookUpEditFrom.EditValue = this._Default;
                this.LookUpEditFrom.Width = this.orginWith;

            }
            int count = list.Count;
            if (count == 1)
            {
                this.LookUpEditFrom.Properties.ReadOnly = true;
                this.LookUpEditFrom.Properties.ShowDropDown = ShowDropDown.Never;
            }
            else
            {
                this.LookUpEditFrom.Properties.DropDownRows = count;
            }
        }
        private void AutoSize()
        {
            this.Width = this.LookUpEditFrom.Width + this.DateTimeControl.Width;
            if (this.Width < orginWith)
            {
                this.DateTimeControl.Width = this.orginWith - this.LookUpEditFrom.Width;
                this.Width = this.LookUpEditFrom.Width + this.DateTimeControl.Width;
            }
        }
        private void ShowControl(BasicControl BasicDateTimeControl)
        {
            base.Controls.Remove(this.DateTimeControl);
            this.DateTimeControl = BasicDateTimeControl;
            this.DateTimeControl.Location = new Point(72, 0);
            this.DateTimeControl.TabIndex = 2;
            base.Controls.Add(this.DateTimeControl);
            AutoSize();
            if (this.Changed != null)
            {
                this.Changed(this, new EventArgs());
            }
        }

        [Browsable(false)]
        public string Caption
        {
            get
            {
                return General.ToString(this.FromDate, this.ToDate);
            }
            set
            {
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public SelectionTypes Default
        {
            get
            {
                return this._Default;
            }
            set
            {
                if (this._Default != value)
                {
                    this._Default = value;
                    this.LookUpEditFrom.EditValue = this._Default;
                }
            }
        }

        [Browsable(false)]
        public object FirstFrom
        {
            get
            {
                switch (this._ReturnType)
                {
                    case TimeType.Date:
                        return this.FromDate;

                    case TimeType.Month:
                        return this.FromDate.Month;

                    case TimeType.Quarter:
                        return General.MonthToQuarter(this.FromDate.Month);

                    case TimeType.HalfYear:
                        return General.MonthToSixMonth(this.FromDate.Month);

                    case TimeType.Year:
                        return this.FromDate.Year;
                }
                return -1;
            }
            set
            {
            }
        }

        [Browsable(false)]
        public object FirstTo
        {
            get
            {
                switch (this._ReturnType)
                {
                    case TimeType.Date:
                        return this.ToDate;

                    case TimeType.Month:
                        return this.ToDate.Month;

                    case TimeType.Quarter:
                        return General.MonthToQuarter(this.ToDate.Month);

                    case TimeType.HalfYear:
                        return General.MonthToSixMonth(this.ToDate.Month);

                    case TimeType.Year:
                        return this.ToDate.Year;
                }
                return -1;
            }
            set
            {
            }
        }

        [Browsable(false)]
        public DateTime FromDate
        {
            get
            {
                return this.DateTimeControl.DateFrom;
            }
            set
            {
                this.DateTimeControl.DateFrom = value;
            }
        }

        public static Collection<KeyValuePair<TimeType, string>> GetReturnTypes
        {
            get
            {
                return new Collection<KeyValuePair<TimeType, string>> { new KeyValuePair<TimeType, string>(TimeType.Date, "Ngày"), new KeyValuePair<TimeType, string>(TimeType.HalfYear, "Nửa năm"), new KeyValuePair<TimeType, string>(TimeType.Month, "Tháng"), new KeyValuePair<TimeType, string>(TimeType.None, "Không"), new KeyValuePair<TimeType, string>(TimeType.Quarter, "Quý"), new KeyValuePair<TimeType, string>(TimeType.Year, "Năm") };
            }
        }

        public bool IsCaptionVisible
        {
            get
            {
                return true;
            }
        }

        public Size MaxSize
        {
            get
            {
                return new Size(0, 20);
            }
        }

        public Size MinSize
        {
            get
            {
                return new Size(0, 20);
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public TimeType ReturnType
        {
            get
            {
                return this._ReturnType;
            }
            set
            {
                this._ReturnType = value;
            }
        }

        [Browsable(false)]
        public object SecondFrom
        {
            get
            {
                switch (this._ReturnType)
                {
                    case TimeType.Date:
                        return this.FromDate;

                    case TimeType.Month:
                        return this.FromDate.Year;

                    case TimeType.Quarter:
                        return this.FromDate.Year;

                    case TimeType.HalfYear:
                        return this.FromDate.Year;

                    case TimeType.Year:
                        return this.FromDate.Year;
                }
                return -1;
            }
            set
            {
            }
        }

        [Browsable(false)]
        public object SecondTo
        {
            get
            {
                switch (this._ReturnType)
                {
                    case TimeType.Date:
                        return this.ToDate;

                    case TimeType.Month:
                        return this.ToDate.Year;

                    case TimeType.Quarter:
                        return this.ToDate.Year;

                    case TimeType.HalfYear:
                        return this.ToDate.Year;

                    case TimeType.Year:
                        return this.ToDate.Year;
                }
                return -1;
            }
            set
            {
            }
        }

        [Browsable(false)]
        public DateTime ToDate
        {
            get
            {
                return this.DateTimeControl.DateTo;
            }
            set
            {
                this.DateTimeControl.DateTo = value;
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public SelectionTypes Types
        {
            get
            {
                return this._Types;
            }
            set
            {
                if (this._Types != value)
                {
                    this._Types = value;
                    this.SetLookup();
                }
            }
        }
       
        [RefreshProperties(RefreshProperties.All),DefaultValue(true)]
        public bool AllowNull
        {
            get { return allowNull; }
            set { allowNull = value; }
        }      
        public SelectionTypes SelectedType
        {
            get
            {
                return (SelectionTypes)this.LookUpEditFrom.EditValue;
                    
            }
            set
            {
                this.LookUpEditFrom.EditValue = value;
            }

            
        }
    }
}

