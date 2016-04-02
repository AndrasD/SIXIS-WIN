using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TKE
{
	public class UserControl1 : UserControl
	{
		private IContainer components;

		private GroupBox groupBox1;

		private ListBox listBox3;

		private ListBox listBox2;

		private ListBox listBox1;

		private Label label3;

		private Label label2;

		private Label label1;

		private GroupBox groupBox2;

		private ComboBox comboBox4;

		private ComboBox comboBox3;

		private ComboBox comboBox2;

		private Label label9;

		private Label label8;

		private Label label7;

		private TextBox textBox2;

		private Label label6;

		private ComboBox comboBox1;

		private Label label5;

		private TextBox textBox1;

		private Label label4;

		private ComboBox comboBox7;

		private ComboBox comboBox6;

		private ComboBox comboBox5;

		private Button button1;

		public UserControl1()
		{
			this.InitializeComponent();
		}

		private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
		{
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
			this.groupBox1 = new GroupBox();
			this.listBox3 = new ListBox();
			this.listBox2 = new ListBox();
			this.listBox1 = new ListBox();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox2 = new GroupBox();
			this.comboBox4 = new ComboBox();
			this.comboBox3 = new ComboBox();
			this.comboBox2 = new ComboBox();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.textBox2 = new TextBox();
			this.label6 = new Label();
			this.comboBox1 = new ComboBox();
			this.label5 = new Label();
			this.textBox1 = new TextBox();
			this.label4 = new Label();
			this.comboBox5 = new ComboBox();
			this.comboBox6 = new ComboBox();
			this.comboBox7 = new ComboBox();
			this.button1 = new Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.comboBox7);
			this.groupBox1.Controls.Add(this.comboBox6);
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.listBox3);
			this.groupBox1.Controls.Add(this.listBox2);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = FlatStyle.System;
			this.groupBox1.Location = new Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(754, 198);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Szervízanyag ajánlatkérés";
			this.listBox3.BackColor = SystemColors.ScrollBar;
			this.listBox3.FormattingEnabled = true;
			ListBox.ObjectCollection items = this.listBox3.Items;
			object[] objArray = new object[] { "Összes", "1L", "5L", "15L", "20L" };
			items.AddRange(objArray);
			this.listBox3.Location = new Point(444, 72);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(120, 95);
			this.listBox3.TabIndex = 5;
			this.listBox2.BackColor = SystemColors.ScrollBar;
			this.listBox2.FormattingEnabled = true;
			ListBox.ObjectCollection objectCollections = this.listBox2.Items;
			object[] objArray1 = new object[] { "Összes", "Téli ablakmosó -20C", "Téli ablakmosó -35C", "Nyári zöld ablakmosó", "Nyári ibolya illatú" };
			objectCollections.AddRange(objArray1);
			this.listBox2.Location = new Point(243, 72);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(120, 95);
			this.listBox2.TabIndex = 4;
			this.listBox1.BackColor = SystemColors.ScrollBar;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Items.AddRange(new object[] { "Ablakmosó", "Fagyálló", "Féktisztító" });
			this.listBox1.Location = new Point(29, 72);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 95);
			this.listBox1.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(441, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Kiszerelés:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(240, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Anyag:";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(26, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Kategória:";
			this.groupBox2.Controls.Add(this.comboBox4);
			this.groupBox2.Controls.Add(this.comboBox3);
			this.groupBox2.Controls.Add(this.comboBox2);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new Point(4, 233);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(405, 218);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Szervízanyag karbantartás";
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new Point(133, 178);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(121, 21);
			this.comboBox4.TabIndex = 12;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new Point(133, 149);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 11;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new Point(133, 118);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 10;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(16, 181);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Gyártó:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(16, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Márka:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(16, 121);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Kiszerelés:";
			this.textBox2.Location = new Point(133, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(266, 20);
			this.textBox2.TabIndex = 5;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(16, 91);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Anyag megnevezés:";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(133, 59);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 3;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(16, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Kategória:";
			this.textBox1.Location = new Point(133, 34);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(166, 20);
			this.textBox1.TabIndex = 1;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(16, 37);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "OE szám. (azonosító):";
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Items.AddRange(new object[] { "Ablakmosó" });
			this.comboBox5.Location = new Point(29, 46);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(121, 21);
			this.comboBox5.TabIndex = 6;
			this.comboBox5.Text = "Ablakmosó";
			this.comboBox6.FormattingEnabled = true;
			this.comboBox6.Location = new Point(242, 46);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(121, 21);
			this.comboBox6.TabIndex = 7;
			this.comboBox6.Text = "Téli ablakmosó -20C";
			this.comboBox6.SelectedIndexChanged += new EventHandler(this.comboBox6_SelectedIndexChanged);
			this.comboBox7.FormattingEnabled = true;
			this.comboBox7.Location = new Point(443, 46);
			this.comboBox7.Name = "comboBox7";
			this.comboBox7.Size = new System.Drawing.Size(121, 21);
			this.comboBox7.TabIndex = 8;
			this.comboBox7.Text = "15L";
			this.button1.Location = new Point(596, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Hozzáadás";
			this.button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Name = "UserControl1";
			base.Size = new System.Drawing.Size(903, 644);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}