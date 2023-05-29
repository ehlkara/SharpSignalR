using System;
using Microsoft.AspNetCore.SignalR;

namespace SharpSignalR.API.Hubs
{
	public class MyHub:Hub
	{
		public static List<string> Names { get; set; } = new List<string>();

		public async Task SendName(string name)
		{
			Names.Add(name);

			await Clients.All.SendAsync("ReceiveName", name);
		}

		public async Task GetName()
		{
			await Clients.All.SendAsync("ReceiveNames", Names);
		}
	}
}

