using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using StudentClientApp.Models;
using Microsoft.AspNetCore.SignalR.Client;


namespace StudentClientApp
{
    public partial class RequestSide : Form
    {
        private string currentStudentId;
        public RequestSide(string studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;

            // Pre-fill the student ID
            IdBox.Text = currentStudentId;
            IdBox.ReadOnly = true;
            DocTypeBox.Items.AddRange(new string[]
           {
                "Certificate of Graduation",
                "Certificate of Enrollment",
                "Diploma",
                "Transcript of Records",
                "Certificate of Honors Received",
                "Study Permit/Cross-Enroll Permit"
           });

            PurposeBox.Items.AddRange(new string[]
            {
                "Transfer",
                "Employment",
                "Civil Service Exam",
                "Board Exam",
                "Scholarship",
                "Evaluation",
                "Promotion",
                "Reference"
            });

            PaymentBox.Items.AddRange(new string[]
            {
                "Gcash",
                "Pay at the cashier"
            });
            // Enter key: FullName → Age
            FullNameBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    AgeBox.Focus();
                }
            };

            // Enter key: Age → Address, with age range check
            AgeBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (int.TryParse(AgeBox.Text.Trim(), out int age))
                    {
                        if (age >= 16 && age <= 100)
                        {
                            AddBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Age must be between 16 and above.");
                            AgeBox.Focus();
                            AgeBox.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid age.");
                        AgeBox.Focus();
                        AgeBox.SelectAll();
                    }
                }
            };

            
            AddBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ProgramBox.Focus();
                }
            };

           
            ProgramBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    DocTypeBox.Focus();
                }
            };

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FullNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProgramBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DocTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PurposeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void SendBtn_Click(object sender, EventArgs e)
        {
            // Get values from the form
            var fullName = FullNameBox.Text.Trim();
            var ageText = AgeBox.Text.Trim();
            var address = AddBox.Text.Trim();
            var idNumber = IdBox.Text.Trim();
            var program = ProgramBox.Text.Trim();
            var docType = DocTypeBox.SelectedItem?.ToString();
            var purpose = PurposeBox.SelectedItem?.ToString();
            var paymentMethod = PaymentBox.SelectedItem?.ToString();

            // Validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(ageText) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(idNumber) ||
                string.IsNullOrEmpty(program) || string.IsNullOrEmpty(docType) ||
                string.IsNullOrEmpty(purpose) || string.IsNullOrEmpty(paymentMethod))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(ageText, out int age))
            {
                MessageBox.Show("Age must be a valid number.");
                return;
            }
            if (!Agreement.Checked)
            {
                MessageBox.Show("You must agree to the terms before submitting the request.");
                return;
            }

            var request = new RequestInfo
            {
                FullName = fullName,
                Age = age,
                Address = address,
                StudentId = idNumber,
                Program = program,
                FormRequested = docType,
                PurposeOfRequest = purpose,
                PaymentMethod = paymentMethod,
                Status = "Pending"
            };

            try
            {
                string apiUrl = "https://formerly-central-spider.ngrok-free.app/api/RequestInfo"; // URL of API

                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Request submitted successfully!");
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show($"Failed to submit request. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting the request: " + ex.Message);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            StudentSide dashboard = new StudentSide(currentStudentId); 
            dashboard.Show();                        
            this.Close();
        }

        private void Agreement_CheckedChanged(object sender, EventArgs e)
        {
            if (!Agreement.Checked)
            {
                MessageBox.Show("Please agree to the terms before submitting the request.");
            }

        }
    }
    /*public class RequestInfo
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string StudentId { get; set; }
        public string Program { get; set; }
        public string FormRequested { get; set; }
        public string PurposeOfRequest { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
    */
}
