using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IOutputBuyTickets
	{
		/// <summary>
		/// Metodo per ottenere la response inerente al pagamente del biglietto
		/// </summary>
		/// <param name="ticket">Biglietto da acquistare</param>
		/// <param name="quantity">Quantità da acquistare</param>
		/// <returns>List<object> </returns>
		public List<object> GetTicket(TicketDto ticket, int quantity);
	}
}

