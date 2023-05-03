using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public interface IOutputGetTickets
	{
		public void Initialize();
		public List<TicketDto> getTickets();
	}
}

