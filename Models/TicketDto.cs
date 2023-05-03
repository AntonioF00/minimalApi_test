using System;
namespace minimalApi_test.Models
{
	public class TicketDto
	{
		public string  TicketId				{ get; set; }
		public string  TicketDescription	{ get; set; }
		public string  Route				{ get; set; }
		public decimal Price				{ get; set; }
	}
}

