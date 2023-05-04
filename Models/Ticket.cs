using System;
namespace minimalApi_test.Models
{
	public class Ticket
	{
		public string  Id			{ get; set; } // ticket id
		public string  Description  { get; set; } // descrizione ticket
		public decimal Price		{ get; set; } // prezzo ticket
		public string  Route		{ get; set; } // partenza - destinazione
		public bool    Aviable		{ get; set; } // disponibilità ticket
		
		public int     Quantity		{ get; set; } // quantità disponibile ticket
	}
}

