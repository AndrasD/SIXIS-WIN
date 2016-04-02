using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using TKE.Properties;

namespace TKE
{
	public class tke : UserControl
	{
		private IContainer components;

		private Panel panel1;

		private DateTimePicker dateTimePicker;

		private SplitContainer splitContainer1;

		private GroupBox groupBoxT;

		private ComboBox comboBoxT;

		private Label textOsszegT;

		private DataGridView dataGVT;

		private Label label4;

		private TextBox textBoxT;

		private Label label3;

		private Label dayofweekT;

		private Label label1;

		private GroupBox groupBoxK;

		private Label textSummaT;

		private Button button1T;

		private ToolStrip toolStrip;

		private ToolStripButton buttonUjT;

		private ToolStripButton buttonTorolT;

		private ErrorProvider errorProvider;

		private Label datumT;

		private Label textSzorzoT;

		private ToolStrip toolStrip1;

		private ToolStripButton buttonUjK;

		private ToolStripButton buttonTorolK;

		private Label textSummaK;

		private DataGridView dataGVK;

		private Label datumK;

		private Button button1K;

		private ComboBox comboBoxK;

		private Label dayofweekK;

		private Label label10;

		private Label textSzorzoK;

		private Label textOsszegK;

		private Label label7;

		private Label label6;

		private Label label2;

		private TextBox textBox3;

		private Label label8;

		private TextBox textBox2;

		private TextBox textBox1;

		private Button buttonCT;

		private Button buttonCK;

		private MaskedTextBox oraT;

		private MaskedTextBox kmT;

		private Button buttonRefresh;

		private Button buttonMentes;

		private DataGridViewTextBoxColumn idK;

		private DataGridViewTextBoxColumn datumKK;

		private DataGridViewTextBoxColumn honnan;

		private DataGridViewTextBoxColumn hova;

		private DataGridViewTextBoxColumn km;

		private DataGridViewTextBoxColumn osszegK;

		private DataGridViewCheckBoxColumn kFizetve;

		private DataGridViewTextBoxColumn szovegK;

		private DataGridViewTextBoxColumn dolgozo_idK;

		private DataGridViewTextBoxColumn szorzoK;

		private DataGridViewTextBoxColumn id;

		private DataGridViewTextBoxColumn Datum;

		private DataGridViewTextBoxColumn szoveg;

		private DataGridViewTextBoxColumn ora;

		private DataGridViewTextBoxColumn osszeg;

		private DataGridViewCheckBoxColumn Fizetve;

		private DataGridViewTextBoxColumn dolgozo_id;

		private DataGridViewTextBoxColumn szorzo;

		private ComboBox comboDolgozo;

		private TKE.DataSet dataSet1;

		private TKE.DataSet dataSet = new TKE.DataSet();

		private DataTable tableTulora = new DataTable();

		private DataView viewTulora = new DataView();

		private SqlConnection myconn = new SqlConnection();

		private SqlDataAdapter daTulora;

		private SqlCommandBuilder cbTulora;

		private DataTable tableKilometer = new DataTable();

		private DataView viewKilometer = new DataView();

		private SqlDataAdapter da;

		private SqlDataAdapter daKilometer;

		private SqlCommandBuilder cbKilometer;

		private int user_ID;

		private int tmpUserId;

		private mainForm MainForm;

		private DataRow aktualisSorT;

		private DataRow aktualisSorK;

		private int maxDate;

		private DataTable tableUser = new DataTable();

		private int userORA_SZORZO_HK;

		private int userORA_SZORZO_HV;

		private int userKM_SZORZO;

		private DataTable dolgozok = new DataTable();

		public tke(mainForm _mainForm)
		{
			this.user_ID = _mainForm.UserId;
			this.tmpUserId = this.user_ID;
			this.myconn = _mainForm.MyConn;
			this.MainForm = _mainForm;
			this.userORA_SZORZO_HK = Convert.ToInt32(_mainForm.userRec()["ORA_HK"].ToString());
			this.userORA_SZORZO_HV = Convert.ToInt32(_mainForm.userRec()["ORA_HV"].ToString());
			this.userKM_SZORZO = Convert.ToInt32(_mainForm.userRec()["KM_SZORZO"].ToString());
			this.InitializeComponent();
			this.comboDolgozo.SelectedIndexChanged -= new EventHandler(this.comboDolgozo_SelectedIndexChanged);
			this.dolgozok.Clear();
			this.da = new SqlDataAdapter("select * from dolgozo ", this.myconn);
			this.da.Fill(this.dataSet, "dolgozok");
			this.dolgozok = this.dataSet.Tables["dolgozok"];
			this.comboDolgozo.DataSource = this.dolgozok;
			this.comboDolgozo.DisplayMember = "dolgozo_nev";
			this.comboDolgozo.ValueMember = "id";
			if (this.MainForm.Jogosultsag != "1")
			{
				this.comboDolgozo.Visible = false;
				this.dataGVT.Columns["Fizetve"].ReadOnly = true;
				this.dataGVK.Columns["kFizetve"].ReadOnly = true;
			}
			this.comboDolgozo.SelectedIndexChanged += new EventHandler(this.comboDolgozo_SelectedIndexChanged);
		}

		private void button1K_Click(object sender, EventArgs e)
		{
			this.rendbenK();
			this.countSumma(this.tableKilometer);
		}

		private void button1T_Click(object sender, EventArgs e)
		{
			this.rendbenT();
			this.countSumma(this.tableTulora);
		}

		private void buttonCK_Click(object sender, EventArgs e)
		{
			if (!this.buttonUjK.Enabled && !this.buttonTorolK.Enabled && this.dataGVK.Rows.Count > 0)
			{
				DataRow dataRow = this.aktualisSorK;
				this.variabelLoad(this.groupBoxK.Controls, dataRow);
				this.buttonUjK.Enabled = true;
				this.buttonTorolK.Enabled = true;
			}
		}

		private void buttonCT_Click(object sender, EventArgs e)
		{
			if (!this.buttonUjT.Enabled && !this.buttonTorolT.Enabled && this.dataGVT.Rows.Count > 0)
			{
				DataRow dataRow = this.aktualisSorT;
				this.variabelLoad(this.groupBoxT.Controls, dataRow);
				this.buttonUjT.Enabled = true;
				this.buttonTorolT.Enabled = true;
			}
		}

		private void buttonMentes_Click(object sender, EventArgs e)
		{
			this.buttonOKT_Click(sender, e);
			this.buttonOKK_Click(sender, e);
		}

		private void buttonOKK_Click(object sender, EventArgs e)
		{
			try
			{
				this.daKilometer.Update(this.tableKilometer);
				this.tableKilometer.AcceptChanges();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Hiba az adatbázis aktualizálásánál\r\n", exception.Message));
			}
		}

		private void buttonOKT_Click(object sender, EventArgs e)
		{
			try
			{
				this.daTulora.Update(this.tableTulora);
				this.tableTulora.AcceptChanges();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Hiba az adatbázis aktualizálásánál\r\n", exception.Message));
			}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			this.variabelClear(this.groupBoxT.Controls);
			this.variabelClear(this.groupBoxK.Controls);
			this.dateTimePicker.Value = DateTime.Today;
			this.dateTimePicker_ValueChanged(sender, e);
			this.tableUser.Clear();
			this.da = new SqlDataAdapter(string.Concat("select * from dolgozo where id = ", this.tmpUserId.ToString()), this.myconn);
			this.da.Fill(this.dataSet, "tableUser");
			this.tableUser = this.dataSet.Tables["tableUser"];
			this.userORA_SZORZO_HK = Convert.ToInt32(this.tableUser.Rows[0]["ORA_HK"].ToString());
			this.userORA_SZORZO_HV = Convert.ToInt32(this.tableUser.Rows[0]["ORA_HV"].ToString());
			this.userKM_SZORZO = Convert.ToInt32(this.tableUser.Rows[0]["KM_SZORZO"].ToString());
		}

		private void buttonTorolK_Click(object sender, EventArgs e)
		{
			this.variabelClear(this.groupBoxK.Controls);
			if (this.dataGVK.SelectedRows.Count > 0 && this.aktualisSorK["Fizetve"].ToString() != "1")
			{
				this.aktualisSorK.Delete();
			}
			this.countSumma(this.tableKilometer);
		}

		private void buttonTorolT_Click(object sender, EventArgs e)
		{
			this.variabelClear(this.groupBoxT.Controls);
			if (this.dataGVT.SelectedRows.Count > 0 && this.aktualisSorT["Fizetve"].ToString() != "1")
			{
				this.aktualisSorT.Delete();
			}
			this.countSumma(this.tableTulora);
		}

		private void buttonUjK_Click(object sender, EventArgs e)
		{
			this.variabelClear(this.groupBoxK.Controls);
			this.buttonUjK.Enabled = false;
			this.buttonTorolK.Enabled = false;
			this.button1K.Enabled = true;
			this.comboBoxK.Enabled = true;
			this.textBox1.Enabled = true;
			this.textBox2.Enabled = true;
			this.kmT.Enabled = true;
			this.textBox3.Enabled = true;
		}

		private void buttonUjT_Click(object sender, EventArgs e)
		{
			this.variabelClear(this.groupBoxT.Controls);
			this.buttonUjT.Enabled = false;
			this.buttonTorolT.Enabled = false;
			this.button1T.Enabled = true;
			this.comboBoxT.Enabled = true;
			this.textBoxT.Enabled = true;
			this.oraT.Enabled = true;
		}

		private void comboBoxK_SelectedValueChanged(object sender, EventArgs e)
		{
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, Convert.ToInt32(this.comboBoxK.Text));
			this.dayofweekK.Text = dateTime.ToString("dddd", new CultureInfo("hu-HU"));
		}

		private void comboBoxK_TextUpdate(object sender, EventArgs e)
		{
			if (this.mezoValidalas("comboBoxK"))
			{
				this.comboBoxK_SelectedValueChanged(sender, e);
			}
		}

		private void comboBoxT_SelectedValueChanged(object sender, EventArgs e)
		{
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, Convert.ToInt32(this.comboBoxT.Text));
			this.dayofweekT.Text = dateTime.ToString("dddd", new CultureInfo("hu-HU"));
			this.osszegSzamolas();
		}

		private void comboBoxT_TextUpdate(object sender, EventArgs e)
		{
			if (this.mezoValidalas("comboBoxT"))
			{
				this.comboBoxT_SelectedValueChanged(sender, e);
			}
		}

		private void comboDolgozo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.MainForm.Jogosultsag == "1")
			{
				this.tmpUserId = Convert.ToInt32(this.comboDolgozo.SelectedValue.ToString());
			}
			this.tableUser.Clear();
			this.da = new SqlDataAdapter(string.Concat("select * from dolgozo where id = ", this.tmpUserId.ToString()), this.myconn);
			this.da.Fill(this.dataSet, "tableUser");
			this.tableUser = this.dataSet.Tables["tableUser"];
			this.userORA_SZORZO_HK = Convert.ToInt32(this.tableUser.Rows[0]["ORA_HK"].ToString());
			this.userORA_SZORZO_HV = Convert.ToInt32(this.tableUser.Rows[0]["ORA_HV"].ToString());
			this.userKM_SZORZO = Convert.ToInt32(this.tableUser.Rows[0]["KM_SZORZO"].ToString());
			this.dateTimePicker_ValueChanged(sender, e);
		}

		private void countSumma(DataTable tab)
		{
			if (tab.TableName == "tableTulora")
			{
				this.textSummaT.Text = "0";
				for (int i = 0; i < tab.Rows.Count; i++)
				{
					if (tab.Rows[i].RowState != DataRowState.Deleted)
					{
						this.textSummaT.Text = Convert.ToString(Convert.ToInt32(this.textSummaT.Text) + Convert.ToInt32(tab.Rows[i]["Összeg"]));
					}
				}
				return;
			}
			this.textSummaK.Text = "0";
			for (int j = 0; j < tab.Rows.Count; j++)
			{
				if (tab.Rows[j].RowState != DataRowState.Deleted)
				{
					this.textSummaK.Text = Convert.ToString(Convert.ToInt32(this.textSummaK.Text) + Convert.ToInt32(tab.Rows[j]["Összeg"]));
				}
			}
		}

		private void dataGVK_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				this.aktualisSorK = this.viewKilometer[e.RowIndex].Row;
				DataRow dataRow = this.aktualisSorK;
				this.variabelLoad(this.groupBoxK.Controls, dataRow);
				ComboBox day = this.comboBoxK;
				DateTime dateTime = Convert.ToDateTime(dataRow["datum"].ToString());
				day.SelectedIndex = dateTime.Day - 1;
				this.buttonUjK.Enabled = true;
				if (this.aktualisSorK["Fizetve"].ToString() != "0")
				{
					this.buttonTorolK.Enabled = false;
				}
				else
				{
					this.buttonTorolK.Enabled = true;
				}
				this.errorProvider.SetError(this.kmT, "");
				this.button1K.Enabled = true;
				this.comboBoxK.Enabled = true;
				this.textBox1.Enabled = true;
				this.textBox2.Enabled = true;
				this.kmT.Enabled = true;
				this.textBox3.Enabled = true;
			}
		}

		private void dataGVK_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.dataGVK.Rows[e.RowIndex].Selected = true;
			this.aktualisSorK = this.viewKilometer[e.RowIndex].Row;
		}

		private void dataGVK_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (this.dataGVK.CurrentRow != null)
			{
				this.aktualisSorK = this.viewKilometer[this.dataGVK.CurrentRow.Index].Row;
			}
		}

		private void dataGVT_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				this.aktualisSorT = this.viewTulora[e.RowIndex].Row;
				DataRow dataRow = this.aktualisSorT;
				this.variabelLoad(this.groupBoxT.Controls, dataRow);
				ComboBox day = this.comboBoxT;
				DateTime dateTime = Convert.ToDateTime(dataRow["datum"].ToString());
				day.SelectedIndex = dateTime.Day - 1;
				this.buttonUjT.Enabled = true;
				if (this.aktualisSorT["Fizetve"].ToString() != "0")
				{
					this.buttonTorolT.Enabled = false;
				}
				else
				{
					this.buttonTorolT.Enabled = true;
				}
				this.errorProvider.SetError(this.oraT, "");
				this.button1T.Enabled = true;
				this.comboBoxT.Enabled = true;
				this.textBoxT.Enabled = true;
				this.oraT.Enabled = true;
			}
		}

		private void dataGVT_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.dataGVT.Rows[e.RowIndex].Selected = true;
			this.aktualisSorT = this.viewTulora[e.RowIndex].Row;
		}

		private void dataGVT_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (this.dataGVT.CurrentRow != null)
			{
				this.aktualisSorT = this.viewTulora[this.dataGVT.CurrentRow.Index].Row;
			}
		}

		private void dateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			this.comboBoxT.Items.Clear();
			this.comboBoxK.Items.Clear();
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			this.maxDate = DateTime.DaysInMonth(year, value.Month);
			if (DateTime.Today.Month == this.dateTimePicker.Value.Month && DateTime.Today.Day < this.maxDate)
			{
				this.maxDate = DateTime.Today.Day;
			}
			for (int i = 1; i <= this.maxDate; i++)
			{
				this.comboBoxT.Items.Add(i);
				this.comboBoxK.Items.Add(i);
			}
			this.loadTulora();
			this.loadKilometer();
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
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			this.panel1 = new Panel();
			this.buttonRefresh = new Button();
			this.buttonMentes = new Button();
			this.dateTimePicker = new DateTimePicker();
			this.splitContainer1 = new SplitContainer();
			this.groupBoxT = new GroupBox();
			this.oraT = new MaskedTextBox();
			this.buttonCT = new Button();
			this.textSzorzoT = new Label();
			this.datumT = new Label();
			this.toolStrip = new ToolStrip();
			this.buttonUjT = new ToolStripButton();
			this.buttonTorolT = new ToolStripButton();
			this.button1T = new Button();
			this.textSummaT = new Label();
			this.comboBoxT = new ComboBox();
			this.textOsszegT = new Label();
			this.dataGVT = new DataGridView();
			this.label4 = new Label();
			this.textBoxT = new TextBox();
			this.label3 = new Label();
			this.dayofweekT = new Label();
			this.label1 = new Label();
			this.groupBoxK = new GroupBox();
			this.kmT = new MaskedTextBox();
			this.buttonCK = new Button();
			this.textBox3 = new TextBox();
			this.label8 = new Label();
			this.textBox2 = new TextBox();
			this.textBox1 = new TextBox();
			this.textSzorzoK = new Label();
			this.textOsszegK = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label2 = new Label();
			this.toolStrip1 = new ToolStrip();
			this.buttonUjK = new ToolStripButton();
			this.buttonTorolK = new ToolStripButton();
			this.textSummaK = new Label();
			this.dataGVK = new DataGridView();
			this.idK = new DataGridViewTextBoxColumn();
			this.datumKK = new DataGridViewTextBoxColumn();
			this.honnan = new DataGridViewTextBoxColumn();
			this.hova = new DataGridViewTextBoxColumn();
			this.km = new DataGridViewTextBoxColumn();
			this.osszegK = new DataGridViewTextBoxColumn();
			this.kFizetve = new DataGridViewCheckBoxColumn();
			this.szovegK = new DataGridViewTextBoxColumn();
			this.dolgozo_idK = new DataGridViewTextBoxColumn();
			this.szorzoK = new DataGridViewTextBoxColumn();
			this.datumK = new Label();
			this.button1K = new Button();
			this.comboBoxK = new ComboBox();
			this.dayofweekK = new Label();
			this.label10 = new Label();
			this.errorProvider = new ErrorProvider(this.components);
			this.id = new DataGridViewTextBoxColumn();
			this.Datum = new DataGridViewTextBoxColumn();
			this.szoveg = new DataGridViewTextBoxColumn();
			this.ora = new DataGridViewTextBoxColumn();
			this.osszeg = new DataGridViewTextBoxColumn();
			this.Fizetve = new DataGridViewCheckBoxColumn();
			this.dolgozo_id = new DataGridViewTextBoxColumn();
			this.szorzo = new DataGridViewTextBoxColumn();
			this.comboDolgozo = new ComboBox();
			this.dataSet1 = new TKE.DataSet();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBoxT.SuspendLayout();
			this.toolStrip.SuspendLayout();
			((ISupportInitialize)this.dataGVT).BeginInit();
			this.groupBoxK.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((ISupportInitialize)this.dataGVK).BeginInit();
			((ISupportInitialize)this.errorProvider).BeginInit();
			((ISupportInitialize)this.dataSet1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = SystemColors.ControlDark;
			this.panel1.Controls.Add(this.comboDolgozo);
			this.panel1.Controls.Add(this.buttonRefresh);
			this.panel1.Controls.Add(this.buttonMentes);
			this.panel1.Controls.Add(this.dateTimePicker);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1007, 40);
			this.panel1.TabIndex = 2;
			this.buttonRefresh.Image = Resources.arrow_refresh;
			this.buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
			this.buttonRefresh.Location = new Point(113, 1);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(103, 37);
			this.buttonRefresh.TabIndex = 2;
			this.buttonRefresh.Text = "Elölről";
			this.buttonRefresh.TextAlign = ContentAlignment.MiddleRight;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
			this.buttonMentes.Image = Resources.save_as;
			this.buttonMentes.ImageAlign = ContentAlignment.MiddleLeft;
			this.buttonMentes.Location = new Point(4, 1);
			this.buttonMentes.Name = "buttonMentes";
			this.buttonMentes.Size = new System.Drawing.Size(103, 37);
			this.buttonMentes.TabIndex = 1;
			this.buttonMentes.Text = "Mentés";
			this.buttonMentes.TextAlign = ContentAlignment.MiddleRight;
			this.buttonMentes.UseVisualStyleBackColor = true;
			this.buttonMentes.Click += new EventHandler(this.buttonMentes_Click);
			this.dateTimePicker.CustomFormat = "yyyy.MMMM";
			this.dateTimePicker.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker.Location = new Point(419, 7);
			this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(168, 26);
			this.dateTimePicker.TabIndex = 0;
			this.dateTimePicker.ValueChanged += new EventHandler(this.dateTimePicker_ValueChanged);
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new Point(0, 40);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.groupBoxT);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxK);
			this.splitContainer1.Size = new System.Drawing.Size(1007, 659);
			this.splitContainer1.SplitterDistance = 307;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 3;
			this.groupBoxT.BackColor = Color.Khaki;
			this.groupBoxT.Controls.Add(this.oraT);
			this.groupBoxT.Controls.Add(this.buttonCT);
			this.groupBoxT.Controls.Add(this.textSzorzoT);
			this.groupBoxT.Controls.Add(this.datumT);
			this.groupBoxT.Controls.Add(this.toolStrip);
			this.groupBoxT.Controls.Add(this.button1T);
			this.groupBoxT.Controls.Add(this.textSummaT);
			this.groupBoxT.Controls.Add(this.comboBoxT);
			this.groupBoxT.Controls.Add(this.textOsszegT);
			this.groupBoxT.Controls.Add(this.dataGVT);
			this.groupBoxT.Controls.Add(this.label4);
			this.groupBoxT.Controls.Add(this.textBoxT);
			this.groupBoxT.Controls.Add(this.label3);
			this.groupBoxT.Controls.Add(this.dayofweekT);
			this.groupBoxT.Controls.Add(this.label1);
			this.groupBoxT.Dock = DockStyle.Fill;
			this.groupBoxT.Location = new Point(0, 0);
			this.groupBoxT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBoxT.Name = "groupBoxT";
			this.groupBoxT.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBoxT.Size = new System.Drawing.Size(1007, 307);
			this.groupBoxT.TabIndex = 0;
			this.groupBoxT.TabStop = false;
			this.groupBoxT.Text = "Túlóra elszámolás";
			this.oraT.Location = new Point(143, 104);
			this.oraT.Name = "oraT";
			this.oraT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.oraT.Size = new System.Drawing.Size(67, 26);
			this.oraT.TabIndex = 2;
			this.oraT.Tag = "ora";
			this.oraT.TextChanged += new EventHandler(this.oraT_TextChanged);
			this.buttonCT.Image = Resources.cancel;
			this.buttonCT.ImageAlign = ContentAlignment.MiddleLeft;
			this.buttonCT.Location = new Point(301, 249);
			this.buttonCT.Name = "buttonCT";
			this.buttonCT.Size = new System.Drawing.Size(120, 40);
			this.buttonCT.TabIndex = 4;
			this.buttonCT.Text = "Mégsem";
			this.buttonCT.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCT.UseVisualStyleBackColor = true;
			this.buttonCT.Click += new EventHandler(this.buttonCT_Click);
			this.textSzorzoT.AutoSize = true;
			this.textSzorzoT.Location = new Point(350, 107);
			this.textSzorzoT.Name = "textSzorzoT";
			this.textSzorzoT.Size = new System.Drawing.Size(56, 20);
			this.textSzorzoT.TabIndex = 22;
			this.textSzorzoT.Tag = "szorzo";
			this.textSzorzoT.Text = "szorzo";
			this.textSzorzoT.Visible = false;
			this.datumT.AutoSize = true;
			this.datumT.Location = new Point(350, 38);
			this.datumT.Name = "datumT";
			this.datumT.Size = new System.Drawing.Size(54, 20);
			this.datumT.TabIndex = 21;
			this.datumT.Tag = "datum";
			this.datumT.Text = "datum";
			this.datumT.Visible = false;
			this.toolStrip.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.toolStrip.Dock = DockStyle.None;
			this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripItemCollection items = this.toolStrip.Items;
			ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.buttonUjT, this.buttonTorolT };
			items.AddRange(toolStripItemArray);
			this.toolStrip.Location = new Point(474, 13);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(142, 25);
			this.toolStrip.TabIndex = 20;
			this.buttonUjT.Image = Resources.star;
			this.buttonUjT.ImageTransparentColor = Color.Black;
			this.buttonUjT.Name = "buttonUjT";
			this.buttonUjT.Size = new System.Drawing.Size(81, 22);
			this.buttonUjT.Text = "Új felvítel";
			this.buttonUjT.ToolTipText = "Új elem felvétele";
			this.buttonUjT.Click += new EventHandler(this.buttonUjT_Click);
			this.buttonTorolT.Image = Resources.cancel;
			this.buttonTorolT.ImageTransparentColor = Color.Black;
			this.buttonTorolT.Name = "buttonTorolT";
			this.buttonTorolT.Size = new System.Drawing.Size(58, 22);
			this.buttonTorolT.Text = "Töröl";
			this.buttonTorolT.Click += new EventHandler(this.buttonTorolT_Click);
			this.button1T.Image = Resources.accept;
			this.button1T.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1T.Location = new Point(143, 249);
			this.button1T.Name = "button1T";
			this.button1T.Size = new System.Drawing.Size(120, 40);
			this.button1T.TabIndex = 3;
			this.button1T.Text = "Rendben";
			this.button1T.TextAlign = ContentAlignment.MiddleRight;
			this.button1T.UseVisualStyleBackColor = true;
			this.button1T.Click += new EventHandler(this.button1T_Click);
			this.textSummaT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textSummaT.AutoSize = true;
			this.textSummaT.Location = new Point(946, 245);
			this.textSummaT.Name = "textSummaT";
			this.textSummaT.Size = new System.Drawing.Size(51, 20);
			this.textSummaT.TabIndex = 10;
			this.textSummaT.Text = "label2";
			this.textSummaT.TextAlign = ContentAlignment.MiddleRight;
			this.comboBoxT.FormatString = "N0";
			this.comboBoxT.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.comboBoxT.Items;
			object[] objArray = new object[] { "1", "2", "3", "4" };
			objectCollections.AddRange(objArray);
			this.comboBoxT.Location = new Point(143, 33);
			this.comboBoxT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.comboBoxT.Name = "comboBoxT";
			this.comboBoxT.Size = new System.Drawing.Size(67, 28);
			this.comboBoxT.TabIndex = 0;
			this.comboBoxT.Text = "1";
			this.comboBoxT.SelectedIndexChanged += new EventHandler(this.comboBoxT_SelectedValueChanged);
			this.comboBoxT.TextUpdate += new EventHandler(this.comboBoxT_TextUpdate);
			this.textOsszegT.AutoSize = true;
			this.textOsszegT.Location = new Point(248, 107);
			this.textOsszegT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.textOsszegT.Name = "textOsszegT";
			this.textOsszegT.Size = new System.Drawing.Size(0, 20);
			this.textOsszegT.TabIndex = 8;
			this.textOsszegT.Tag = "Összeg";
			this.dataGVT.AllowUserToAddRows = false;
			this.dataGVT.AllowUserToDeleteRows = false;
			this.dataGVT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.dataGVT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGVT.BackgroundColor = SystemColors.ControlLightLight;
			this.dataGVT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dataGVT.Columns;
			DataGridViewColumn[] datum = new DataGridViewColumn[] { this.id, this.Datum, this.szoveg, this.ora, this.osszeg, this.Fizetve, this.dolgozo_id, this.szorzo };
			columns.AddRange(datum);
			this.dataGVT.Location = new Point(474, 38);
			this.dataGVT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dataGVT.MultiSelect = false;
			this.dataGVT.Name = "dataGVT";
			this.dataGVT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGVT.Size = new System.Drawing.Size(525, 202);
			this.dataGVT.TabIndex = 7;
			this.dataGVT.CellClick += new DataGridViewCellEventHandler(this.dataGVT_CellClick);
			this.dataGVT.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGVT_RowsAdded);
			this.dataGVT.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGVT_RowsRemoved);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(62, 107);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "óra:";
			this.textBoxT.Location = new Point(143, 71);
			this.textBoxT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxT.Name = "textBoxT";
			this.textBoxT.Size = new System.Drawing.Size(323, 26);
			this.textBoxT.TabIndex = 1;
			this.textBoxT.Tag = "szoveg";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(37, 76);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Munka:";
			this.dayofweekT.AutoSize = true;
			this.dayofweekT.Location = new Point(248, 38);
			this.dayofweekT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.dayofweekT.Name = "dayofweekT";
			this.dayofweekT.Size = new System.Drawing.Size(74, 20);
			this.dayofweekT.TabIndex = 2;
			this.dayofweekT.Text = "vasárnap";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(37, 38);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nap:";
			this.groupBoxK.BackColor = Color.PaleGoldenrod;
			this.groupBoxK.Controls.Add(this.kmT);
			this.groupBoxK.Controls.Add(this.buttonCK);
			this.groupBoxK.Controls.Add(this.textBox3);
			this.groupBoxK.Controls.Add(this.label8);
			this.groupBoxK.Controls.Add(this.textBox2);
			this.groupBoxK.Controls.Add(this.textBox1);
			this.groupBoxK.Controls.Add(this.textSzorzoK);
			this.groupBoxK.Controls.Add(this.textOsszegK);
			this.groupBoxK.Controls.Add(this.label7);
			this.groupBoxK.Controls.Add(this.label6);
			this.groupBoxK.Controls.Add(this.label2);
			this.groupBoxK.Controls.Add(this.toolStrip1);
			this.groupBoxK.Controls.Add(this.textSummaK);
			this.groupBoxK.Controls.Add(this.dataGVK);
			this.groupBoxK.Controls.Add(this.datumK);
			this.groupBoxK.Controls.Add(this.button1K);
			this.groupBoxK.Controls.Add(this.comboBoxK);
			this.groupBoxK.Controls.Add(this.dayofweekK);
			this.groupBoxK.Controls.Add(this.label10);
			this.groupBoxK.Dock = DockStyle.Fill;
			this.groupBoxK.Location = new Point(0, 0);
			this.groupBoxK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBoxK.Name = "groupBoxK";
			this.groupBoxK.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBoxK.Size = new System.Drawing.Size(1007, 346);
			this.groupBoxK.TabIndex = 1;
			this.groupBoxK.TabStop = false;
			this.groupBoxK.Text = "Kilométer elszámolás";
			this.kmT.Location = new Point(143, 150);
			this.kmT.Name = "kmT";
			this.kmT.Size = new System.Drawing.Size(67, 26);
			this.kmT.TabIndex = 3;
			this.kmT.Tag = "km";
			this.kmT.TextChanged += new EventHandler(this.kmT_TextChanged);
			this.buttonCK.Image = Resources.cancel;
			this.buttonCK.ImageAlign = ContentAlignment.MiddleLeft;
			this.buttonCK.Location = new Point(301, 287);
			this.buttonCK.Name = "buttonCK";
			this.buttonCK.Size = new System.Drawing.Size(120, 40);
			this.buttonCK.TabIndex = 6;
			this.buttonCK.Text = "Mégsem";
			this.buttonCK.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCK.UseVisualStyleBackColor = true;
			this.buttonCK.Click += new EventHandler(this.buttonCK_Click);
			this.textBox3.Location = new Point(143, 186);
			this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(323, 26);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "szoveg";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(37, 189);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(97, 20);
			this.label8.TabIndex = 45;
			this.label8.Text = "Megjegyzés:";
			this.textBox2.Location = new Point(143, 114);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(323, 26);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "hova";
			this.textBox1.Location = new Point(143, 78);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(323, 26);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "honnan";
			this.textSzorzoK.AutoSize = true;
			this.textSzorzoK.Location = new Point(350, 150);
			this.textSzorzoK.Name = "textSzorzoK";
			this.textSzorzoK.Size = new System.Drawing.Size(56, 20);
			this.textSzorzoK.TabIndex = 42;
			this.textSzorzoK.Tag = "szorzo";
			this.textSzorzoK.Text = "szorzo";
			this.textSzorzoK.Visible = false;
			this.textOsszegK.AutoSize = true;
			this.textOsszegK.Location = new Point(248, 150);
			this.textOsszegK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.textOsszegK.Name = "textOsszegK";
			this.textOsszegK.Size = new System.Drawing.Size(0, 20);
			this.textOsszegK.TabIndex = 41;
			this.textOsszegK.Tag = "Összeg";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(73, 153);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 20);
			this.label7.TabIndex = 39;
			this.label7.Text = "km:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(37, 117);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 20);
			this.label6.TabIndex = 38;
			this.label6.Text = "Hova:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(37, 81);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 37;
			this.label2.Text = "Honnan:";
			this.toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.toolStrip1.Dock = DockStyle.None;
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripItemCollection toolStripItemCollections = this.toolStrip1.Items;
			ToolStripItem[] toolStripItemArray1 = new ToolStripItem[] { this.buttonUjK, this.buttonTorolK };
			toolStripItemCollections.AddRange(toolStripItemArray1);
			this.toolStrip1.Location = new Point(474, 13);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(142, 25);
			this.toolStrip1.TabIndex = 36;
			this.buttonUjK.Image = Resources.star;
			this.buttonUjK.ImageTransparentColor = Color.Black;
			this.buttonUjK.Name = "buttonUjK";
			this.buttonUjK.Size = new System.Drawing.Size(81, 22);
			this.buttonUjK.Text = "Új felvítel";
			this.buttonUjK.ToolTipText = "Új elem felvétele";
			this.buttonUjK.Click += new EventHandler(this.buttonUjK_Click);
			this.buttonTorolK.Image = Resources.cancel;
			this.buttonTorolK.ImageTransparentColor = Color.Black;
			this.buttonTorolK.Name = "buttonTorolK";
			this.buttonTorolK.Size = new System.Drawing.Size(58, 22);
			this.buttonTorolK.Text = "Töröl";
			this.buttonTorolK.Click += new EventHandler(this.buttonTorolK_Click);
			this.textSummaK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textSummaK.AutoSize = true;
			this.textSummaK.Location = new Point(946, 282);
			this.textSummaK.Name = "textSummaK";
			this.textSummaK.Size = new System.Drawing.Size(51, 20);
			this.textSummaK.TabIndex = 35;
			this.textSummaK.Text = "label3";
			this.textSummaK.TextAlign = ContentAlignment.MiddleRight;
			this.dataGVK.AllowUserToAddRows = false;
			this.dataGVK.AllowUserToDeleteRows = false;
			this.dataGVK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.dataGVK.BackgroundColor = SystemColors.ControlLightLight;
			this.dataGVK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection dataGridViewColumnCollections = this.dataGVK.Columns;
			DataGridViewColumn[] dolgozoIdK = new DataGridViewColumn[] { this.idK, this.datumKK, this.honnan, this.hova, this.km, this.osszegK, this.kFizetve, this.szovegK, this.dolgozo_idK, this.szorzoK };
			dataGridViewColumnCollections.AddRange(dolgozoIdK);
			this.dataGVK.Location = new Point(472, 40);
			this.dataGVK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dataGVK.MultiSelect = false;
			this.dataGVK.Name = "dataGVK";
			this.dataGVK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGVK.Size = new System.Drawing.Size(525, 237);
			this.dataGVK.TabIndex = 34;
			this.dataGVK.CellClick += new DataGridViewCellEventHandler(this.dataGVK_CellClick);
			this.dataGVK.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGVK_RowsAdded);
			this.dataGVK.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGVK_RowsRemoved);
			this.idK.DataPropertyName = "id";
			this.idK.HeaderText = "id";
			this.idK.Name = "idK";
			this.idK.Visible = false;
			this.idK.Width = 46;
			this.datumKK.DataPropertyName = "datum";
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.Format = "M";
			dataGridViewCellStyle.NullValue = null;
			this.datumKK.DefaultCellStyle = dataGridViewCellStyle;
			this.datumKK.HeaderText = "Dátum";
			this.datumKK.Name = "datumKK";
			this.datumKK.ReadOnly = true;
			this.datumKK.Width = 82;
			this.honnan.DataPropertyName = "honnan";
			this.honnan.HeaderText = "Honnan";
			this.honnan.Name = "honnan";
			this.honnan.ReadOnly = true;
			this.honnan.Width = 91;
			this.hova.DataPropertyName = "hova";
			this.hova.HeaderText = "Hova";
			this.hova.Name = "hova";
			this.hova.ReadOnly = true;
			this.hova.Width = 71;
			this.km.DataPropertyName = "km";
			this.km.HeaderText = "km";
			this.km.Name = "km";
			this.km.ReadOnly = true;
			this.km.Width = 55;
			this.osszegK.DataPropertyName = "Összeg";
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = null;
			this.osszegK.DefaultCellStyle = dataGridViewCellStyle1;
			this.osszegK.HeaderText = "Összeg";
			this.osszegK.Name = "osszegK";
			this.osszegK.ReadOnly = true;
			this.osszegK.Width = 88;
			this.kFizetve.DataPropertyName = "fizetve";
			this.kFizetve.FalseValue = "0";
			this.kFizetve.HeaderText = "Fizetve";
			this.kFizetve.Name = "kFizetve";
			this.kFizetve.Resizable = DataGridViewTriState.True;
			this.kFizetve.SortMode = DataGridViewColumnSortMode.Automatic;
			this.kFizetve.TrueValue = "1";
			this.kFizetve.Width = 85;
			this.szovegK.DataPropertyName = "szoveg";
			this.szovegK.HeaderText = "Megjegyzés";
			this.szovegK.Name = "szovegK";
			this.szovegK.ReadOnly = true;
			this.szovegK.Visible = false;
			this.szovegK.Width = 118;
			this.dolgozo_idK.DataPropertyName = "dolgozo_id";
			this.dolgozo_idK.HeaderText = "dolgozo_id";
			this.dolgozo_idK.Name = "dolgozo_idK";
			this.dolgozo_idK.Visible = false;
			this.dolgozo_idK.Width = 111;
			this.szorzoK.DataPropertyName = "szorzo";
			this.szorzoK.HeaderText = "szorzo";
			this.szorzoK.Name = "szorzoK";
			this.szorzoK.Visible = false;
			this.szorzoK.Width = 81;
			this.datumK.AutoSize = true;
			this.datumK.Location = new Point(350, 45);
			this.datumK.Name = "datumK";
			this.datumK.Size = new System.Drawing.Size(54, 20);
			this.datumK.TabIndex = 32;
			this.datumK.Tag = "datum";
			this.datumK.Text = "datum";
			this.datumK.Visible = false;
			this.button1K.Image = Resources.accept;
			this.button1K.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1K.Location = new Point(143, 287);
			this.button1K.Name = "button1K";
			this.button1K.Size = new System.Drawing.Size(120, 40);
			this.button1K.TabIndex = 5;
			this.button1K.Text = "Rendben";
			this.button1K.TextAlign = ContentAlignment.MiddleRight;
			this.button1K.UseVisualStyleBackColor = true;
			this.button1K.Click += new EventHandler(this.button1K_Click);
			this.comboBoxK.FormatString = "N0";
			this.comboBoxK.FormattingEnabled = true;
			ComboBox.ObjectCollection items1 = this.comboBoxK.Items;
			object[] objArray1 = new object[] { "1", "2", "3", "4" };
			items1.AddRange(objArray1);
			this.comboBoxK.Location = new Point(143, 40);
			this.comboBoxK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.comboBoxK.Name = "comboBoxK";
			this.comboBoxK.Size = new System.Drawing.Size(67, 28);
			this.comboBoxK.TabIndex = 0;
			this.comboBoxK.Text = "1";
			this.comboBoxK.SelectedIndexChanged += new EventHandler(this.comboBoxK_SelectedValueChanged);
			this.comboBoxK.TextUpdate += new EventHandler(this.comboBoxK_TextUpdate);
			this.dayofweekK.AutoSize = true;
			this.dayofweekK.Location = new Point(248, 45);
			this.dayofweekK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.dayofweekK.Name = "dayofweekK";
			this.dayofweekK.Size = new System.Drawing.Size(74, 20);
			this.dayofweekK.TabIndex = 27;
			this.dayofweekK.Text = "vasárnap";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(37, 45);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(42, 20);
			this.label10.TabIndex = 25;
			this.label10.Text = "Nap:";
			this.errorProvider.ContainerControl = this;
			this.id.DataPropertyName = "id";
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			this.id.Width = 46;
			this.Datum.DataPropertyName = "datum";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Format = "M";
			dataGridViewCellStyle2.NullValue = null;
			this.Datum.DefaultCellStyle = dataGridViewCellStyle2;
			this.Datum.HeaderText = "Dátum";
			this.Datum.Name = "Datum";
			this.Datum.ReadOnly = true;
			this.Datum.Width = 82;
			this.szoveg.DataPropertyName = "szoveg";
			this.szoveg.HeaderText = "Szöveg";
			this.szoveg.Name = "szoveg";
			this.szoveg.ReadOnly = true;
			this.szoveg.Width = 87;
			this.ora.DataPropertyName = "ora";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N2";
			dataGridViewCellStyle3.NullValue = null;
			this.ora.DefaultCellStyle = dataGridViewCellStyle3;
			this.ora.HeaderText = "óra";
			this.ora.Name = "ora";
			this.ora.ReadOnly = true;
			this.ora.Width = 57;
			this.osszeg.DataPropertyName = "Összeg";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N0";
			dataGridViewCellStyle4.NullValue = null;
			this.osszeg.DefaultCellStyle = dataGridViewCellStyle4;
			this.osszeg.HeaderText = "Összeg";
			this.osszeg.Name = "osszeg";
			this.osszeg.ReadOnly = true;
			this.osszeg.Width = 88;
			this.Fizetve.DataPropertyName = "fizetve";
			this.Fizetve.FalseValue = "0";
			this.Fizetve.HeaderText = "Fizetve";
			this.Fizetve.Name = "Fizetve";
			this.Fizetve.Resizable = DataGridViewTriState.True;
			this.Fizetve.SortMode = DataGridViewColumnSortMode.Automatic;
			this.Fizetve.TrueValue = "1";
			this.Fizetve.Width = 85;
			this.dolgozo_id.DataPropertyName = "dolgozo_id";
			this.dolgozo_id.HeaderText = "dolgozo_id";
			this.dolgozo_id.Name = "dolgozo_id";
			this.dolgozo_id.Visible = false;
			this.dolgozo_id.Width = 111;
			this.szorzo.DataPropertyName = "szorzo";
			this.szorzo.HeaderText = "szorzo";
			this.szorzo.Name = "szorzo";
			this.szorzo.Visible = false;
			this.szorzo.Width = 81;
			this.comboDolgozo.FormattingEnabled = true;
			this.comboDolgozo.Location = new Point(763, 6);
			this.comboDolgozo.Name = "comboDolgozo";
			this.comboDolgozo.Size = new System.Drawing.Size(236, 28);
			this.comboDolgozo.TabIndex = 3;
			this.comboDolgozo.SelectedIndexChanged += new EventHandler(this.comboDolgozo_SelectedIndexChanged);
			this.dataSet1.DataSetName = "DataSet";
			this.dataSet1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			base.AutoScaleDimensions = new SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "tke";
			base.Size = new System.Drawing.Size(1007, 699);
			base.Load += new EventHandler(this.tke_Load);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBoxT.ResumeLayout(false);
			this.groupBoxT.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			((ISupportInitialize)this.dataGVT).EndInit();
			this.groupBoxK.ResumeLayout(false);
			this.groupBoxK.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((ISupportInitialize)this.dataGVK).EndInit();
			((ISupportInitialize)this.errorProvider).EndInit();
			((ISupportInitialize)this.dataSet1).EndInit();
			base.ResumeLayout(false);
		}

		private bool isNumeric(string st)
		{
			bool flag = true;
			try
			{
				Convert.ToInt32(st);
			}
			catch
			{
				try
				{
					Convert.ToDecimal(st);
				}
				catch
				{
					flag = false;
				}
			}
			return flag;
		}

		private void kmT_TextChanged(object sender, EventArgs e)
		{
			this.kmT.Text = this.kmT.Text.Replace('.', ',');
			if (this.kmT.Text.Trim() != string.Empty && this.isNumeric(this.kmT.Text))
			{
				if (this.userKM_SZORZO <= 0)
				{
					this.textSzorzoK.Text = this.MainForm.parameterErtek("KM_SZORZO").ToString();
				}
				else
				{
					this.textSzorzoK.Text = this.userKM_SZORZO.ToString();
				}
				Label str = this.textOsszegK;
				decimal num = Convert.ToDecimal(this.kmT.Text) * Convert.ToInt32(this.textSzorzoK.Text);
				str.Text = num.ToString();
			}
		}

		private void kmT_Validating(object sender, CancelEventArgs e)
		{
			this.mezoValidalas("kmT");
		}

		private void loadKilometer()
		{
			this.dataGVK.RowsRemoved -= new DataGridViewRowsRemovedEventHandler(this.dataGVK_RowsRemoved);
			this.tableKilometer.Clear();
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, 1);
			int num = this.dateTimePicker.Value.Year;
			int month = this.dateTimePicker.Value.Month;
			int year1 = this.dateTimePicker.Value.Year;
			DateTime value1 = this.dateTimePicker.Value;
			DateTime dateTime1 = new DateTime(num, month, DateTime.DaysInMonth(year1, value1.Month));
			string[] strArrays = new string[] { "select *, km*szorzo as Összeg from kilometer where dolgozo_id = '", this.tmpUserId.ToString().Trim(), "' and datum between '", dateTime.ToShortDateString(), "' and '", dateTime1.ToShortDateString(), "' " };
			this.daKilometer = new SqlDataAdapter(string.Concat(strArrays), this.myconn);
			this.daKilometer.Fill(this.dataSet, "tableKilometer");
			this.tableKilometer = this.dataSet.Tables["tableKilometer"];
			this.viewKilometer.BeginInit();
			this.viewKilometer.Table = this.tableKilometer;
			this.viewKilometer.EndInit();
			this.viewKilometer.Sort = "datum";
			this.dataGVK.DataSource = this.viewKilometer;
			this.cbKilometer = new SqlCommandBuilder(this.daKilometer);
			this.countSumma(this.tableKilometer);
			this.dataGVK.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGVK_RowsRemoved);
		}

		private void loadTulora()
		{
			this.dataGVT.RowsRemoved -= new DataGridViewRowsRemovedEventHandler(this.dataGVT_RowsRemoved);
			this.tableTulora.Clear();
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, 1);
			int num = this.dateTimePicker.Value.Year;
			int month = this.dateTimePicker.Value.Month;
			int year1 = this.dateTimePicker.Value.Year;
			DateTime value1 = this.dateTimePicker.Value;
			DateTime dateTime1 = new DateTime(num, month, DateTime.DaysInMonth(year1, value1.Month));
			string[] strArrays = new string[] { "select *, ora*szorzo as Összeg from tulora where dolgozo_id = '", this.tmpUserId.ToString().Trim(), "' and datum between '", dateTime.ToShortDateString(), "' and '", dateTime1.ToShortDateString(), "' " };
			this.daTulora = new SqlDataAdapter(string.Concat(strArrays), this.myconn);
			this.daTulora.Fill(this.dataSet, "tableTulora");
			this.tableTulora = this.dataSet.Tables["tableTulora"];
			this.viewTulora.BeginInit();
			this.viewTulora.Table = this.tableTulora;
			this.viewTulora.EndInit();
			this.viewTulora.Sort = "Datum";
			this.dataGVT.DataSource = this.viewTulora;
			this.cbTulora = new SqlCommandBuilder(this.daTulora);
			this.countSumma(this.tableTulora);
			this.dataGVT.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGVT_RowsRemoved);
		}

		private bool mezoValidalas(string mezo)
		{
			bool flag = false;
			if (mezo == "comboBoxT")
			{
				if (this.comboBoxT.Text == string.Empty || !this.isNumeric(this.comboBoxT.Text))
				{
					this.comboBoxT.Focus();
					this.errorProvider.SetError(this.comboBoxT, "Hibás dátum.");
					flag = false;
				}
				else if (Convert.ToInt32(this.comboBoxT.Text) < 1 || Convert.ToInt32(this.comboBoxT.Text) > this.maxDate)
				{
					this.comboBoxT.Focus();
					this.errorProvider.SetError(this.comboBoxT, "Hibás dátum.");
					flag = false;
				}
				else
				{
					this.errorProvider.SetError(this.comboBoxT, "");
					flag = true;
				}
			}
			if (mezo == "oraT")
			{
				if (this.oraT.Text == string.Empty)
				{
					this.oraT.Focus();
					this.errorProvider.SetError(this.oraT, "Az óraszámot legyen szíves megadni.");
					flag = false;
				}
				else if (Convert.ToDecimal(this.oraT.Text) < new decimal(-24) || Convert.ToDecimal(this.oraT.Text) > new decimal(24))
				{
					this.oraT.Focus();
					this.errorProvider.SetError(this.oraT, "A óra csak -24 és 24 között lehet.");
					flag = false;
				}
				else
				{
					this.errorProvider.SetError(this.oraT, "");
					flag = true;
				}
			}
			if (mezo == "comboBoxK")
			{
				if (this.comboBoxK.Text == string.Empty || !this.isNumeric(this.comboBoxK.Text))
				{
					this.comboBoxK.Focus();
					this.errorProvider.SetError(this.comboBoxK, "Hibás dátum.");
					flag = false;
				}
				else if (Convert.ToInt32(this.comboBoxK.Text) < 1 || Convert.ToInt32(this.comboBoxK.Text) > this.maxDate)
				{
					this.comboBoxK.Focus();
					this.errorProvider.SetError(this.comboBoxK, "Hibás dátum.");
					flag = false;
				}
				else
				{
					this.errorProvider.SetError(this.comboBoxK, "");
					flag = true;
				}
			}
			if (mezo == "kmT")
			{
				if (this.kmT.Text == string.Empty)
				{
					this.kmT.Focus();
					this.errorProvider.SetError(this.kmT, "Az kilométert legyen szíves megadni.");
					flag = false;
				}
				else if (Convert.ToDecimal(this.kmT.Text) < new decimal(-1000) || Convert.ToDecimal(this.kmT.Text) > new decimal(1000))
				{
					this.kmT.Focus();
					this.errorProvider.SetError(this.kmT, "A kilométer csak -1000 és 1000 között lehet.");
					flag = false;
				}
				else
				{
					this.errorProvider.SetError(this.kmT, "");
					flag = true;
				}
			}
			return flag;
		}

		private void oraT_TextChanged(object sender, EventArgs e)
		{
			this.oraT.Text = this.oraT.Text.Replace('.', ',');
			if (this.oraT.Text != string.Empty && this.isNumeric(this.oraT.Text))
			{
				this.osszegSzamolas();
			}
		}

		private void oraT_Validating(object sender, CancelEventArgs e)
		{
			this.mezoValidalas("oraT");
		}

		private void osszegSzamolas()
		{
			if (this.dayofweekT.Text != "hétfő" && this.dayofweekT.Text != "kedd" && this.dayofweekT.Text != "szerda" && this.dayofweekT.Text != "csütörtök" && this.dayofweekT.Text != "péntek")
			{
				if (this.userORA_SZORZO_HV <= 0)
				{
					this.textSzorzoT.Text = this.MainForm.parameterErtek("ORA_SZORZO_HV").ToString();
				}
				else
				{
					this.textSzorzoT.Text = this.userORA_SZORZO_HV.ToString();
				}
			}
			else if (this.userORA_SZORZO_HK <= 0)
			{
				this.textSzorzoT.Text = this.MainForm.parameterErtek("ORA_SZORZO_HK").ToString();
			}
			else
			{
				this.textSzorzoT.Text = this.userORA_SZORZO_HK.ToString();
			}
			if (this.oraT.Text.Trim() != string.Empty)
			{
				Label str = this.textOsszegT;
				decimal num = Convert.ToDecimal(this.oraT.Text) * Convert.ToInt32(this.textSzorzoT.Text);
				str.Text = num.ToString();
			}
		}

		private void rendbenK()
		{
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, Convert.ToInt32(this.comboBoxK.Text));
			this.datumK.Text = dateTime.ToShortDateString();
			if (this.mezoValidalas("kmT"))
			{
				if (this.buttonUjK.Enabled || this.buttonTorolK.Enabled)
				{
					DataRow dataRow = this.aktualisSorK;
					this.variabelSave(this.groupBoxK.Controls, dataRow);
				}
				else
				{
					DataRow dataRow1 = this.tableKilometer.NewRow();
					dataRow1["dolgozo_id"] = this.tmpUserId;
					this.variabelSave(this.groupBoxK.Controls, dataRow1);
					this.tableKilometer.Rows.Add(dataRow1);
					this.dataGVK.CurrentCell = this.dataGVK.Rows[this.dataGVK.Rows.Count - 1].Cells["Datumkk"];
					this.variabelClear(this.groupBoxK.Controls);
				}
				this.buttonUjK.Enabled = true;
				this.buttonTorolK.Enabled = true;
			}
		}

		private void rendbenT()
		{
			int year = this.dateTimePicker.Value.Year;
			DateTime value = this.dateTimePicker.Value;
			DateTime dateTime = new DateTime(year, value.Month, Convert.ToInt32(this.comboBoxT.Text));
			this.datumT.Text = dateTime.ToShortDateString();
			if (this.mezoValidalas("oraT"))
			{
				if (this.buttonUjT.Enabled || this.buttonTorolT.Enabled)
				{
					DataRow dataRow = this.aktualisSorT;
					this.variabelSave(this.groupBoxT.Controls, dataRow);
				}
				else
				{
					DataRow dataRow1 = this.tableTulora.NewRow();
					dataRow1["dolgozo_id"] = this.tmpUserId;
					this.variabelSave(this.groupBoxT.Controls, dataRow1);
					this.tableTulora.Rows.Add(dataRow1);
					this.dataGVT.CurrentCell = this.dataGVT.Rows[this.dataGVT.Rows.Count - 1].Cells["Datum"];
					this.variabelClear(this.groupBoxT.Controls);
				}
				this.buttonUjT.Enabled = true;
				this.buttonTorolT.Enabled = true;
			}
		}

		private void tke_Load(object sender, EventArgs e)
		{
			this.dateTimePicker_ValueChanged(sender, e);
		}

		private void variabelClear(Control.ControlCollection con)
		{
			this.errorProvider.SetError(this.oraT, "");
			this.errorProvider.SetError(this.kmT, "");
			for (int i = 0; i < con.Count; i++)
			{
				if (con[i].GetType().Name == "GroupBox")
				{
					this.variabelClear(con[i].Controls);
				}
				if (con[i].GetType().Name == "CheckBox" && con[i].Tag != null)
				{
					((CheckBox)con[i]).Checked = false;
				}
				if (con[i].Tag != null)
				{
					con[i].Text = string.Empty;
				}
			}
			if (con.Owner.Name == "groupBoxT")
			{
				this.button1T.Enabled = false;
				this.comboBoxT.Enabled = false;
				this.textBoxT.Enabled = false;
				this.oraT.Enabled = false;
				return;
			}
			this.button1K.Enabled = false;
			this.comboBoxK.Enabled = false;
			this.textBox1.Enabled = false;
			this.textBox2.Enabled = false;
			this.kmT.Enabled = false;
			this.textBox3.Enabled = false;
		}

		private void variabelLoad(Control.ControlCollection con, DataRow row)
		{
			for (int i = 0; i < con.Count; i++)
			{
				if (con[i].GetType().Name == "GroupBox")
				{
					this.variabelLoad(con[i].Controls, row);
				}
				if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
				{
					((CheckBox)con[i]).Checked = Convert.ToBoolean(Convert.ToInt32(row[(string)con[i].Tag].ToString()));
				}
				if (con[i].Tag != null)
				{
					con[i].Text = row[(string)con[i].Tag].ToString();
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
				if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
				{
					row[(string)con[i].Tag] = Convert.ToInt32(((CheckBox)con[i]).Checked);
				}
				if (con[i].Tag != null)
				{
					row[(string)con[i].Tag] = con[i].Text;
				}
			}
		}
	}
}