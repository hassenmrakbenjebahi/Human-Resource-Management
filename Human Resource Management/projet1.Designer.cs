﻿namespace Human_Resource_Management
{
    partial class projet1
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
            this.client_table = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.arch = new System.Windows.Forms.ComboBox();
            this.de = new System.Windows.Forms.DateTimePicker();
            this.a = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.client_table)).BeginInit();
            this.SuspendLayout();
            // 
            // client_table
            // 
            this.client_table.AllowUserToAddRows = false;
            this.client_table.AllowUserToDeleteRows = false;
            this.client_table.AllowUserToResizeRows = false;
            this.client_table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.client_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.client_table.Location = new System.Drawing.Point(36, 132);
            this.client_table.MultiSelect = false;
            this.client_table.Name = "client_table";
            this.client_table.ReadOnly = true;
            this.client_table.Size = new System.Drawing.Size(953, 535);
            this.client_table.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(88, 691);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 43);
            this.button3.TabIndex = 15;
            this.button3.Text = "Add projet";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Olive;
            this.edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit.ForeColor = System.Drawing.Color.White;
            this.edit.Location = new System.Drawing.Point(306, 691);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(160, 43);
            this.edit.TabIndex = 16;
            this.edit.Text = "Edit projet";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Maroon;
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(525, 691);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(160, 43);
            this.delete.TabIndex = 17;
            this.delete.Text = "Delete projet";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Brown;
            this.close.Location = new System.Drawing.Point(977, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 28);
            this.close.TabIndex = 22;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(741, 691);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 43);
            this.button1.TabIndex = 23;
            this.button1.Text = "Imprimer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // arch
            // 
            this.arch.FormattingEnabled = true;
            this.arch.Location = new System.Drawing.Point(202, 43);
            this.arch.Name = "arch";
            this.arch.Size = new System.Drawing.Size(121, 21);
            this.arch.TabIndex = 26;
            // 
            // de
            // 
            this.de.Location = new System.Drawing.Point(202, 81);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(200, 20);
            this.de.TabIndex = 27;
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(505, 81);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(200, 20);
            this.a.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(782, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "filtrer par date";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(782, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 23);
            this.button4.TabIndex = 30;
            this.button4.Text = "filtrer par architecte";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // projet1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.a);
            this.Controls.Add(this.de);
            this.Controls.Add(this.arch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.client_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "projet1";
            this.Text = "projet1";
            this.Load += new System.EventHandler(this.projet1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.client_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView client_table;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox arch;
        private System.Windows.Forms.DateTimePicker de;
        private System.Windows.Forms.DateTimePicker a;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}