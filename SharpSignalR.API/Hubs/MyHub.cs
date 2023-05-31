using System;
using Microsoft.AspNetCore.SignalR;

namespace SharpSignalR.API.Hubs
{
	public class MyHub:Hub
	{
		private static List<string> Names { get; set; } = new List<string>();

		private static int ClientCount { get; set; } = 0;

		public static int TeamCount { get; set; } = 7;

		public async Task SendName(string name)
		{
			if(Names.Count >= TeamCount)
			{
				await Clients.Caller.SendAsync("Error", $"The team can have a maximum of {TeamCount} people.");
			}
			else
			{
                Names.Add(name);

                await Clients.All.SendAsync("ReceiveName", name);
            }
		}

		public async Task GetName()
		{
			await Clients.All.SendAsync("ReceiveNames", Names);
		}

        public override async Task OnConnectedAsync()
        {
			ClientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

