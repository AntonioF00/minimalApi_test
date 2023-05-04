using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
    //Classe utilizzata per gestire la procedura di acquisto d'un biglietto,
    //sulla base del biglietto selezionato dall'utente tramite chiamata API
    //ritorna una response contenente il ticektId ed il prezzo che l'utene dovrà
    //pagare per acquistare il biglietto stesso, calcolato sulla base delle
    //quantità selezionate.
	public class OutputBuyTickets : IOutputBuyTickets
	{
        private string _ticketId;
        private decimal _payedAmout;

        public OutputBuyTickets() { }

        public List<object> GetTicket(TicketDto ticket, int quantity)
        {
            List<object> res = new List<object>();
            if(ticket != null)
            {
                _ticketId = ticket.TicketId;
                _payedAmout = (ticket.Price * quantity);
                res = new List<object>()
                {
                    new Dictionary<string,object>()
                    {
                        ["TicketId"] = _ticketId,
                        ["PayedAmount"] = _payedAmout
                    }
                };
            }
            return res;
        }
    }
}

