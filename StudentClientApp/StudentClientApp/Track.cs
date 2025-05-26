using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using StudentClientApp.Models;

namespace StudentClientApp
{
    public partial class Track : Form
    {
        private HubConnection connection;
        private string currentStudentId;
        public Track(string studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;
        }
        private void MakeCircle(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }

        private async void Track_Load(object sender, EventArgs e)
        {
            //para maging bilog ung mga panel
            MakeCircle(circlePending);
            MakeCircle(circleApproved);
            MakeCircle(circleReady);

            circlePending.BackColor = Color.Green;
            circleApproved.BackColor = Color.Gray;
            circleReady.BackColor = Color.Gray;

            await FetchAndUpdateStatusAsync(); // fetch initial status from API

            // Connect to SignalR
            connection = new HubConnectionBuilder()
                .WithUrl("https://formerly-central-spider.ngrok-free.app/requestHub")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string, string>("ReceiveStatusUpdate", (studentId, status) =>
            {
                if (studentId == currentStudentId)
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            UpdateTracking(status);
                        }));
                    }
                    else
                    {
                        UpdateTracking(status);
                    }
                }
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to SignalR hub: " + ex.Message);
            }
        }
        private void UpdateStatusUI(string status)
        {
            switch (status)
            {
                case "Pending":
                    circlePending.BackColor = Color.Orange;
                    circleApproved.BackColor = Color.Gray;
                    circleReady.BackColor = Color.Gray;
                    break;

                case "Approved":
                    circlePending.BackColor = Color.Green;
                    circleApproved.BackColor = Color.Green;
                    circleReady.BackColor = Color.Gray;
                    break;

                case "Ready to Claim":
                    circlePending.BackColor = Color.Green;
                    circleApproved.BackColor = Color.Green;
                    circleReady.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateTracking(string status)
        {
            // Reset all to gray
            circlePending.BackColor = Color.Gray;
            circleApproved.BackColor = Color.Gray;
            circleReady.BackColor = Color.Gray;
            line1.BackColor = Color.Gray;
            line2.BackColor = Color.Gray;

            // Set active or completed
            if (status == "Pending")
            {
                circlePending.BackColor = Color.Green;
            }
            else if (status == "Approved")
            {
                circlePending.BackColor = Color.Green;
                line1.BackColor = Color.Green;
                circleApproved.BackColor = Color.Orange;
            }
            else if (status == "Ready to Claim")
            {
                circlePending.BackColor = Color.Green;
                line1.BackColor = Color.Green;
                circleApproved.BackColor = Color.Green;
                line2.BackColor = Color.Green;
                circleReady.BackColor = Color.Red;
            }
        }
        private async Task FetchAndUpdateStatusAsync()
        {
            string apiUrl = "https://formerly-central-spider.ngrok-free.app/api/RequestInfo"; // Adjust all url kapag nire-run ngrok
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var requestList = JsonConvert.DeserializeObject<List<RequestInfo>>(json);

                        var myRequest = requestList.FirstOrDefault(r => r.StudentId == currentStudentId);
                        if (myRequest != null)
                        {
                            string status = myRequest.Status;
                            if (this.InvokeRequired)
                            {
                                this.BeginInvoke(new MethodInvoker(() =>
                                {
                                    UpdateTracking(status);
                                }));
                            }
                            else
                            {
                                UpdateTracking(status);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to load request data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching status: " + ex.Message);
                }
            }
        }


        private void TrackRequestStatus(string currentStatusFromDb)
        {
            UpdateTracking(currentStatusFromDb);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            StudentSide dashboard = new StudentSide(currentStudentId);
            dashboard.Show();
            this.Close();
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            StudentSide dashboard = new StudentSide(currentStudentId);
            dashboard.Show();
            this.Close();
        }
    }
}
