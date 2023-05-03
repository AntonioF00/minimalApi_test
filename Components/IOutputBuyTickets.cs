using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IOutputBuyTickets
	{
		public List<Object> GetTicket(TicketDto a, int b);
	}
}

