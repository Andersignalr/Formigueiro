using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
	public async Task SendMessage(string mensagem)
	{
		await Clients.All.SendAsync("ReceiveMessage", mensagem);
	}
}
