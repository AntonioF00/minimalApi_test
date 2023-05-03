using System;
namespace minimalApi_test.Models
{
	public class Ticket
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Route { get; set; }
		public bool Aviable { get; set; }
	}
}

