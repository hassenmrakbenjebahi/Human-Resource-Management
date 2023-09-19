namespace Human_Resource_Management
{
    partial class projet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.dat = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.c1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c2 = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.str = new System.Windows.Forms.CheckBox();
            this.vrd = new System.Windows.Forms.CheckBox();
            this.sec = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sur = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nblot = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.architecteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.architecteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prix = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.architecteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.architecteBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(181, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add projet Form";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.date.Location = new System.Drawing.Point(24, 96);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(87, 33);
            this.date.TabIndex = 6;
            this.date.Text = "date :";
            // 
            // dat
            // 
            this.dat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dat.Location = new System.Drawing.Point(250, 109);
            this.dat.Name = "dat";
            this.dat.Size = new System.Drawing.Size(100, 20);
            this.dat.TabIndex = 7;
            this.dat.Value = new System.DateTime(2019, 2, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "architect :";
            // 
            // c1
            // 
            this.c1.FormattingEnabled = true;
            this.c1.Location = new System.Drawing.Point(250, 167);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(101, 21);
            this.c1.TabIndex = 9;
            this.c1.SelectedIndexChanged += new System.EventHandler(this.c1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(24, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "client :";
            // 
            // c2
            // 
            this.c2.FormattingEnabled = true;
            this.c2.Location = new System.Drawing.Point(251, 224);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(100, 21);
            this.c2.TabIndex = 11;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Brown;
            this.close.Location = new System.Drawing.Point(682, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 28);
            this.close.TabIndex = 23;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(30, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 33);
            this.label4.TabIndex = 24;
            this.label4.Text = "type d\'étude :";
            // 
            // str
            // 
            this.str.AutoSize = true;
            this.str.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.str.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.str.Location = new System.Drawing.Point(250, 282);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(101, 28);
            this.str.TabIndex = 25;
            this.str.Text = "structure";
            this.str.UseVisualStyleBackColor = true;
            this.str.CheckedChanged += new System.EventHandler(this.str_CheckedChanged);
            // 
            // vrd
            // 
            this.vrd.AutoSize = true;
            this.vrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.vrd.Location = new System.Drawing.Point(250, 330);
            this.vrd.Name = "vrd";
            this.vrd.Size = new System.Drawing.Size(68, 28);
            this.vrd.TabIndex = 26;
            this.vrd.Text = "VRD";
            this.vrd.UseVisualStyleBackColor = true;
            this.vrd.CheckedChanged += new System.EventHandler(this.vrd_CheckedChanged);
            // 
            // sec
            // 
            this.sec.AutoSize = true;
            this.sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sec.Location = new System.Drawing.Point(375, 284);
            this.sec.Name = "sec";
            this.sec.Size = new System.Drawing.Size(95, 28);
            this.sec.TabIndex = 27;
            this.sec.Text = "sécurité";
            this.sec.UseVisualStyleBackColor = true;
            this.sec.CheckedChanged += new System.EventHandler(this.sec_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(30, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 33);
            this.label5.TabIndex = 28;
            this.label5.Text = "Surface:";
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(251, 400);
            this.sur.Name = "sur";
            this.sur.Size = new System.Drawing.Size(100, 20);
            this.sur.TabIndex = 29;
            this.sur.TextChanged += new System.EventHandler(this.sur_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(30, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 33);
            this.label6.TabIndex = 30;
            this.label6.Text = "nombre de lot :";
            // 
            // nblot
            // 
            this.nblot.Location = new System.Drawing.Point(250, 453);
            this.nblot.Name = "nblot";
            this.nblot.Size = new System.Drawing.Size(100, 20);
            this.nblot.TabIndex = 31;
            this.nblot.TextChanged += new System.EventHandler(this.nblot_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(270, 599);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 43);
            this.button3.TabIndex = 32;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // prix
            // 
            this.prix.Location = new System.Drawing.Point(250, 507);
            this.prix.Name = "prix";
            this.prix.Size = new System.Drawing.Size(100, 20);
            this.prix.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(251, 560);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(31, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 33);
            this.label8.TabIndex = 35;
            this.label8.Text = "nombre etage:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(30, 494);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 33);
            this.label7.TabIndex = 37;
            this.label7.Text = "prix:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(122, 494);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 33);
            this.label9.TabIndex = 38;
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Olive;
            this.edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit.ForeColor = System.Drawing.Color.White;
            this.edit.Location = new System.Drawing.Point(404, 499);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(95, 33);
            this.edit.TabIndex = 39;
            this.edit.Text = "calculer";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // projet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(729, 758);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.prix);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nblot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sec);
            this.Controls.Add(this.vrd);
            this.Controls.Add(this.str);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.close);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dat);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "projet";
            this.Text = "addprojet";
            this.Load += new System.EventHandler(this.projet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.architecteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.architecteBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.DateTimePicker dat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox c1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox c2;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox str;
        private System.Windows.Forms.CheckBox vrd;
        private System.Windows.Forms.CheckBox sec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nblot;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
       
        private System.Windows.Forms.BindingSource architecteBindingSource;
       
        private System.Windows.Forms.BindingSource architecteBindingSource1;
        
        private System.Windows.Forms.BindingSource dBDataSetBindingSource;
        private System.Windows.Forms.TextBox prix;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button edit;
    }
}