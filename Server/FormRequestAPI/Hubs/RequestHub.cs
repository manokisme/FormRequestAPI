using Microsoft.AspNetCore.SignalR;

namespace FormRequestAPI.Hubs
{
    public class RequestHub : Hub
    {
        //called to send updates to all connected clients
        public async Task SendStatusUpdate(string studentId, string status)
        {
            // Sending a real-time update to all clients.
            await Clients.All.SendAsync("ReceiveStatusUpdate", studentId, status);
        }
    }
}
