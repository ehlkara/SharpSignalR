namespace SharpSignalR.API.Models
{
    public class Team
	{
		// team.users.add(
		public Team()
		{
			Users = new List<User>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}

