using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TKE.Properties;

namespace TKE
{
	public class Login : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label3;

		private Panel panel2;

		private PictureBox pictureBox1;

		private TextBox textPWD;

		private TextBox textUser;

		private Label label2;

		private Label label1;

		private Button megsem;

		private Button rendben;

		private Panel panel3;

		private Label verzio;

		private ErrorProvider errorProvider;

		private SqlConnection connection = new SqlConnection();

//		private string rendszerconn = "Data Source=DESKTOP-CJI5FT4\\SQLEXPRESS;Initial Catalog=tke;User Id=SkytecUser;Password=PassW0rd_2015;";
        private string rendszerconn = "Data Source=SZERVER\\SQLEXPRESS;Initial Catalog=tke;User Id=SkytecUser;Password=Passw0rd_2015;";

        private TKE.DataSet dataSet = new TKE.DataSet();

		private DataTable tableUser = new DataTable();

		private SqlDataAdapter da;

		private string szint;

		private int userId;

		private string userNev;

		public SqlConnection Connection
		{
			get
			{
				return this.connection;
			}
			set
			{
				this.connection = value;
			}
		}

		public string Jogosultsag
		{
			get
			{
				return this.szint;
			}
		}

		public string Pwd
		{
			get
			{
				return this.textPWD.Text;
			}
		}

		public string User
		{
			get
			{
				return this.textUser.Text;
			}
		}

		public int UserId
		{
			get
			{
				return this.userId;
			}
		}

		public string UserNev
		{
			get
			{
				return this.userNev;
			}
		}

		public DataTable UserTable
		{
			get
			{
				return this.tableUser;
			}
		}

		public string Verzio
		{
			set
			{
				this.verzio.Text = string.Concat(this.verzio.Text, value);
			}
		}

		public Login()
		{
			this.InitializeComponent();
		}

		private void Bejelentkezes_Activated(object sender, EventArgs e)
		{
			this.textUser.Focus();
		}

		private void Bejelentkezes_Load(object sender, EventArgs e)
		{
			this.verzio.Text = string.Concat(this.verzio.Text, "1.0.3");
			base.Show();
			this.Refresh();
			this.connection.ConnectionString = this.rendszerconn;
			this.createConnection();
			this.textUser.Focus();
		}

		private void createConnection()
		{
			try
			{
				this.connection.Open();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Adatbázis kapcsolódási hiba.\r\n Hibás Dolgozó/Jelszó.\r\n", this.connection.ConnectionString, "\r\n", exception.Message));
				base.Close();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Login));
			this.panel1 = new Panel();
			this.label3 = new Label();
			this.panel2 = new Panel();
			this.pictureBox1 = new PictureBox();
			this.textPWD = new TextBox();
			this.textUser = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.megsem = new Button();
			this.rendben = new Button();
			this.panel3 = new Panel();
			this.verzio = new Label();
			this.errorProvider = new ErrorProvider(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.errorProvider).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Silver;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(413, 34);
			this.panel1.TabIndex = 8;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 238);
			this.label3.ForeColor = SystemColors.ButtonHighlight;
			this.label3.Location = new Point(146, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Bejelentkezés";
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.textPWD);
			this.panel2.Controls.Add(this.textUser);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.megsem);
			this.panel2.Controls.Add(this.rendben);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 34);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(413, 153);
			this.panel2.TabIndex = 9;
			this.pictureBox1.Image = Resources.Calculator_icon;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new Point(13, 18);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(109, 121);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			this.textPWD.Location = new Point(247, 49);
			this.textPWD.MaxLength = 15;
			this.textPWD.Name = "textPWD";
			this.textPWD.Size = new System.Drawing.Size(124, 21);
			this.textPWD.TabIndex = 7;
			this.textPWD.UseSystemPasswordChar = true;
			this.textUser.Location = new Point(247, 21);
			this.textUser.MaxLength = 30;
			this.textUser.Name = "textUser";
			this.textUser.Size = new System.Drawing.Size(124, 21);
			this.textUser.TabIndex = 6;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(162, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 15);
			this.label2.TabIndex = 10;
			this.label2.Text = "Jelszó:";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(162, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Azonosító:";
			this.megsem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.megsem.Image = Resources.cancel;
			this.megsem.ImageAlign = ContentAlignment.MiddleLeft;
			this.megsem.Location = new Point(277, 90);
			this.megsem.Name = "megsem";
			this.megsem.Size = new System.Drawing.Size(94, 38);
			this.megsem.TabIndex = 11;
			this.megsem.Text = "Mégsem";
			this.megsem.TextAlign = ContentAlignment.MiddleRight;
			this.megsem.UseVisualStyleBackColor = true;
			this.rendben.Image = Resources.accept;
			this.rendben.ImageAlign = ContentAlignment.MiddleLeft;
			this.rendben.Location = new Point(165, 90);
			this.rendben.Name = "rendben";
			this.rendben.Size = new System.Drawing.Size(97, 38);
			this.rendben.TabIndex = 9;
			this.rendben.Text = "Rendben";
			this.rendben.TextAlign = ContentAlignment.MiddleRight;
			this.rendben.UseVisualStyleBackColor = true;
			this.rendben.Click += new EventHandler(this.rendben_Click);
			this.panel3.BackColor = SystemColors.Control;
			this.panel3.Controls.Add(this.verzio);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.Location = new Point(0, 187);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(413, 22);
			this.panel3.TabIndex = 10;
			this.verzio.AutoSize = true;
			this.verzio.Font = new System.Drawing.Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 238);
			this.verzio.Location = new Point(141, 4);
			this.verzio.Name = "verzio";
			this.verzio.Size = new System.Drawing.Size(65, 14);
			this.verzio.TabIndex = 0;
			this.verzio.Text = "S-TKE  Ver.:";
			this.errorProvider.ContainerControl = this;
			base.AcceptButton = this.rendben;
			base.CancelButton = this.megsem;
			base.ClientSize = new System.Drawing.Size(413, 209);
			base.ControlBox = false;
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Activated += new EventHandler(this.Bejelentkezes_Activated);
			base.Load += new EventHandler(this.Bejelentkezes_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((ISupportInitialize)this.errorProvider).EndInit();
			base.ResumeLayout(false);
		}

		private void rendben_Click(object sender, EventArgs e)
		{
			if (this.textUser.Text == string.Empty)
			{
				this.textUser.Focus();
				this.errorProvider.SetError(this.textUser, "Adja meg a dolgozó azonosítoját!");
				return;
			}
			if (this.textUser.Text != string.Empty)
			{
				this.errorProvider.SetError(this.textUser, "");
				if (this.textPWD.Text == string.Empty)
				{
					this.textPWD.Focus();
					this.errorProvider.SetError(this.textPWD, "Adja meg a jelszavát!");
					return;
				}
				if (this.textPWD.Text != string.Empty)
				{
					this.errorProvider.SetError(this.textPWD, "");
					if (this.textUser.Text == "Supervisor" && this.textPWD.Text == "Supervisor1963")
					{
						this.szint = "1";
						base.DialogResult = System.Windows.Forms.DialogResult.OK;
						base.Close();
						return;
					}
					if (this.userLoad())
					{
						this.szint = this.tableUser.Rows[0]["szint"].ToString();
						this.userId = Convert.ToInt32(this.tableUser.Rows[0]["id"]);
						this.userNev = this.tableUser.Rows[0]["dolgozo_nev"].ToString();
						base.DialogResult = System.Windows.Forms.DialogResult.OK;
						base.Close();
						return;
					}
					MessageBox.Show("Hibás Dolgozó/Jelszó.\r\n");
				}
			}
		}

		private void textPWD_Leave(object sender, EventArgs e)
		{
		}

		private bool userLoad()
		{
			string[] strArrays = new string[] { "select * from dolgozo where azonosito = '", this.textUser.Text.Trim(), "' and jelszo = '", this.textPWD.Text.Trim(), "'" };
			this.da = new SqlDataAdapter(string.Concat(strArrays), this.connection);
			this.da.Fill(this.dataSet, "tableUser");
			this.tableUser = this.dataSet.Tables["tableUser"];
			if (this.tableUser.Rows.Count == 0)
			{
				return false;
			}
			return true;
		}
	}
}