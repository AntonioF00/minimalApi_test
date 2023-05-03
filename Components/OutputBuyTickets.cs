using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public class OutputBuyTickets : IOutputBuyTickets
	{
        private string _ticketId;
        private decimal _payedAmout;

        public OutputBuyTickets() { }

        public List<object> GetTicket(TicketDto ticket, int quantity)
        {
            _ticketId = ticket.TicketId;
            _payedAmout = (ticket.Price * quantity);
            return new List<object>()
            {
                new Dictionary<string,object>()
                {
                    ["TicketId"] = _ticketId,
                    ["PayedAmount"] = _payedAmout
                }
            };
        }
    }
}

