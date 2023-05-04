using Microsoft.AspNetCore.Mvc;
using minimalApi_test.Components;
using minimalApi_test.Datas;
using minimalApi_test.Models;

namespace minimalApi_test.Controllers
{
    //controller che esporrà le API del progetto
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        //dichiarazione delle variabili locali
        private readonly IRequestsCounter _requestsCounter;     //Interfaccia IRequestCounter
        private readonly IOutputError _outputError;             //Interfaccia IOutputError
        private readonly IDataManager _dataManager;             //Interfaccia IDataManager
        private readonly IConfiguration _configuration;         //Interfaccia IConfiguration
        private readonly IOutputGetTickets _outputGetTickets;   //Interfaccia IOutputGetTickets
        private readonly IInputBuyTickets _inputBuyTicket;      //Interfaccia IInputBuyTickets
        private readonly IOutputBuyTickets _outputBuyTickets;   //Interfaccia IOutputBuyTickets

        public TicketController(IConfiguration configuration,
                                IRequestsCounter requestsCounter,
                                IDataManager dataManager,
                                IOutputGetTickets outputGetTickets,
                                IInputBuyTickets inputBuyTicket,
                                IOutputBuyTickets outputBuyTickets,
                                IOutputError outputError)
        {
            //inizializzo le variabili locali
            _configuration = configuration;
            _requestsCounter = requestsCounter;
            _outputGetTickets = outputGetTickets;
            _outputBuyTickets = outputBuyTickets;
            _outputError = outputError;
            _inputBuyTicket = inputBuyTicket;
            _dataManager = dataManager;
        }

        //API che restituisce tutti i ticket senza tenere conto dello stato di disponibilità
        //gli errori verranno gestiti tramite l'oggetto OutputError
        [HttpGet]
        [Route("GetAllTickets")]
        public IEnumerable<object> GetAllTickets()
        {
            _requestsCounter.IncrementRequest();
            var res = _dataManager.getTicketList();
            if (res.Count == 0)
                return _outputError.getError("ERROR_NOT_FOUND", "Errore nel caricamento dei dati.");
            else
                return res;
        }

        //API che restituisce tutti i ticket la cui disponibilità è pari a true
        //gli errori verranno gestiti tramite l'oggetto OutputError
        [HttpGet]
        [Route("GetTickets")]
        public IEnumerable<object> GetTickets()
        {
            _requestsCounter.IncrementRequest();
            var res = _outputGetTickets.getTickets();
            if (res.Count == 0)
                return _outputError.getError("ERROR_NOT_AVIABLE", "Non ci sono biglietti disponibili.");
            else
                return res;
        }

        //API che in base ai valori in ingresso id, qta, restituisce il biglietto ed il relativo costo
        //gli errori verranno gestiti tramite l'oggetto OutputError
        [HttpPost]
        [Route("GetTickets/{id}/{qta}")]
        public IEnumerable<object> BuyTicket(string id, int qta)
        {
            _requestsCounter.IncrementRequest();
            _inputBuyTicket.searchTicket(id, qta);
            var res = _inputBuyTicket.GetTicketDto();
            if (!string.IsNullOrWhiteSpace(res.TicketId))
            {
                var r = _inputBuyTicket.getTicketsList();
                if (r.Count == 0)
                    return _outputError.getError("ERROR_TICKETID", "Non ci sono biglietti corrispondenti a quell'id.");
                else     
                    return r;
            }
            else
            {
                return _outputError.getError("ERROR_QUANTITY", "Non ci sono biglietti a sufficenza per la quantità indicata.");
            }
        }
    }
}