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
        private readonly DbController _dbController;
        private readonly string _connectionString;
        private readonly IRequestsCounter _requestsCounter;
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
                                IOutputBuyTickets outputBuyTickets)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _dbController = new DbController(_connectionString);
            _requestsCounter = requestsCounter;
            _outputGetTickets = outputGetTickets;
            _outputBuyTickets = outputBuyTickets;
            _inputBuyTicket = inputBuyTicket;
            _dataManager = dataManager;
        }

        [HttpGet]
        [Route("GetAllTickets")]
        public IEnumerable<Ticket> GetAllTickets()
        {
            _requestsCounter.IncrementRequest();
            return _dataManager.getTicketList();
        }

        [HttpGet]
        [Route("GetTickets")]
        public IEnumerable<TicketDto> GetTickets()
        {
            _requestsCounter.IncrementRequest();
            return _outputGetTickets.getTickets();
        }

        [HttpPost]
        [Route("BuyTicket/{id}/{qta}")]
        public IEnumerable<object> BuyTicket(string id, int qta)
        {
            _requestsCounter.IncrementRequest();
            _inputBuyTicket.searchTicket(id, qta);
            return _inputBuyTicket.getTicketsList();
        }
    }
}

