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
    public partial class StudentSide : Form
    {
        private string studentId;
        public StudentSide(string id)
        {
            InitializeComponent();
            studentId = id;
            RequestBtn.Click += RequestBtn_Click;
            TrackBtn.Click += TrackBtn_Click;
        }

        private void RequestBtn_Click(object sender, EventArgs e)
        {
            RequestSide requestForm = new RequestSide(studentId);
            requestForm.Show();
            this.Hide();

        }

        private void TrackBtn_Click(object sender, EventArgs e)
        {
            Track trackForm = new Track(studentId);
            trackForm.Show();
            this.Close();

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
