using System;
namespace minimalApi_test.Models
{
	public class Ticket
	{
		public Guid id { get; set; }
		public string name { get; set; }
		public double price { get; set; }
		public string route { get; set; }
		public bool aviable { get; set; }

	}
}

