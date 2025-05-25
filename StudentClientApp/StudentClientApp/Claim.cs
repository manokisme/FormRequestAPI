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

namespace StudentClientApp
{
    public partial class Claim : Form
    {
        private string studentId;
        private int requestId; //for updating lang
        private bool hasShownNotReadyMessage = false;
        private RequestInfo currentRequest; // para sa stub info
        public Claim(string id)
        {
            InitializeComponent();
            studentId = id;
            this.Load += Claim_Load;
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            StudentSide dashboard = new StudentSide(studentId);
            dashboard.Show();
            this.Close();
        }
        private async void Claim_Load(object sender, EventArgs e)
        {
            await CheckIfReadyToClaimAsync();
        }

        private async Task CheckIfReadyToClaimAsync()
        {
            string apiUrl = "https://formerly-central-spider.ngrok-free.app/api/RequestInfo";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var requests = JsonConvert.DeserializeObject<List<RequestInfo>>(json);

                        this.currentRequest = requests
                            .Where(r => r.StudentId == studentId)
                            .OrderByDescending(r => r.Id)  //new requests para nd sabog
                            .FirstOrDefault();


                        if (currentRequest != null && currentRequest.Status == "Ready to Claim")
                        {
                            requestId = currentRequest.Id;
                            ClaimBtn.Enabled = true;
                            hasShownNotReadyMessage = false;
                        }
                        else
                        {
                            if (!hasShownNotReadyMessage)
                            {
                                MessageBox.Show("Your request is not ready to claim yet.");
                                hasShownNotReadyMessage = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch request status.");
                        ClaimBtn.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking status: " + ex.Message);
                    ClaimBtn.Enabled = false;
                }
            }
        }

        private async void ClaimBtn_Click(object sender, EventArgs e)
        {
            await UpdateStatusToClaimedAsync();

        }
        private async Task UpdateStatusToClaimedAsync()
        {
            string apiUrl = "https://formerly-central-spider.ngrok-free.app/api/Request/updateStatus";

            var update = new
            {
                Id = requestId,
                Status = "Claimed"
            };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(update);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thank you for claiming your request!");
                        DateTime claimedDate = DateTime.Now;

                        // Open Claim Stub
                        if (this.currentRequest != null)
                        {
                            ClaimStub stub = new ClaimStub(
                                this.currentRequest.FullName,
                                this.currentRequest.FormRequested,
                                this.currentRequest.StudentId,
                                claimedDate
                            );
                            stub.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Warning: Could not generate claim stub. Missing request info.");
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gcashQrUrl = "https://i.postimg.cc/P5pYdtH7/64227f4a-f211-4428-bba0-32fca3167a51.jpg"; // gcash url

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = gcashQrUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open GCash QR code link: " + ex.Message);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            StudentSide dashboard = new StudentSide(studentId);
            dashboard.Show();
            this.Close();
        }
    }
}
