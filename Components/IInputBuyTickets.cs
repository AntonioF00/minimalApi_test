using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IInputBuyTickets
	{
		public TicketDto GetTicketDto();
		public void searchTicket(string id, int qta);
		public List<object> getTicketsList();
	}
}

