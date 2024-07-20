using Microsoft.AspNetCore.SignalR;

namespace uchat.Hubs
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(string user, string message)
	   => await Clients.All.SendAsync("ReceiveMessage", user, message);

		public async Task SendPrivateMessage(string fromUser, string toUser, string message)
			=> await Clients.User(toUser).SendAsync("ReceivePrivateMessage", fromUser, message);
		public async Task JoinGroup(string roomid, string username)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, roomid);
			await Clients.Group(roomid).SendAsync("ReceiveGroupMessage", "System", $"{username} has joined the room");
		}

		public async Task SendMessageToGroup(string roomid, string username, string message)
        {
            await Clients.Group(roomid).SendAsync("ReceiveGroupMessage", username, message);
        }
		public async Task LeaveGroup(string roomid, string username)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomid);
            await Clients.Group(roomid).SendAsync("ReceiveGroupMessage", "System", $"{username} has left the room");
        }
	}
}
