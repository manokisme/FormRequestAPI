using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace StudentClientApp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            IdNumberBox2.TextChanged += IdNumberBox2_TextChanged;
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            // You can add any setup code here if needed when the form loads
        }

        private async void SignUpBtn_Click(object sender, EventArgs e)
        {
            string fullName = FullNameBox.Text.Trim();
            string idNumber = IdNumberBox2.Text.Trim();
            string password = PasswordBox2.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(idNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            var newStudent = new Student
            {
                FullName = fullName,
                IdNumber = idNumber,
                Password = password
            };

            try
            {
                string apiBaseUrl = "https://c34b-160-25-95-134.ngrok-free.app/api/";

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);

                    // Check if ID already exists
                    HttpResponseMessage checkResponse = await client.GetAsync($"StudentInfo/{idNumber}");
                    if (checkResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("ID number already exists. Please use a different one.");
                        return;
                    }

                    // Proceed with registration if ID is not found
                    string json = JsonConvert.SerializeObject(newStudent);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("StudentInfo", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Account created successfully!");
                        Login loginForm = new Login();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to create account. Status: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exits the application
        }

        private void IdNumberBox2_TextChanged(object sender, EventArgs e)
        {
            // Ensure the textbox only contains digits
            string input = IdNumberBox2.Text;

            // Remove non-digit characters
            if (input.Any(c => !char.IsDigit(c)))
            {
                // Remove the last non-digit character
                IdNumberBox2.Text = new string(input.Where(c => char.IsDigit(c)).ToArray());
                // Move the cursor to the end
                IdNumberBox2.SelectionStart = IdNumberBox2.Text.Length;
            }

        }
    }

}
