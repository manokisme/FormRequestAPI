namespace StudentClientApp
{
    partial class Track
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Track));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DashboardBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReady = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.circlePending = new System.Windows.Forms.Panel();
            this.circleApproved = new System.Windows.Forms.Panel();
            this.circleReady = new System.Windows.Forms.Panel();
            this.line1 = new System.Windows.Forms.Panel();
            this.line2 = new System.Windows.Forms.Panel();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.DashboardBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 450);
            this.panel1.TabIndex = 0;
            // 
            // DashboardBtn
            // 
            this.DashboardBtn.BackColor = System.Drawing.Color.Teal;
            this.DashboardBtn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.DashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashboardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardBtn.ForeColor = System.Drawing.Color.White;
            this.DashboardBtn.Location = new System.Drawing.Point(0, 0);
            this.DashboardBtn.Name = "DashboardBtn";
            this.DashboardBtn.Size = new System.Drawing.Size(134, 28);
            this.DashboardBtn.TabIndex = 29;
            this.DashboardBtn.Text = "<<Dashboard";
            this.DashboardBtn.UseVisualStyleBackColor = false;
            this.DashboardBtn.Click += new System.EventHandler(this.DashboardBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Swis721 Blk BT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tracking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Swis721 Blk BT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Request ";
            // 
            // labelReady
            // 
            this.labelReady.AutoSize = true;
            this.labelReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReady.ForeColor = System.Drawing.Color.Black;
            this.labelReady.Location = new System.Drawing.Point(211, 172);
            this.labelReady.Name = "labelReady";
            this.labelReady.Size = new System.Drawing.Size(74, 20);
            this.labelReady.TabIndex = 4;
            this.labelReady.Text = "Pending";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(589, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ready to Claim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(404, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Approved";
            // 
            // circlePending
            // 
            this.circlePending.BackColor = System.Drawing.SystemColors.ControlDark;
            this.circlePending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circlePending.Location = new System.Drawing.Point(225, 201);
            this.circlePending.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.circlePending.Name = "circlePending";
            this.circlePending.Size = new System.Drawing.Size(23, 25);
            this.circlePending.TabIndex = 9;
            // 
            // circleApproved
            // 
            this.circleApproved.BackColor = System.Drawing.SystemColors.ControlDark;
            this.circleApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circleApproved.Location = new System.Drawing.Point(425, 201);
            this.circleApproved.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.circleApproved.Name = "circleApproved";
            this.circleApproved.Size = new System.Drawing.Size(23, 25);
            this.circleApproved.TabIndex = 10;
            // 
            // circleReady
            // 
            this.circleReady.BackColor = System.Drawing.SystemColors.ControlDark;
            this.circleReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circleReady.Location = new System.Drawing.Point(626, 201);
            this.circleReady.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.circleReady.Name = "circleReady";
            this.circleReady.Size = new System.Drawing.Size(23, 25);
            this.circleReady.TabIndex = 11;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.line1.Location = new System.Drawing.Point(252, 210);
            this.line1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(169, 8);
            this.line1.TabIndex = 12;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.line2.Location = new System.Drawing.Point(452, 210);
            this.line2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(169, 8);
            this.line2.TabIndex = 13;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Teal;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.Location = new System.Drawing.Point(762, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(40, 32);
            this.ExitBtn.TabIndex = 14;
            this.ExitBtn.Text = "X";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.circleReady);
            this.Controls.Add(this.circleApproved);
            this.Controls.Add(this.circlePending);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelReady);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Track";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Track";
            this.Load += new System.EventHandler(this.Track_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReady;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel circlePending;
        private System.Windows.Forms.Panel circleApproved;
        private System.Windows.Forms.Panel circleReady;
        private System.Windows.Forms.Panel line1;
        private System.Windows.Forms.Panel line2;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DashboardBtn;
    }
}