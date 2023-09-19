namespace Human_Resource_Management
{
    partial class AdminNotifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminNotifications));
            this.button1 = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.leaves_table = new System.Windows.Forms.DataGridView();
            this.disapprove = new System.Windows.Forms.Button();
            this.approve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list_end_service = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.leaves_table)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(936, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.close.TabIndex = 8;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // leaves_table
            // 
            this.leaves_table.AllowUserToAddRows = false;
            this.leaves_table.AllowUserToDeleteRows = false;
            this.leaves_table.AllowUserToResizeRows = false;
            this.leaves_table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.leaves_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leaves_table.Location = new System.Drawing.Point(39, 384);
            this.leaves_table.MultiSelect = false;
            this.leaves_table.Name = "leaves_table";
            this.leaves_table.ReadOnly = true;
            this.leaves_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.leaves_table.Size = new System.Drawing.Size(953, 261);
            this.leaves_table.TabIndex = 20;
            // 
            // disapprove
            // 
            this.disapprove.BackColor = System.Drawing.Color.Maroon;
            this.disapprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disapprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disapprove.ForeColor = System.Drawing.Color.White;
            this.disapprove.Location = new System.Drawing.Point(646, 683);
            this.disapprove.Name = "disapprove";
            this.disapprove.Size = new System.Drawing.Size(160, 43);
            this.disapprove.TabIndex = 22;
            this.disapprove.Text = "Disapprove Leave";
            this.disapprove.UseVisualStyleBackColor = false;
            this.disapprove.Click += new System.EventHandler(this.disapprove_Click);
            // 
            // approve
            // 
            this.approve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.approve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approve.ForeColor = System.Drawing.Color.White;
            this.approve.Location = new System.Drawing.Point(250, 683);
            this.approve.Name = "approve";
            this.approve.Size = new System.Drawing.Size(160, 43);
            this.approve.TabIndex = 21;
            this.approve.Text = "Approve Leave";
            this.approve.UseVisualStyleBackColor = false;
            this.approve.Click += new System.EventHandler(this.approve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(344, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "New Leave Demands";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(310, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 39);
            this.label2.TabIndex = 24;
            this.label2.Text = "End of Service Employees";
            // 
            // list_end_service
            // 
            this.list_end_service.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.list_end_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_end_service.ForeColor = System.Drawing.SystemColors.Menu;
            this.list_end_service.Location = new System.Drawing.Point(39, 128);
            this.list_end_service.Name = "list_end_service";
            this.list_end_service.ReadOnly = true;
            this.list_end_service.Size = new System.Drawing.Size(953, 176);
            this.list_end_service.TabIndex = 25;
            this.list_end_service.Text = "";
            // 
            // AdminNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.list_end_service);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disapprove);
            this.Controls.Add(this.approve);
            this.Controls.Add(this.leaves_table);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminNotifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminNotifications";
            this.Load += new System.EventHandler(this.AdminNotifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leaves_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.DataGridView leaves_table;
        private System.Windows.Forms.Button disapprove;
        private System.Windows.Forms.Button approve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox list_end_service;
    }
}