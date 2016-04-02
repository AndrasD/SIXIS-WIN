using CrystalDecisions.CrystalReports.Engine;
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
	public class parameter : UserControl
	{
		private SqlConnection myconn = new SqlConnection();

		private TKE.DataSet dataSet = new TKE.DataSet();

		private DataTable tableParameter = new DataTable();

		private DataView viewParameter = new DataView();

		private SqlDataAdapter da;

		private SqlCommandBuilder cb;

		private int user_ID;

		private mainForm MainForm;

		private ReportDocument rpt1 = new report1();

		private TKE.DataSet ds = new TKE.DataSet();

		private IContainer components;

		private ToolStrip toolStrip;

		private ToolStripButton buttonVissza;

		private Panel panel2;

		private DataGridView dataGV;

		private ToolStripButton buttonMentes;

		private DataGridViewTextBoxColumn ParamNev;

		private DataGridViewTextBoxColumn param_ertek;

		private DataGridViewTextBoxColumn id;

		public parameter(mainForm _mainForm)
		{
			this.user_ID = _mainForm.UserId;
			this.myconn = _mainForm.MyConn;
			this.MainForm = _mainForm;
			this.InitializeComponent();
		}

		private void buttonMentes_Click(object sender, EventArgs e)
		{
			try
			{
				this.da.Update(this.tableParameter);
				this.tableParameter.AcceptChanges();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Hiba az adatbázis aktualizálásánál\r\n", exception.Message));
			}
		}

		private void buttonVissza_Click(object sender, EventArgs e)
		{
			base.Visible = false;
			this.MainForm.panelBeallit(0);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(parameter));
			this.toolStrip = new ToolStrip();
			this.buttonVissza = new ToolStripButton();
			this.panel2 = new Panel();
			this.dataGV = new DataGridView();
			this.buttonMentes = new ToolStripButton();
			this.ParamNev = new DataGridViewTextBoxColumn();
			this.param_ertek = new DataGridViewTextBoxColumn();
			this.id = new DataGridViewTextBoxColumn();
			this.toolStrip.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.dataGV).BeginInit();
			base.SuspendLayout();
			this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripItemCollection items = this.toolStrip.Items;
			ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.buttonVissza, this.buttonMentes };
			items.AddRange(toolStripItemArray);
			this.toolStrip.Location = new Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(1055, 25);
			this.toolStrip.TabIndex = 4;
			this.buttonVissza.Image = Resources.left;
			this.buttonVissza.ImageTransparentColor = Color.Black;
			this.buttonVissza.Name = "buttonVissza";
			this.buttonVissza.Size = new System.Drawing.Size(64, 22);
			this.buttonVissza.Text = "Vissza";
			this.buttonVissza.Click += new EventHandler(this.buttonVissza_Click);
			this.panel2.Controls.Add(this.dataGV);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1055, 552);
			this.panel2.TabIndex = 6;
			this.dataGV.AllowUserToAddRows = false;
			this.dataGV.AllowUserToDeleteRows = false;
			this.dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dataGV.Columns;
			DataGridViewColumn[] paramNev = new DataGridViewColumn[] { this.ParamNev, this.param_ertek, this.id };
			columns.AddRange(paramNev);
			this.dataGV.Dock = DockStyle.Fill;
			this.dataGV.Location = new Point(0, 0);
			this.dataGV.Name = "dataGV";
			this.dataGV.Size = new System.Drawing.Size(1055, 552);
			this.dataGV.TabIndex = 0;
			this.buttonMentes.Image = (Image)componentResourceManager.GetObject("buttonMentes.Image");
			this.buttonMentes.ImageTransparentColor = Color.Magenta;
			this.buttonMentes.Name = "buttonMentes";
			this.buttonMentes.Size = new System.Drawing.Size(69, 22);
			this.buttonMentes.Text = "Mentés";
			this.buttonMentes.Click += new EventHandler(this.buttonMentes_Click);
			this.ParamNev.DataPropertyName = "NEV";
			this.ParamNev.HeaderText = "Paraméter neve";
			this.ParamNev.Name = "ParamNev";
			this.ParamNev.Width = 133;
			this.param_ertek.DataPropertyName = "ERTEK";
			this.param_ertek.HeaderText = "értéke";
			this.param_ertek.Name = "param_ertek";
			this.param_ertek.Width = 79;
			this.id.DataPropertyName = "ID";
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			this.id.Width = 46;
			base.AutoScaleDimensions = new SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.toolStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "parameter";
			base.Size = new System.Drawing.Size(1055, 577);
			base.Load += new EventHandler(this.parameter_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panel2.ResumeLayout(false);
			((ISupportInitialize)this.dataGV).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void parameter_Load(object sender, EventArgs e)
		{
			this.da = new SqlDataAdapter("SELECT * FROM parameter ", this.myconn);
			this.da.Fill(this.dataSet, "tableParameter");
			this.tableParameter = this.dataSet.Tables["tableParameter"];
			DataTable dataTable = this.tableParameter;
			DataColumn[] item = new DataColumn[] { this.tableParameter.Columns["azonosito"] };
			dataTable.PrimaryKey = item;
			this.viewParameter.BeginInit();
			this.viewParameter.Table = this.tableParameter;
			this.viewParameter.EndInit();
			this.dataGV.DataSource = this.viewParameter;
			this.cb = new SqlCommandBuilder(this.da);
		}
	}
}