using System;
using minimalApi_test.Loggers;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	public class InputBuyTickets : IInputBuyTickets
	{
		private readonly IOutputGetTickets _outputGetTickets;
        private readonly IOutputBuyTickets _outputBuyTickets;
        private readonly IDataManager _dataManager;
        private string _ticketId;
		private int _quantity;
        private TicketDto _ticket;
        private List<object> _ticketBuyList;


		public InputBuyTickets(IOutputGetTickets outputGetTickets,
                              IOutputBuyTickets outputBuyTicket,
                              IDataManager dataManager)
		{
			_outputGetTickets = outputGetTickets;
            _outputBuyTickets = outputBuyTicket;
            _dataManager = dataManager;
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

            //imposto una variabile di appoggio per i ticket disponibili
            List<TicketDto> list = _outputGetTickets.getTickets();

            //cerco il ticket scelto
            list.ForEach(e => {
                try
                {
                    //se lo trovo lo imposto in una variabile
                    if (e.TicketId.Equals(_ticketId))
                    {
                        if(e.Quantity <= _quantity)
                        {
                            _ticket = e;
                            _dataManager.ChangeAviable(_ticketId);
                            _dataManager.ChangeQuantity("D", _quantity, _ticketId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                }    
            });

            //salvo il risultato della richiesta in una lista che sarà il mio
            //valore di ritorno
            _ticketBuyList = _outputBuyTickets.GetTicket(_ticket,_quantity);
        }
    }
}

