﻿namespace Human_Resource_Management
{
    partial class livraisonprojet
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
            this.close = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.instance = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.solder = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.instance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solder)).BeginInit();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Brown;
            this.close.Location = new System.Drawing.Point(974, 19);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 28);
            this.close.TabIndex = 29;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(420, 680);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 43);
            this.button3.TabIndex = 28;
            this.button3.Text = "livraison";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(15, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Instance";
            // 
            // instance
            // 
            this.instance.AllowUserToAddRows = false;
            this.instance.AllowUserToDeleteRows = false;
            this.instance.AllowUserToResizeRows = false;
            this.instance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.instance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.instance.Location = new System.Drawing.Point(18, 387);
            this.instance.MultiSelect = false;
            this.instance.Name = "instance";
            this.instance.ReadOnly = true;
            this.instance.Size = new System.Drawing.Size(932, 287);
            this.instance.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Livrer";
            // 
            // solder
            // 
            this.solder.AllowUserToAddRows = false;
            this.solder.AllowUserToDeleteRows = false;
            this.solder.AllowUserToResizeRows = false;
            this.solder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.solder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solder.Location = new System.Drawing.Point(19, 53);
            this.solder.MultiSelect = false;
            this.solder.Name = "solder";
            this.solder.ReadOnly = true;
            this.solder.Size = new System.Drawing.Size(931, 317);
            this.solder.TabIndex = 24;
            this.solder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.solder_CellContentClick);
            // 
            // livraisonprojet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.close);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.instance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "livraisonprojet";
            this.Text = "livraisonprojet";
            this.Load += new System.EventHandler(this.livraisonprojet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.instance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView instance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView solder;
    }
}