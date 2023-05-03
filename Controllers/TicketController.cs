using Microsoft.AspNetCore.Mvc;
using minimalApi_test.Components;
using minimalApi_test.Datas;
using minimalApi_test.Models;

namespace minimalApi_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IRequestsCounter _requestsCounter;
        private readonly IOutputError _outputError;
        private readonly IDataManager _dataManager;
        private readonly IConfiguration _configuration;
        private readonly IOutputGetTickets _outputGetTickets;
        private readonly IInputBuyTickets _inputBuyTicket;
        private readonly IOutputBuyTickets _outputBuyTickets;


        public TicketController(IConfiguration configuration,
                                IRequestsCounter requestsCounter,
                                IDataManager dataManager,
                                IOutputGetTickets outputGetTickets,
                                IInputBuyTickets inputBuyTicket,
                                IOutputBuyTickets outputBuyTickets,
                                IOutputError outputError)
        {
            _configuration = configuration;
            _requestsCounter = requestsCounter;
            _outputGetTickets = outputGetTickets;
            _outputBuyTickets = outputBuyTickets;
            _outputError = outputError;
            _inputBuyTicket = inputBuyTicket;
            _dataManager = dataManager;
        }


        //migliorare la gestione degli errori, con questi return non mi piace troppo

        [HttpGet]
        [Route("GetAllTickets")]
        public IEnumerable<object> GetAllTickets()
        {
            _requestsCounter.IncrementRequest();
            _dataManager.getTicketList();
            if (_dataManager.getTicketList().Count == 0)
                return _outputError.getError("ERROR_NOT_FOUND", "Errore nel caricamento dei dati.");
            else
                return _dataManager.getTicketList();
        }

        [HttpGet]
        [Route("GetTickets")]
        public IEnumerable<object> GetTickets()
        {
            _requestsCounter.IncrementRequest();
            if(_outputGetTickets.getTickets().Count == 0)
                return _outputError.getError("ERROR_NOT_AVIABLE", "Non ci sono biglietti disponibili.");
            else
                return _outputGetTickets.getTickets();
        }

        [HttpPost]
        [Route("BuyTicket/{id}/{qta}")]
        public IEnumerable<object> BuyTicket(string id, int qta)
        {
            _requestsCounter.IncrementRequest();
            _inputBuyTicket.searchTicket(id, qta);
            if(_inputBuyTicket.getTicketsList().Count == 0)
                return _outputError.getError("ERROR_TICKETID", "Non ci sono biglietti corrispondenti a quell'id.");
            else     
                return _inputBuyTicket.getTicketsList();
        }
    }
}

