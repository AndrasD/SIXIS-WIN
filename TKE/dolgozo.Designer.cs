using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using TKE.Properties;

namespace TKE
{
	public class dolgozo : UserControl
	{
		private IContainer components;

		private ToolStrip toolStrip;

		private ToolStripButton buttonUj;

		private ToolStripButton buttonTorol;

		private ToolStripButton buttonMentes;

		private ToolStripButton buttonVissza;

		private GroupBox groupBox1;

		private Button button1;

		private Label label3;

		private Label label2;

		private TextBox textMegnevezes;

		private ComboBox comboSzint;

		private Label label5;

		private TextBox textAzonosito;

		private TextBox textJelszo;

		private Label label4;

		private DataGridView dataGV;

		private ErrorProvider errorProvider;

		private TextBox textBox3;

		private TextBox textBox2;

		private TextBox textBox1;

		private Label label7;

		private Label label6;

		private Label label1;

		private DataGridViewTextBoxColumn dolgozo_nev;

		private DataGridViewTextBoxColumn azonosito;

		private DataGridViewTextBoxColumn jelszo;

		private DataGridViewTextBoxColumn szint;

		private DataGridViewTextBoxColumn ORA_HK;

		private DataGridViewTextBoxColumn ORA_HV;

		private DataGridViewTextBoxColumn KM_SZORZO;

		private DataGridViewTextBoxColumn id;

		private TKE.DataSet dataSet = new TKE.DataSet();

		private DataTable tableDolgozo = new DataTable();

		private DataView viewDolgozo = new DataView();

		private SqlConnection myconn = new SqlConnection();

		private SqlDataAdapter da;

		private SqlCommandBuilder cb;

		private mainForm _mainForm;

		public dolgozo(mainForm mF)
		{
			this.myconn = mF.MyConn;
			this._mainForm = mF;
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.rendben();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			try
			{
				this.da.Update(this.tableDolgozo);
				this.tableDolgozo.AcceptChanges();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Hiba az adatbázis aktualizálásánál\r\n", exception.Message));
			}
		}

		private void buttonTorol_Click(object sender, EventArgs e)
		{
			this.variabelClear(base.Controls);
			if (this.dataGV.SelectedRows.Count > -1)
			{
				DataRow[] dataRowArray = this.tableDolgozo.Select(string.Concat("dolgozo_nev ='", this.dataGV.CurrentRow.Cells["dolgozo_nev"].Value, "'"));
				dataRowArray[0].Delete();
			}
		}

		private void buttonUj_Click(object sender, EventArgs e)
		{
			this.textAzonosito.ReadOnly = false;
			this.variabelClear(base.Controls);
			this.buttonUj.Enabled = false;
			this.buttonTorol.Enabled = false;
			this.buttonMentes.Enabled = false;
			this.textAzonosito.Focus();
		}

		private void buttonVissza_Click_1(object sender, EventArgs e)
		{
			base.Visible = false;
			this._mainForm.panelBeallit(0);
		}

		private void comboSzint_Leave(object sender, EventArgs e)
		{
			if (this.comboSzint.Text == string.Empty)
			{
				this.comboSzint.Text = "1";
			}
		}

		private void comboSzint_Validating(object sender, CancelEventArgs e)
		{
			this.mezoValidalas("szint");
		}

		private void dataGV_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				this.textAzonosito.ReadOnly = true;
				DataRow[] dataRowArray = this.tableDolgozo.Select(string.Concat("azonosito = '", this.dataGV.Rows[e.RowIndex].Cells["azonosito"].Value, "'"));
				this.variabelLoad(base.Controls, dataRowArray);
				this.buttonUj.Enabled = true;
				this.buttonTorol.Enabled = true;
				this.buttonMentes.Enabled = true;
				this.errorProvider.SetError(this.textAzonosito, "");
				this.errorProvider.SetError(this.textMegnevezes, "");
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

		private void dolgozo_Load(object sender, EventArgs e)
		{
			this.myconn = this._mainForm.MyConn;
			this.dolgozoLoad();
			if (this.tableDolgozo.Rows.Count == 0)
			{
				this.buttonUj_Click(sender, e);
				this.textAzonosito.Focus();
			}
		}

		private void dolgozoLoad()
		{
			this.da = new SqlDataAdapter("SELECT * FROM dolgozo order by dolgozo_nev", this.myconn);
			this.da.Fill(this.dataSet, "tableDolgozo");
			this.tableDolgozo = this.dataSet.Tables["tableDolgozo"];
			DataTable dataTable = this.tableDolgozo;
			DataColumn[] item = new DataColumn[] { this.tableDolgozo.Columns["azonosito"] };
			dataTable.PrimaryKey = item;
			this.viewDolgozo.BeginInit();
			this.viewDolgozo.Table = this.tableDolgozo;
			this.viewDolgozo.EndInit();
			this.dataGV.DataSource = this.viewDolgozo;
			this.cb = new SqlCommandBuilder(this.da);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(dolgozo));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			this.toolStrip = new ToolStrip();
			this.buttonUj = new ToolStripButton();
			this.buttonTorol = new ToolStripButton();
			this.buttonMentes = new ToolStripButton();
			this.buttonVissza = new ToolStripButton();
			this.groupBox1 = new GroupBox();
			this.button1 = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.textMegnevezes = new TextBox();
			this.comboSzint = new ComboBox();
			this.label5 = new Label();
			this.textAzonosito = new TextBox();
			this.textJelszo = new TextBox();
			this.label4 = new Label();
			this.dataGV = new DataGridView();
			this.errorProvider = new ErrorProvider(this.components);
			this.dolgozo_nev = new DataGridViewTextBoxColumn();
			this.azonosito = new DataGridViewTextBoxColumn();
			this.jelszo = new DataGridViewTextBoxColumn();
			this.szint = new DataGridViewTextBoxColumn();
			this.ORA_HK = new DataGridViewTextBoxColumn();
			this.ORA_HV = new DataGridViewTextBoxColumn();
			this.KM_SZORZO = new DataGridViewTextBoxColumn();
			this.id = new DataGridViewTextBoxColumn();
			this.label1 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.textBox3 = new TextBox();
			this.toolStrip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGV).BeginInit();
			((ISupportInitialize)this.errorProvider).BeginInit();
			base.SuspendLayout();
			this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripItemCollection items = this.toolStrip.Items;
			ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.buttonUj, this.buttonTorol, this.buttonMentes, this.buttonVissza };
			items.AddRange(toolStripItemArray);
			this.toolStrip.Location = new Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(842, 25);
			this.toolStrip.TabIndex = 2;
			this.buttonUj.Image = Resources.star;
			this.buttonUj.ImageTransparentColor = Color.Black;
			this.buttonUj.Name = "buttonUj";
			this.buttonUj.Size = new System.Drawing.Size(81, 22);
			this.buttonUj.Text = "Új felvítel";
			this.buttonUj.ToolTipText = "Új elem felvétele";
			this.buttonUj.Click += new EventHandler(this.buttonUj_Click);
			this.buttonTorol.Image = Resources.cancel;
			this.buttonTorol.ImageTransparentColor = Color.Black;
			this.buttonTorol.Name = "buttonTorol";
			this.buttonTorol.Size = new System.Drawing.Size(58, 22);
			this.buttonTorol.Text = "Töröl";
			this.buttonTorol.Click += new EventHandler(this.buttonTorol_Click);
			this.buttonMentes.Image = (Image)componentResourceManager.GetObject("buttonMentes.Image");
			this.buttonMentes.ImageTransparentColor = Color.Magenta;
			this.buttonMentes.Name = "buttonMentes";
			this.buttonMentes.Size = new System.Drawing.Size(69, 22);
			this.buttonMentes.Text = "Mentés";
			this.buttonMentes.Click += new EventHandler(this.buttonOK_Click);
			this.buttonVissza.Image = Resources.left;
			this.buttonVissza.ImageTransparentColor = Color.Black;
			this.buttonVissza.Name = "buttonVissza";
			this.buttonVissza.Size = new System.Drawing.Size(64, 22);
			this.buttonVissza.Text = "Vissza";
			this.buttonVissza.Click += new EventHandler(this.buttonVissza_Click_1);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textMegnevezes);
			this.groupBox1.Controls.Add(this.comboSzint);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textAzonosito);
			this.groupBox1.Controls.Add(this.textJelszo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Dock = DockStyle.Top;
			this.groupBox1.Location = new Point(0, 187);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(842, 241);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Adatok";
			this.button1.Image = Resources.accept;
			this.button1.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1.Location = new Point(409, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 40);
			this.button1.TabIndex = 18;
			this.button1.Text = "Rendben";
			this.button1.TextAlign = ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(6, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Azonosító:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(6, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Név:";
			this.textMegnevezes.Location = new Point(128, 57);
			this.textMegnevezes.MaxLength = 45;
			this.textMegnevezes.Name = "textMegnevezes";
			this.textMegnevezes.Size = new System.Drawing.Size(200, 20);
			this.textMegnevezes.TabIndex = 1;
			this.textMegnevezes.Tag = "dolgozo_nev";
			this.comboSzint.FormattingEnabled = true;
			this.comboSzint.Items.AddRange(new object[] { "1", "2", "3" });
			this.comboSzint.Location = new Point(128, 109);
			this.comboSzint.Name = "comboSzint";
			this.comboSzint.Size = new System.Drawing.Size(59, 21);
			this.comboSzint.TabIndex = 14;
			this.comboSzint.Tag = "szint";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(6, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Jogosultsági szint:";
			this.textAzonosito.Location = new Point(128, 31);
			this.textAzonosito.MaxLength = 10;
			this.textAzonosito.Name = "textAzonosito";
			this.textAzonosito.ReadOnly = true;
			this.textAzonosito.Size = new System.Drawing.Size(125, 20);
			this.textAzonosito.TabIndex = 0;
			this.textAzonosito.Tag = "azonosito";
			this.textJelszo.Location = new Point(128, 83);
			this.textJelszo.MaxLength = 45;
			this.textJelszo.Name = "textJelszo";
			this.textJelszo.Size = new System.Drawing.Size(200, 20);
			this.textJelszo.TabIndex = 3;
			this.textJelszo.Tag = "jelszo";
			this.textJelszo.UseSystemPasswordChar = true;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(6, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Jelszó:";
			this.dataGV.AllowUserToAddRows = false;
			this.dataGV.AllowUserToDeleteRows = false;
			this.dataGV.AllowUserToResizeColumns = false;
			this.dataGV.AllowUserToResizeRows = false;
			this.dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGV.BackgroundColor = SystemColors.ControlDark;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dataGV.Columns;
			DataGridViewColumn[] dolgozoNev = new DataGridViewColumn[] { this.dolgozo_nev, this.azonosito, this.jelszo, this.szint, this.ORA_HK, this.ORA_HV, this.KM_SZORZO, this.id };
			columns.AddRange(dolgozoNev);
			this.dataGV.Dock = DockStyle.Top;
			this.dataGV.Location = new Point(0, 25);
			this.dataGV.MultiSelect = false;
			this.dataGV.Name = "dataGV";
			this.dataGV.ReadOnly = true;
			this.dataGV.RowHeadersWidth = 24;
			this.dataGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGV.Size = new System.Drawing.Size(842, 162);
			this.dataGV.TabIndex = 19;
			this.dataGV.CellClick += new DataGridViewCellEventHandler(this.dataGV_CellClick);
			this.errorProvider.ContainerControl = this;
			this.dolgozo_nev.DataPropertyName = "dolgozo_nev";
			this.dolgozo_nev.Frozen = true;
			this.dolgozo_nev.HeaderText = "Dolgozo neve";
			this.dolgozo_nev.Name = "dolgozo_nev";
			this.dolgozo_nev.ReadOnly = true;
			this.dolgozo_nev.Width = 110;
			this.azonosito.DataPropertyName = "azonosito";
			this.azonosito.HeaderText = "Azonosító";
			this.azonosito.Name = "azonosito";
			this.azonosito.ReadOnly = true;
			this.azonosito.Width = 91;
			this.jelszo.DataPropertyName = "jelszo";
			this.jelszo.HeaderText = "Jelszó";
			this.jelszo.Name = "jelszo";
			this.jelszo.ReadOnly = true;
			this.jelszo.Width = 70;
			this.szint.DataPropertyName = "szint";
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.szint.DefaultCellStyle = dataGridViewCellStyle1;
			this.szint.HeaderText = "Jog.szint";
			this.szint.Name = "szint";
			this.szint.ReadOnly = true;
			this.szint.Width = 85;
			this.ORA_HK.DataPropertyName = "ORA_HK";
			this.ORA_HK.HeaderText = "Óra hétközben";
			this.ORA_HK.Name = "ORA_HK";
			this.ORA_HK.ReadOnly = true;
			this.ORA_HK.Width = 118;
			this.ORA_HV.DataPropertyName = "ORA_HV";
			this.ORA_HV.HeaderText = "Óra hétvégén";
			this.ORA_HV.Name = "ORA_HV";
			this.ORA_HV.ReadOnly = true;
			this.ORA_HV.Width = 109;
			this.KM_SZORZO.DataPropertyName = "KM_SZORZO";
			this.KM_SZORZO.HeaderText = "Km szorzó";
			this.KM_SZORZO.Name = "KM_SZORZO";
			this.KM_SZORZO.ReadOnly = true;
			this.KM_SZORZO.Width = 96;
			this.id.DataPropertyName = "id";
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Resizable = DataGridViewTriState.False;
			this.id.Visible = false;
			this.id.Width = 43;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Óra hétközben:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 165);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 20;
			this.label6.Text = "Óra hétégén:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(6, 191);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(86, 13);
			this.label7.TabIndex = 21;
			this.label7.Text = "Kilóméter szorzó:";
			this.textBox1.Location = new Point(128, 136);
			this.textBox1.MaxLength = 45;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(59, 20);
			this.textBox1.TabIndex = 22;
			this.textBox1.Tag = "ora_hk";
			this.textBox2.Location = new Point(128, 162);
			this.textBox2.MaxLength = 45;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(59, 20);
			this.textBox2.TabIndex = 23;
			this.textBox2.Tag = "ora_hv";
			this.textBox3.Location = new Point(128, 188);
			this.textBox3.MaxLength = 45;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(59, 20);
			this.textBox3.TabIndex = 24;
			this.textBox3.Tag = "km_szorzo";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.dataGV);
			base.Controls.Add(this.toolStrip);
			base.Name = "dolgozo";
			base.Size = new System.Drawing.Size(842, 612);
			base.Load += new EventHandler(this.dolgozo_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.dataGV).EndInit();
			((ISupportInitialize)this.errorProvider).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private bool mezoValidalas(string mezo)
		{
			bool flag = false;
			if (mezo == "azonosito")
			{
				if (!this.textAzonosito.ReadOnly)
				{
					DataRow dataRow = this.tableDolgozo.Rows.Find(this.textAzonosito.Text);
					if (this.textAzonosito.Text == string.Empty)
					{
						this.textAzonosito.Focus();
						this.errorProvider.SetError(this.textAzonosito, "Az azonsitót legyen szíves megadni.");
						flag = false;
					}
					else if (dataRow == null)
					{
						this.errorProvider.SetError(this.textAzonosito, "");
						flag = true;
					}
					else
					{
						this.textAzonosito.Focus();
						this.errorProvider.SetError(this.textAzonosito, "Már létezik!");
						flag = false;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (mezo == "nev")
			{
				if (this.textMegnevezes.Text != string.Empty)
				{
					this.errorProvider.SetError(this.textMegnevezes, "");
					flag = true;
				}
				else
				{
					this.textMegnevezes.Focus();
					this.errorProvider.SetError(this.textMegnevezes, "A nevet legyen szíves megadni.");
					flag = false;
				}
			}
			if (mezo == "jelszo")
			{
				if (this.textJelszo.Text != string.Empty)
				{
					this.errorProvider.SetError(this.textJelszo, "");
					flag = true;
				}
				else
				{
					this.textJelszo.Focus();
					this.errorProvider.SetError(this.textJelszo, "A jelszót legyen szíves megadni.");
					flag = false;
				}
			}
			if (mezo == "szint")
			{
				if (this.comboSzint.Text == string.Empty)
				{
					this.comboSzint.Focus();
					this.errorProvider.SetError(this.comboSzint, "A szintet legyen szíves megadni.");
					flag = false;
				}
				else if (Convert.ToInt32(this.comboSzint.Text) < 1 || Convert.ToInt32(this.comboSzint.Text) > 3)
				{
					this.comboSzint.Focus();
					this.errorProvider.SetError(this.comboSzint, "A szint csak 1 és 3 között lehet.");
					flag = false;
				}
				else
				{
					this.errorProvider.SetError(this.comboSzint, "");
					flag = true;
				}
			}
			return flag;
		}

		private void rendben()
		{
			if (this.mezoValidalas("azonosito") && this.mezoValidalas("nev") && this.mezoValidalas("jelszo") && this.mezoValidalas("szint"))
			{
				if (this.textAzonosito.ReadOnly)
				{
					DataRow dataRow = this.tableDolgozo.Rows.Find(this.dataGV.CurrentRow.Cells["azonosito"].Value);
					this.variabelSave(base.Controls, dataRow);
				}
				else
				{
					DataRow dataRow1 = this.tableDolgozo.NewRow();
					this.variabelSave(base.Controls, dataRow1);
					this.tableDolgozo.Rows.Add(dataRow1);
					this.variabelClear(base.Controls);
				}
				this.buttonUj.Enabled = true;
				this.buttonTorol.Enabled = true;
				this.buttonMentes.Enabled = true;
			}
		}

		private void textAzonosito_Validating(object sender, CancelEventArgs e)
		{
			this.mezoValidalas("azonsoito");
		}

		private void textMegnevezes_Validating(object sender, CancelEventArgs e)
		{
			this.mezoValidalas("nev");
		}

		private void variabelClear(Control.ControlCollection con)
		{
			this.errorProvider.SetError(this.textMegnevezes, "");
			for (int i = 0; i < con.Count; i++)
			{
				if (con[i].GetType().Name == "GroupBox")
				{
					this.variabelClear(con[i].Controls);
				}
				if (con[i].Tag != null)
				{
					con[i].Text = string.Empty;
				}
			}
		}

		private void variabelLoad(Control.ControlCollection con, DataRow[] row)
		{
			for (int i = 0; i < con.Count; i++)
			{
				if (con[i].GetType().Name == "GroupBox")
				{
					this.variabelLoad(con[i].Controls, row);
				}
				if (con[i].Tag != null)
				{
					con[i].Text = row[0][(string)con[i].Tag].ToString();
				}
			}
		}

		private void variabelSave(Control.ControlCollection con, DataRow row)
		{
			for (int i = 0; i < con.Count; i++)
			{
				if (con[i].GetType().Name == "GroupBox")
				{
					this.variabelSave(con[i].Controls, row);
				}
				if (con[i].Tag != null)
				{
					row[(string)con[i].Tag] = con[i].Text;
				}
			}
		}
	}
}