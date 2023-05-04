﻿using System;
using minimalApi_test.Loggers;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
    //Classe che si occupa dell'intera gestione d'acquisto d'uno o piu' biglietto
    //si preoccupa di cercare il biglietto, controllando se quest'utlimo esiste e
    //inoltre, controlla la possibilità d'acquisto sulla base delle quantità messe
    //a disposizione del biglietto stesso, interpella qualora ci fosse un esito positivo
    //la classe gestore delle informazioni per decurtare le quantità acquistate da quelle
    //totali
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
            foreach(var e in list)
            {
                try
                {
                    //se lo trovo lo imposto in una variabile
                    if (e.TicketId.Equals(_ticketId))
                    {
                        if(e.Quantity >= _quantity)
                        {
                            _ticket = e;
                            _dataManager.ChangeQuantity("D", _quantity, _ticketId);
                            _dataManager.ChangeAviable(_ticketId);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                }    
            }

            //salvo il risultato della richiesta in una lista che sarà il mio
            //valore di ritorno
            _ticketBuyList = _outputBuyTickets.GetTicket(_ticket,_quantity);
        }
    }
}

