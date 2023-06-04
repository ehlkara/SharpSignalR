using System;
using Microsoft.AspNetCore.SignalR;
using SharpCovidChart.API.Models;

namespace SharpCovidChart.API.Hubs
{
	public class CovidHub : Hub
	{
		private readonly CovidService _covidService;

        public CovidHub(CovidService covidService)
        {
            _covidService = covidService;
        }

        public async Task GetCovidList()
		{
			await Clients.All.SendAsync("ReceiveCovidList", _covidService.GetCovidChartList());
		}
	}
}

