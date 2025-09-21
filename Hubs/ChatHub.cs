using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs;

public class ChatHub : Hub
{
    private static List<Message> messages = new List<Message>();

    public async Task SendMessage(string user, string text)
    {
        var msg = new Message { User = user, Text = text, Timestamp = DateTime.UtcNow };
        messages.Add(msg);
        await Clients.All.SendAsync("ReceiveMessage", msg.User, msg.Text, msg.Timestamp);
    }

    public List<Message> GetAllMessages() => messages;
}
