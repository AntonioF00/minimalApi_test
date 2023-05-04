using System;
namespace minimalApi_test.Models
{
	public class TicketDto
	{
		public string  TicketId				{ get; set; } // id ticket
		public string  TicketDescription	{ get; set; } // descrizione ticket
		public string  Route				{ get; set; } // partenza - destinazione 
		public decimal Price				{ get; set; } // prezzo

		public int	   Quantity				{ get; set; } // quantità disponibile
	}
}

