using System;
using System.Linq;
using System.Windows.Forms;

namespace StudentClientApp
{
    public partial class StudentSide : Form
    {
        private readonly string studentId;

        public StudentSide(string id)
        {
            InitializeComponent();
            studentId = id;


            RequestBtn.Click -= RequestBtn_Click;
            TrackBtn.Click -= TrackBtn_Click;
            Claimbtn.Click -= Claimbtn_Click;
            ExitBtn.Click -= ExitBtn_Click;

            RequestBtn.Click += RequestBtn_Click;
            TrackBtn.Click += TrackBtn_Click;
            Claimbtn.Click += Claimbtn_Click;
            ExitBtn.Click += ExitBtn_Click;
        }

        private void RequestBtn_Click(object sender, EventArgs e)
        {
            RequestSide requestForm = new RequestSide(studentId);
            requestForm.Show();
            this.Close();

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

        private void Claimbtn_Click(object sender, EventArgs e)
        {
            Claim claimForm = new Claim(studentId);  // Pass the student ID
            claimForm.Show();
            this.Close();

        }
    }
}
