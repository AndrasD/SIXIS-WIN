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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(mainForm));
			this.menuStrip1 = new MenuStrip();
			this.kilépésToolStripMenuItem = new ToolStripMenuItem();
			this.lekerdezesekToolStripMenuItem = new ToolStripMenuItem();
			this.dolgozókSzerintToolStripMenuItem = new ToolStripMenuItem();
			this.kilométerElszámolásToolStripMenuItem = new ToolStripMenuItem();
			this.összesítettElszámolásToolStripMenuItem = new ToolStripMenuItem();
			this.törzsadatokToolStripMenuItem = new ToolStripMenuItem();
			this.dolgozokToolStripMenuItem = new ToolStripMenuItem();
			this.kódtáblákToolStripMenuItem = new ToolStripMenuItem();
			this.panelMain = new Panel();
			this.userNev = new Label();
			this.menuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 238);
			ToolStripItemCollection items = this.menuStrip1.Items;
			ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.kilépésToolStripMenuItem, this.lekerdezesekToolStripMenuItem, this.törzsadatokToolStripMenuItem };
			items.AddRange(toolStripItemArray);
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1008, 28);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			this.kilépésToolStripMenuItem.Image = Resources.power;
			this.kilépésToolStripMenuItem.ImageTransparentColor = Color.Black;
			this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
			this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
			this.kilépésToolStripMenuItem.Text = "Kilépés";
			this.kilépésToolStripMenuItem.Click += new EventHandler(this.kilépésToolStripMenuItem_Click);
			ToolStripItemCollection dropDownItems = this.lekerdezesekToolStripMenuItem.DropDownItems;
			ToolStripItem[] toolStripItemArray1 = new ToolStripItem[] { this.dolgozókSzerintToolStripMenuItem, this.kilométerElszámolásToolStripMenuItem, this.összesítettElszámolásToolStripMenuItem };
			dropDownItems.AddRange(toolStripItemArray1);
			this.lekerdezesekToolStripMenuItem.Image = Resources.info;
			this.lekerdezesekToolStripMenuItem.Name = "lekerdezesekToolStripMenuItem";
			this.lekerdezesekToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
			this.lekerdezesekToolStripMenuItem.Text = "Lekérdezések";
			this.dolgozókSzerintToolStripMenuItem.Name = "dolgozókSzerintToolStripMenuItem";
			this.dolgozókSzerintToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
			this.dolgozókSzerintToolStripMenuItem.Text = "Túlóra elszámolás";
			this.dolgozókSzerintToolStripMenuItem.Click += new EventHandler(this.dolgozókSzerintToolStripMenuItem_Click);
			this.kilométerElszámolásToolStripMenuItem.Name = "kilométerElszámolásToolStripMenuItem";
			this.kilométerElszámolásToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
			this.kilométerElszámolásToolStripMenuItem.Text = "Kilométer elszámolás";
			this.kilométerElszámolásToolStripMenuItem.Click += new EventHandler(this.kilométerElszámolásToolStripMenuItem_Click);
			this.összesítettElszámolásToolStripMenuItem.Name = "összesítettElszámolásToolStripMenuItem";
			this.összesítettElszámolásToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
			this.összesítettElszámolásToolStripMenuItem.Text = "Összesített elszámolás";
			this.összesítettElszámolásToolStripMenuItem.Click += new EventHandler(this.összesítettElszámolásToolStripMenuItem_Click);
			ToolStripItemCollection toolStripItemCollections = this.törzsadatokToolStripMenuItem.DropDownItems;
			ToolStripItem[] toolStripItemArray2 = new ToolStripItem[] { this.dolgozokToolStripMenuItem, this.kódtáblákToolStripMenuItem };
			toolStripItemCollections.AddRange(toolStripItemArray2);
			this.törzsadatokToolStripMenuItem.Image = Resources.config;
			this.törzsadatokToolStripMenuItem.Name = "törzsadatokToolStripMenuItem";
			this.törzsadatokToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
			this.törzsadatokToolStripMenuItem.Text = "Törzsadatok";
			this.dolgozokToolStripMenuItem.Image = Resources.User_Clients_01;
			this.dolgozokToolStripMenuItem.ImageTransparentColor = Color.White;
			this.dolgozokToolStripMenuItem.Name = "dolgozokToolStripMenuItem";
			this.dolgozokToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
			this.dolgozokToolStripMenuItem.Text = "Dolgozók";
			this.dolgozokToolStripMenuItem.Click += new EventHandler(this.dolgozókToolStripMenuItem_Click);
			this.kódtáblákToolStripMenuItem.Image = Resources.Library_01;
			this.kódtáblákToolStripMenuItem.Name = "kódtáblákToolStripMenuItem";
			this.kódtáblákToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
			this.kódtáblákToolStripMenuItem.Text = "Beállítás";
			this.kódtáblákToolStripMenuItem.Click += new EventHandler(this.kódtáblákToolStripMenuItem_Click);
			this.panelMain.Dock = DockStyle.Fill;
			this.panelMain.Location = new Point(0, 28);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1008, 702);
			this.panelMain.TabIndex = 9;
			this.userNev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.userNev.Location = new Point(799, 4);
			this.userNev.Name = "userNev";
			this.userNev.Size = new System.Drawing.Size(201, 21);
			this.userNev.TabIndex = 10;
			this.userNev.Text = "label1";
			this.userNev.TextAlign = ContentAlignment.MiddleRight;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1008, 730);
			base.Controls.Add(this.userNev);
			base.Controls.Add(this.panelMain);
			base.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "mainForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Túlóra és Kilométer elszámolás";
			base.FormClosing += new FormClosingEventHandler(this.mainForm_FormClosing);
			base.Load += new EventHandler(this.mainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
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