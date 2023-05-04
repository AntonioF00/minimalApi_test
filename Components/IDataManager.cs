using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	//interfaccia per l'accesso ai dati
	public interface IDataManager
	{
		/// <summary>
		/// Metodo per inizializzare i dati all'interno del sistema
		/// </summary>
		public void Initializate();
		/// <summary>
		/// Metodo per ottenre la lista dei biglietti all'interno del sistema
		/// </summary>
		/// <returns>List<Ticket></returns>
		public List<Ticket> getTicketList();
		/// <summary>
		/// Metodo per cambiare qualora la quantità fosse 0 la dispobilità del biglietto
		/// </summary>
		/// <param name="TicketId">TicketId</param>
		public void ChangeAviable(string TicketId);
		/// <summary>
		/// Metodo per cambiare la quantità del biglietto
		/// </summary>
		/// <param name="command">"I" per aumentare, "D" per decrementare</param>
		/// <param name="qta">quantità </param>
		/// <param name="ticketID">ticket id</param>
		public void ChangeQuantity(string command, int qta, string ticketID);
	}
}

