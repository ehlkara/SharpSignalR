using System;
using Microsoft.AspNetCore.SignalR;

namespace SharpCovidChart.API.Hubs
{
	public class CovidHub : Hub
	{
		public async Task GetCovidList()
		{
			await Clients.All.SendAsync("ReceiveCovidList", "get to covid variables in service");
		}
	}
}

