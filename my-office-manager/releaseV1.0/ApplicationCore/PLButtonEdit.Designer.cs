namespace ProtocolVN.Framework.Trial
{
    partial class PLButtonEdit
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this._buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this._buttonEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonEdit
            // 
            this._buttonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonEdit.Location = new System.Drawing.Point(0, 0);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this._buttonEdit.Properties.Appearance.Options.UseBackColor = true;
            this._buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Xóa", "Delete", null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Thêm", "Get", null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Mở", "Open", null, true)});
            this._buttonEdit.Properties.NullText = "Chọn tập tin...";
            this._buttonEdit.Properties.ReadOnly = true;
            this._buttonEdit.Size = new System.Drawing.Size(426, 20);
            this._buttonEdit.TabIndex = 1;
            this._buttonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this._buttonEdit_ButtonClick);
            // 
            // PLButtonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonEdit);
            this.Name = "PLButtonEdit";
            this.Size = new System.Drawing.Size(426, 24);
            this.Load += new System.EventHandler(this.PLButtonEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this._buttonEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.ButtonEdit _buttonEdit;

    }
}
