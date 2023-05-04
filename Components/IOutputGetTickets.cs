using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IOutputGetTickets
	{
		/// <summary>
		/// Metodo per inizializzare la lista dei ticket disponibili
		/// </summary>
		public void Initialize();
		/// <summary>
		/// Metodo per ottenere la lista dei ticket disponibili
		/// </summary>
		/// <returns>List<TicketDto> pari alla lista dei ticket disponibili </returns>
		public List<TicketDto> getTickets();
	}
}

