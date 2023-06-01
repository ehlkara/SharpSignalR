using System;
using Microsoft.AspNetCore.SignalR;
using SharpSignalR.API.Models;

namespace SharpSignalR.API.Hubs
{
	public class ProductHub : Hub<IProductHub>
	{
		public async Task SendProduct(Product p)
		{
			await Clients.All.ReceiveProduct(p);
		}
	}
}

