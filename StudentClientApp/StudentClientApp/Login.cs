using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace StudentClientApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            IdNumberBox.TextChanged += IdNumberBox_TextChanged;
            PasswordBox.PasswordChar = '*';
            //ShowPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();
        }

        private void IdNumberBox_TextChanged(object sender, EventArgs e)
        {
            string input = IdNumberBox.Text;

            // Remove non-digit characters
            string cleanedInput = new string(input.Where(c => char.IsDigit(c)).ToArray());

            // Check if text is different, then update
            if (input != cleanedInput)
            {
                IdNumberBox.Text = cleanedInput;
              
                IdNumberBox.SelectionStart = IdNumberBox.Text.Length;
            }
        }

        
        private async void SignInBtn_Click(object sender, EventArgs e)
        {
            string idNumber = IdNumberBox.Text.Trim();
            string password = PasswordBox.Text.Trim();

            if (string.IsNullOrEmpty(idNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in both fields.");
                return;
            }

            // local API URL
            string apiBaseUrl = "https://formerly-central-spider.ngrok-free.app/api/";
            bool loginSuccess = false;


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);

                    HttpResponseMessage response = await client.GetAsync($"StudentInfo/{idNumber}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var student = JsonConvert.DeserializeObject<Student>(content);

                        if (student != null && student.Password == password)
                        {
                            MessageBox.Show("Login successful!");
                            StudentSide studentForm = new StudentSide(student.IdNumber);
                            studentForm.Show();
                            this.Hide();
                            loginSuccess = true;
                            return;
                        }
                        else if (student != null)
                        {
                            MessageBox.Show("Incorrect password. Please try again.");
                            return;
                        }
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the API: " + ex.Message);
            }


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);

                    // Send POST request to the /Login endpoint
                    var loginRequest = new { IdNumber = idNumber, Password = password };
                    string jsonContent = JsonConvert.SerializeObject(loginRequest);

                    HttpResponseMessage response = await client.PostAsync("RegistrarInfo/Login",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var registrar = JsonConvert.DeserializeObject<RegistrarInfo>(content);

                        if (registrar != null)
                        {
                            MessageBox.Show("Login successful!");
                            AdminSide adminForm = new AdminSide(); // Navigate to AdminSide
                            adminForm.Show();
                            this.Hide();
                            this.Hide();
                            loginSuccess = true;
                            return;
                        }
                       
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the API: " + ex.Message);
            }

            //condition if neither student nor registrar is incorrect
            if (!loginSuccess)
            {
                MessageBox.Show("ID not found or invalid credentials. Please try again.");
            }

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.PasswordChar = ShowPasswordCheckBox.Checked ? '\0' : '*';
        }
    }

    // Helper class to represent the student
    public class Student
    {
        public string IdNumber { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
    public class RegistrarInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string Password { get; set; }
    }
}
