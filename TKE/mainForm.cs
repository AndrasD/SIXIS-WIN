using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using TKE.Properties;

namespace TKE
{
	public class mainForm : Form
	{
		private IContainer components;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem kilépésToolStripMenuItem;

		private ToolStripMenuItem lekerdezesekToolStripMenuItem;

		private ToolStripMenuItem dolgozókSzerintToolStripMenuItem;

		private ToolStripMenuItem törzsadatokToolStripMenuItem;

		private ToolStripMenuItem dolgozokToolStripMenuItem;

		private ToolStripMenuItem kódtáblákToolStripMenuItem;

		private Panel panelMain;

		private Label userNev;

		private ToolStripMenuItem kilométerElszámolásToolStripMenuItem;

		private ToolStripMenuItem összesítettElszámolásToolStripMenuItem;

		private Login bejelentkezes = new Login();

		private TKE.DataSet dataSet = new TKE.DataSet();

		private DataTable tableParameter = new DataTable();

		private SqlConnection myconn = new SqlConnection();

		private SqlConnection mysqlconn = new SqlConnection();

		private string rendszerconn;

		private SqlDataAdapter da;

		private string user;

		private int user_ID;

		private string pwd;

		private string jogosultsag = "1";

		public TKE.tke tke;

		public dolgozo dolgozoKarb;

		public lekerdezes1 lekerdezes;

		public TKE.lekerdezes2 lekerdezes2;

		public TKE.lekerdezes3 lekerdezes3;

		public TKE.parameter parameter;

		public string Jogosultsag
		{
			get
			{
				return this.jogosultsag;
			}
			set
			{
				this.jogosultsag = value;
			}
		}

		public SqlConnection MyConn
		{
			get
			{
				return this.myconn;
			}
			set
			{
				this.myconn = value;
			}
		}

		public SqlConnection MySqlConn
		{
			get
			{
				return this.mysqlconn;
			}
			set
			{
				this.mysqlconn = value;
			}
		}

		public string Password
		{
			get
			{
				return this.pwd;
			}
			set
			{
				this.pwd = value;
			}
		}

		public int UserId
		{
			get
			{
				return this.user_ID;
			}
		}

		public mainForm()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void dolgozókSzerintToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.panelBeallit(2);
		}

		private void dolgozókToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.panelBeallit(1);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lekerdezesekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dolgozókSzerintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilométerElszámolásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.összesítettElszámolásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.törzsadatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dolgozokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kódtáblákToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.userNev = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Image = global::TKE.Properties.Resources.power;
            this.kilépésToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // lekerdezesekToolStripMenuItem
            // 
            this.lekerdezesekToolStripMenuItem.Image = global::TKE.Properties.Resources.info;
            this.lekerdezesekToolStripMenuItem.Name = "lekerdezesekToolStripMenuItem";
            this.lekerdezesekToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.lekerdezesekToolStripMenuItem.Text = "Lekérdezések";
            // 
            // dolgozókSzerintToolStripMenuItem
            // 
            this.dolgozókSzerintToolStripMenuItem.Name = "dolgozókSzerintToolStripMenuItem";
            this.dolgozókSzerintToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.dolgozókSzerintToolStripMenuItem.Text = "Túlóra elszámolás";
            this.dolgozókSzerintToolStripMenuItem.Click += new System.EventHandler(this.dolgozókSzerintToolStripMenuItem_Click);
            // 
            // kilométerElszámolásToolStripMenuItem
            // 
            this.kilométerElszámolásToolStripMenuItem.Name = "kilométerElszámolásToolStripMenuItem";
            this.kilométerElszámolásToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.kilométerElszámolásToolStripMenuItem.Text = "Kilométer elszámolás";
            this.kilométerElszámolásToolStripMenuItem.Click += new System.EventHandler(this.kilométerElszámolásToolStripMenuItem_Click);
            // 
            // összesítettElszámolásToolStripMenuItem
            // 
            this.összesítettElszámolásToolStripMenuItem.Name = "összesítettElszámolásToolStripMenuItem";
            this.összesítettElszámolásToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.összesítettElszámolásToolStripMenuItem.Text = "Összesített elszámolás";
            this.összesítettElszámolásToolStripMenuItem.Click += new System.EventHandler(this.összesítettElszámolásToolStripMenuItem_Click);
            // 
            // törzsadatokToolStripMenuItem
            // 
            this.törzsadatokToolStripMenuItem.Image = global::TKE.Properties.Resources.config;
            this.törzsadatokToolStripMenuItem.Name = "törzsadatokToolStripMenuItem";
            this.törzsadatokToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.törzsadatokToolStripMenuItem.Text = "Törzsadatok";
            // 
            // dolgozokToolStripMenuItem
            // 
            this.dolgozokToolStripMenuItem.Image = global::TKE.Properties.Resources.User_Clients_01;
            this.dolgozokToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.dolgozokToolStripMenuItem.Name = "dolgozokToolStripMenuItem";
            this.dolgozokToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.dolgozokToolStripMenuItem.Text = "Dolgozók";
            this.dolgozokToolStripMenuItem.Click += new System.EventHandler(this.dolgozókToolStripMenuItem_Click);
            // 
            // kódtáblákToolStripMenuItem
            // 
            this.kódtáblákToolStripMenuItem.Image = global::TKE.Properties.Resources.Library_01;
            this.kódtáblákToolStripMenuItem.Name = "kódtáblákToolStripMenuItem";
            this.kódtáblákToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.kódtáblákToolStripMenuItem.Text = "Beállítás";
            this.kódtáblákToolStripMenuItem.Click += new System.EventHandler(this.kódtáblákToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1008, 706);
            this.panelMain.TabIndex = 9;
            // 
            // userNev
            // 
            this.userNev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userNev.Location = new System.Drawing.Point(799, 4);
            this.userNev.Name = "userNev";
            this.userNev.Size = new System.Drawing.Size(201, 21);
            this.userNev.TabIndex = 10;
            this.userNev.Text = "label1";
            this.userNev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.userNev);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Túlóra és Kilométer elszámolás";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("  Biztosan ki akar lépni!", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			{
				base.FormClosing -= new FormClosingEventHandler(this.mainForm_FormClosing);
				base.Close();
			}
		}

		private void kilométerElszámolásToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.panelBeallit(3);
		}

		private void kódtáblákToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.panelBeallit(4);
		}

		private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("  Biztosan ki akar lépni!", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			{
				e.Cancel = false;
				return;
			}
			e.Cancel = true;
		}

		private void mainForm_Load(object sender, EventArgs e)
		{
			if (this.bejelentkezes.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
			{
				base.Close();
				return;
			}
			this.myconn = this.bejelentkezes.Connection;
			this.rendszerconn = this.myconn.ConnectionString;
			this.user = this.bejelentkezes.User;
			this.user_ID = this.bejelentkezes.UserId;
			this.pwd = this.bejelentkezes.Pwd;
			this.jogosultsag = this.bejelentkezes.Jogosultsag;
			this.userNev.Text = this.bejelentkezes.UserNev;
			if (this.jogosultsag != "1")
			{
				this.dolgozókSzerintToolStripMenuItem.Enabled = false;
				this.kilométerElszámolásToolStripMenuItem.Enabled = false;
				this.dolgozokToolStripMenuItem.Enabled = false;
				this.kódtáblákToolStripMenuItem.Enabled = false;
			}
			this.da = new SqlDataAdapter("SELECT * FROM parameter", this.myconn);
			this.da.Fill(this.dataSet, "tableParameter");
			this.tableParameter = this.dataSet.Tables["tableParameter"];
			this.tke = new TKE.tke(this);
			this.panelMain.Controls.Add(this.tke);
			this.panelMain.Controls[0].Dock = DockStyle.Fill;
			if (this.jogosultsag == "1")
			{
				this.dolgozoKarb = new dolgozo(this);
				this.panelMain.Controls.Add(this.dolgozoKarb);
				this.lekerdezes = new lekerdezes1(this);
				this.panelMain.Controls.Add(this.lekerdezes);
				this.lekerdezes2 = new TKE.lekerdezes2(this);
				this.panelMain.Controls.Add(this.lekerdezes2);
				this.parameter = new TKE.parameter(this);
				this.panelMain.Controls.Add(this.parameter);
			}
			this.lekerdezes3 = new TKE.lekerdezes3(this);
			this.panelMain.Controls.Add(this.lekerdezes3);
			if (this.jogosultsag != "1")
			{
				this.panelMain.Controls[1].Visible = false;
				return;
			}
			this.panelMain.Controls[1].Visible = false;
			this.panelMain.Controls[2].Visible = false;
			this.panelMain.Controls[3].Visible = false;
			this.panelMain.Controls[4].Visible = false;
			this.panelMain.Controls[5].Visible = false;
		}

		private void összesítettElszámolásToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.jogosultsag == "1")
			{
				this.panelBeallit(5);
				return;
			}
			this.panelBeallit(1);
		}

		public void panelBeallit(int par)
		{
			for (int i = 0; i < this.panelMain.Controls.Count; i++)
			{
				if (par != i)
				{
					this.panelMain.Controls[i].Visible = false;
				}
				else
				{
					this.panelMain.Controls[i].Visible = true;
					this.panelMain.Controls[i].Dock = DockStyle.Fill;
				}
			}
		}

		public object parameterErtek(string key)
		{
			string str = null;
			DataRow[] dataRowArray = this.tableParameter.Select(string.Concat("nev = '", key.Trim(), "'"));
			if ((int)dataRowArray.Length > 0)
			{
				str = dataRowArray[0]["ertek"].ToString();
			}
			return str;
		}

		public void usercontrol_VisibleChanged(object sender, EventArgs e)
		{
			object obj = new object();
			lock (obj)
			{
				Control control = (Control)sender;
				this.panelMain.Controls[0].Visible = !control.Visible;
			}
		}

		public DataRow userRec()
		{
			return this.bejelentkezes.UserTable.Rows[0];
		}
	}
}