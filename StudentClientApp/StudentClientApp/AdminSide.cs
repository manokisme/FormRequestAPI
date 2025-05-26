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
  
    public partial class AdminSide : Form
    {
        private HubConnection _hubConnection;
        public AdminSide()
        {
            InitializeComponent();
           DataAdmin.CellClick += DataAdmin_CellClick;

        }

        private async void AdminSide_Load(object sender, EventArgs e)
        {
            _hubConnection = new HubConnectionBuilder()
       .WithUrl("https://formerly-central-spider.ngrok-free.app/requesthub") // to match SignalR route
       .WithAutomaticReconnect()
       .Build();

            _hubConnection.On<RequestInfo>("ReceiveNewRequest", async (request) =>
            {
                Console.WriteLine("SignalR: ReceiveNewRequest received.");
                await LoadRequestsAsync();
            });

            try
            {
                await _hubConnection.StartAsync();
                Console.WriteLine("SignalR connected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to SignalR: " + ex.Message);
            }

            await LoadRequestsAsync();
        }
        private async Task LoadRequestsAsync()
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
                        var requestList = JsonConvert.DeserializeObject<List<RequestInfo>>(json);

                        var sortedList = requestList
                            .OrderBy(r => r.Status == "Claimed" ? 1 : 0) // Claimed go last
                            .ToList();


                        var displayList = requestList.Select(r => new
                        {
                            r.Id,
                            r.FullName,
                            r.Age,
                            r.Address,
                            r.StudentId,
                            r.Program,
                            r.FormRequested,
                            r.PurposeOfRequest,
                            r.PaymentMethod,
                            r.Status
                        }).ToList();

                        DataAdmin.DataSource = displayList;

                        if (DataAdmin.Columns.Contains("Action"))
                            DataAdmin.Columns.Remove("Action");

                        DataGridViewButtonColumn actionBtn = new DataGridViewButtonColumn();
                        actionBtn.Name = "Action";
                        actionBtn.HeaderText = "Status";
                        actionBtn.UseColumnTextForButtonValue = false;
                        DataAdmin.Columns.Add(actionBtn);

                        // Set text based on current status
                        foreach (DataGridViewRow row in DataAdmin.Rows)
                        {
                            string status = row.Cells["Status"].Value?.ToString();

                            var buttonCell = (DataGridViewButtonCell)row.Cells["Action"];

                            if (status == "Approved")
                            {
                                buttonCell.Value = "Ready to Claim";
                                buttonCell.ReadOnly = false;
                                buttonCell.FlatStyle = FlatStyle.Standard;
                                buttonCell.Style.ForeColor = Color.Black;
                            }
                            else if (status == "Ready to Claim")
                            {
                                // Hide the button: no text, disable clicking
                                buttonCell.Value = "";
                                buttonCell.ReadOnly = true;
                                buttonCell.FlatStyle = FlatStyle.Flat;
                                buttonCell.Style.ForeColor = Color.Transparent;
                                buttonCell.Style.SelectionForeColor = Color.Transparent;
                            }
                            else if (status == "Claimed")
                            {
                                // Also hide for claimed
                                buttonCell.Value = "";
                                buttonCell.ReadOnly = true;
                                buttonCell.FlatStyle = FlatStyle.Flat;
                                buttonCell.Style.ForeColor = Color.Transparent;
                                buttonCell.Style.SelectionForeColor = Color.Transparent;
                            }
                            else
                            {
                                // For Pending or others, show "Accept"
                                buttonCell.Value = "Accept";
                                buttonCell.ReadOnly = false;
                                buttonCell.FlatStyle = FlatStyle.Standard;
                                buttonCell.Style.ForeColor = Color.Black;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch data from API.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private async void DataAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DataAdmin.Columns[e.ColumnIndex].Name == "Action")
            {
                try
                {
                    int requestId = Convert.ToInt32(DataAdmin.Rows[e.RowIndex].Cells["Id"].Value);
                    string currentStatus = DataAdmin.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                    string nextStatus = "";

                    if (currentStatus == "Pending" || string.IsNullOrEmpty(currentStatus))
                    {
                        nextStatus = "Approved";
                    }
                    else if (currentStatus == "Approved")
                    {
                        nextStatus = "Ready to Claim";
                    }
                    else
                    {
                        return; 
                    }

                    string apiUrl = "https://formerly-central-spider.ngrok-free.app/api/Request/updateStatus";
                    var update = new
                    {
                        Id = requestId,
                        Status = nextStatus
                    };

                    using (HttpClient client = new HttpClient())
                    {
                        var json = JsonConvert.SerializeObject(update);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(apiUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Status updated to {nextStatus}.");
                            await LoadRequestsAsync(); // Refresh table 
                        }
                        else
                        {
                            MessageBox.Show("Failed to update status.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
       
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            await LoadRequestsAsync();
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
           // await LoadRequestsAsync();
        }
    }

   
}