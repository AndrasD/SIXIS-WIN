using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TKE
{
    public partial class dolgozo2 : UserControl
    {
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

        public dolgozo2(mainForm mF)
        {
            this.myconn = mF.MyConn;
            this._mainForm = mF;
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
