using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TKE.Properties;

namespace TKE
{
	public class lekerdezes1 : UserControl
	{
		private SqlConnection myconn = new SqlConnection();

		private DataTable tableTulora = new DataTable();

		private DataTable tableDolgozo = new DataTable();

		private SqlDataAdapter da;

		private int user_ID;

		private mainForm MainForm;

		private ReportDocument rpt1 = new report1();

		private TKE.DataSet ds = new TKE.DataSet();

		private IContainer components;

		private ToolStrip toolStrip;

		private ToolStripButton buttonIndit;

		private ToolStripButton buttonVissza;

		private Panel panel1;

		private DateTimePicker datumIg;

		private DateTimePicker datumTol;

		private Panel panel2;

		private CrystalReportViewer crystalReportViewer1;

		public lekerdezes1(mainForm _mainForm)
		{
			this.user_ID = _mainForm.UserId;
			this.myconn = _mainForm.MyConn;
			this.MainForm = _mainForm;
			this.InitializeComponent();
		}

		private void buttonIndit_Click(object sender, EventArgs e)
		{
			DateTime value = this.datumTol.Value;
			DateTime dateTime = this.datumIg.Value;
			this.tableTulora.Clear();
			string[] shortDateString = new string[] { "select * from tulora where datum between '", value.ToShortDateString(), "' and '", dateTime.ToShortDateString(), "'  order by datum " };
			this.da = new SqlDataAdapter(string.Concat(shortDateString), this.myconn);
			this.da.Fill(this.ds, "tulora");
			this.tableTulora = this.ds.Tables["tulora"];
			this.rpt1.SetDataSource(this.ds);
			this.rpt1.SetParameterValue("DatTol", value.ToShortDateString());
			this.rpt1.SetParameterValue("DatIg", dateTime.ToShortDateString());
			this.crystalReportViewer1.ReportSource = this.rpt1;
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
			this.toolStrip = new ToolStrip();
			this.buttonIndit = new ToolStripButton();
			this.buttonVissza = new ToolStripButton();
			this.panel1 = new Panel();
			this.datumIg = new DateTimePicker();
			this.datumTol = new DateTimePicker();
			this.panel2 = new Panel();
			this.crystalReportViewer1 = new CrystalReportViewer();
			this.toolStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripItemCollection items = this.toolStrip.Items;
			ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.buttonIndit, this.buttonVissza };
			items.AddRange(toolStripItemArray);
			this.toolStrip.Location = new Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(1055, 25);
			this.toolStrip.TabIndex = 4;
			this.buttonIndit.Image = Resources.Document_01;
			this.buttonIndit.ImageTransparentColor = Color.Magenta;
			this.buttonIndit.Name = "buttonIndit";
			this.buttonIndit.Size = new System.Drawing.Size(53, 22);
			this.buttonIndit.Text = "Indít";
			this.buttonIndit.Click += new EventHandler(this.buttonIndit_Click);
			this.buttonVissza.Image = Resources.left;
			this.buttonVissza.ImageTransparentColor = Color.Black;
			this.buttonVissza.Name = "buttonVissza";
			this.buttonVissza.Size = new System.Drawing.Size(64, 22);
			this.buttonVissza.Text = "Vissza";
			this.buttonVissza.Click += new EventHandler(this.buttonVissza_Click);
			this.panel1.BackColor = SystemColors.ControlDark;
			this.panel1.Controls.Add(this.datumIg);
			this.panel1.Controls.Add(this.datumTol);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 25);
			this.panel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1055, 45);
			this.panel1.TabIndex = 5;
			this.datumIg.CustomFormat = "";
			this.datumIg.Format = DateTimePickerFormat.Short;
			this.datumIg.Location = new Point(556, 9);
			this.datumIg.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.datumIg.Name = "datumIg";
			this.datumIg.Size = new System.Drawing.Size(133, 26);
			this.datumIg.TabIndex = 2;
			this.datumTol.CustomFormat = "yyyy.MMMM";
			this.datumTol.Format = DateTimePickerFormat.Short;
			this.datumTol.Location = new Point(366, 9);
			this.datumTol.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.datumTol.Name = "datumTol";
			this.datumTol.Size = new System.Drawing.Size(143, 26);
			this.datumTol.TabIndex = 0;
			this.panel2.Controls.Add(this.crystalReportViewer1);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 70);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1055, 507);
			this.panel2.TabIndex = 6;
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer1.Cursor = Cursors.Default;
			this.crystalReportViewer1.Dock = DockStyle.Fill;
			this.crystalReportViewer1.Location = new Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ShowGotoPageButton = false;
			this.crystalReportViewer1.ShowGroupTreeButton = false;
			this.crystalReportViewer1.ShowParameterPanelButton = false;
			this.crystalReportViewer1.ShowRefreshButton = false;
			this.crystalReportViewer1.ShowTextSearchButton = false;
			this.crystalReportViewer1.Size = new System.Drawing.Size(1055, 507);
			this.crystalReportViewer1.TabIndex = 0;
			this.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
			base.AutoScaleDimensions = new SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.toolStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "lekerdezes1";
			base.Size = new System.Drawing.Size(1055, 577);
			base.Load += new EventHandler(this.lekerdezes1_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void lekerdezes1_Load(object sender, EventArgs e)
		{
			this.tableDolgozo.Clear();
			this.da = new SqlDataAdapter("select * from dolgozo ", this.myconn);
			this.da.Fill(this.ds, "dolgozo");
			this.tableDolgozo = this.ds.Tables["dolgozo"];
		}
	}
}