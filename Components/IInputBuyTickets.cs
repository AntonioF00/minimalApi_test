using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IInputBuyTickets
	{
		/// <summary>
		/// Metodo per ottenere il biglietto
		/// </summary>
		/// <returns>TicketDto</returns>
		public TicketDto GetTicketDto();
		/// <summary>
		/// Metodo per cercare il biglietto all'interno
		/// dei biglietti disponibili nel sistema
		/// </summary>
		/// <param name="id">TicketId del biglietto</param>
		/// <param name="qta">Quantità del biglietto</param>
		public void searchTicket(string id, int qta);
		/// <summary>
		/// Ottenere la response dell'acquisto
		/// </summary>
		/// <returns>List<object></returns>
		public List<object> getTicketsList();
	}
}

