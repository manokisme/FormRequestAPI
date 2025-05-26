using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentClientApp
{
    public partial class ClaimStub : Form
    {
        private string studentId;
        public ClaimStub(string fullName, string formRequested, string studentId, DateTime claimedDate)
        {
            InitializeComponent();
            this.studentId = studentId;

            lblFullName.Text = $"Full Name: {fullName}";
            lblFormRequested.Text = $"Form Requested: {formRequested}";
            lblStudentId.Text = $"ID Number: {studentId}";
            lblClaimedDate.Text = $"Claimed Date: {claimedDate:MMMM dd, yyyy}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClaimStub_Load(object sender, EventArgs e)
        {

        }

        private void ExtBtn_Click(object sender, EventArgs e)
        {
            Claim claimForm = new Claim(studentId);
            claimForm.Show();
            this.Close();
        }
    }
}
