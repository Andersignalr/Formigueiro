using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
	public async Task SendMessage(Message message)
	{
		await Clients.All.SendAsync("ReceiveMessage", message);
	}
}
