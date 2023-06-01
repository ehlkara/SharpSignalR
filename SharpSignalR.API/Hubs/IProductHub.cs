using System;
using SharpSignalR.API.Models;

namespace SharpSignalR.API.Hubs
{
	public interface IProductHub
	{
		Task ReceiveProduct(Product p);
	}
}

