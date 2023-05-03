using System;
namespace minimalApi_test.Models
{
	public class Ticket
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Route { get; set; }
		public bool Aviable { get; set; }
	}
}

