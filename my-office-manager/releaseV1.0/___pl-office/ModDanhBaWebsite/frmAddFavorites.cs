using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DevExpress.XtraBars.Demos.BrowserDemo {
	/// <summary>
	/// Summary description for frmAddFavorites.
	/// </summary>
	public partial class frmAddFavorites : DevExpress.XtraEditors.XtraForm {
		public string LocationName {
			get { return textBox1.Text; }
		}

		public string LocationURL {
			get { return textBox2.Text; }
		}

		public frmAddFavorites(string name, string URL, Image img) : this(name, URL, img, true) {}
		public frmAddFavorites(string name, string URL, Image img, bool isAdd) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			textBox1.Text = name;
			textBox2.Text = URL;
			pictureBox1.Image = img;
			if(!isAdd) {
				Text = "Edit Favorite Item";
				label1.Text = "Use the following edit fields to change this Favorite item description or the URL.";
			}
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		

		#region Windows Form Designer generated code
		
		#endregion

	}
}
