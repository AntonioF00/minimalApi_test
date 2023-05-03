using System;
using minimalApi_test.Loggers;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public class InputBuyTickets : IInputBuyTickets
	{
		private readonly IOutputGetTickets _outputGetTickets;
        private readonly IOutputBuyTickets _outputBuyTickets;
        private string _ticketId;
		private int _quantity;
        private TicketDto _ticket;
        private List<object> _ticketBuyList;


		public InputBuyTickets(IOutputGetTickets outputGetTickets,
                              IOutputBuyTickets outputBuyTicket)
		{
			_outputGetTickets = outputGetTickets;
            _outputBuyTickets = outputBuyTicket;
		}

        public TicketDto GetTicketDto()
        {
            return _ticket;
        }

        public List<object> getTicketsList()
        {
            return _ticketBuyList;
        }

        public void searchTicket(string id, int qta)
        {
            _ticketId = id;
            _quantity = qta;

            List<TicketDto> list = _outputGetTickets.getTickets();

            list.ForEach(e => {
                                    try
                                    {
                                        if (e.TicketId.Equals(_ticketId))
                                            _ticket = e;
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.Log(ex.Message);
                                    }    
                                });

            _ticketBuyList = _outputBuyTickets.GetTicket(_ticket,_quantity);

            //impostare il ticket non avaiable
        }
    }
}

