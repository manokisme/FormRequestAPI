namespace StudentClientApp
{
    partial class ClaimStub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaimStub));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExtBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblFormRequested = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblClaimedDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.ExtBtn);
            this.panel1.Controls.Add(this.ExitBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 47);
            this.panel1.TabIndex = 1;
            // 
            // ExtBtn
            // 
            this.ExtBtn.BackColor = System.Drawing.Color.White;
            this.ExtBtn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.ExtBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtBtn.ForeColor = System.Drawing.Color.Teal;
            this.ExtBtn.Location = new System.Drawing.Point(341, 0);
            this.ExtBtn.Name = "ExtBtn";
            this.ExtBtn.Size = new System.Drawing.Size(40, 32);
            this.ExtBtn.TabIndex = 30;
            this.ExtBtn.Text = "X";
            this.ExtBtn.UseVisualStyleBackColor = false;
            this.ExtBtn.Click += new System.EventHandler(this.ExtBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.White;
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Teal;
            this.ExitBtn.Location = new System.Drawing.Point(939, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(40, 32);
            this.ExitBtn.TabIndex = 29;
            this.ExitBtn.Text = "X";
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(26, 158);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(77, 15);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblFormRequested
            // 
            this.lblFormRequested.AutoSize = true;
            this.lblFormRequested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormRequested.Location = new System.Drawing.Point(26, 229);
            this.lblFormRequested.Name = "lblFormRequested";
            this.lblFormRequested.Size = new System.Drawing.Size(117, 15);
            this.lblFormRequested.TabIndex = 3;
            this.lblFormRequested.Text = "Form Requested:";
            this.lblFormRequested.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentId.Location = new System.Drawing.Point(26, 191);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(76, 15);
            this.lblStudentId.TabIndex = 4;
            this.lblStudentId.Text = "Student Id:";
            // 
            // lblClaimedDate
            // 
            this.lblClaimedDate.AutoSize = true;
            this.lblClaimedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaimedDate.Location = new System.Drawing.Point(26, 267);
            this.lblClaimedDate.Name = "lblClaimedDate";
            this.lblClaimedDate.Size = new System.Drawing.Size(98, 15);
            this.lblClaimedDate.TabIndex = 5;
            this.lblClaimedDate.Text = "Claimed Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Claim Slip";
            // 
            // ClaimStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblClaimedDate);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.lblFormRequested);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClaimStub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClaimStub";
            this.Load += new System.EventHandler(this.ClaimStub_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblFormRequested;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblClaimedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExtBtn;
    }
}