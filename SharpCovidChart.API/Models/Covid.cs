using System;
namespace SharpCovidChart.API.Models
{
	public enum ECity
	{
		Istanbul = 1,
		Ankara,
		Izmir,
		Konya,
		Sivas,
		Antalya
	}


	public class Covid
	{
		public int Id { get; set; }
		public ECity City { get; set; }
		public int Count { get; set; }
		public DateTime CovidDate { get; set; }
	}
}

