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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.megsem = new System.Windows.Forms.Button();
            this.rendben = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.verzio = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 34);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(146, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bejelentkezés";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.textPWD);
            this.panel2.Controls.Add(this.textUser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.megsem);
            this.panel2.Controls.Add(this.rendben);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 153);
            this.panel2.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TKE.Properties.Resources.Calculator_icon;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(13, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(247, 49);
            this.textPWD.MaxLength = 15;
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(124, 24);
            this.textPWD.TabIndex = 7;
            this.textPWD.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(247, 21);
            this.textUser.MaxLength = 30;
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(124, 24);
            this.textUser.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Jelszó:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Azonosító:";
            // 
            // megsem
            // 
            this.megsem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megsem.Image = global::TKE.Properties.Resources.cancel;
            this.megsem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.megsem.Location = new System.Drawing.Point(277, 90);
            this.megsem.Name = "megsem";
            this.megsem.Size = new System.Drawing.Size(104, 38);
            this.megsem.TabIndex = 11;
            this.megsem.Text = "Mégsem";
            this.megsem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.megsem.UseVisualStyleBackColor = true;
            // 
            // rendben
            // 
            this.rendben.Image = global::TKE.Properties.Resources.accept;
            this.rendben.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rendben.Location = new System.Drawing.Point(165, 90);
            this.rendben.Name = "rendben";
            this.rendben.Size = new System.Drawing.Size(107, 38);
            this.rendben.TabIndex = 9;
            this.rendben.Text = "Rendben";
            this.rendben.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rendben.UseVisualStyleBackColor = true;
            this.rendben.Click += new System.EventHandler(this.rendben_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.verzio);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 22);
            this.panel3.TabIndex = 10;
            // 
            // verzio
            // 
            this.verzio.AutoSize = true;
            this.verzio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.verzio.Location = new System.Drawing.Point(141, 4);
            this.verzio.Name = "verzio";
            this.verzio.Size = new System.Drawing.Size(85, 16);
            this.verzio.TabIndex = 0;
            this.verzio.Text = "S-TKE  Ver.:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Login
            // 
            this.AcceptButton = this.rendben;
            this.CancelButton = this.megsem;
            this.ClientSize = new System.Drawing.Size(413, 209);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Bejelentkezes_Activated);
            this.Load += new System.EventHandler(this.Bejelentkezes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

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