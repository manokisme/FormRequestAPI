using Microsoft.AspNetCore.SignalR;

namespace FormRequestAPI.Hubs
{
    public class RequestHub : Hub
    {
        // This method is called to send updates to all connected clients (students).
        public async Task SendStatusUpdate(string studentId, string status)
        {
            // Sending a real-time update to all clients.
            await Clients.All.SendAsync("ReceiveStatusUpdate", studentId, status);
        }
    }
}
