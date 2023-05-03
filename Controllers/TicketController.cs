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

        public TicketController(IConfiguration configuration, IRequestsCounter requestsCounter, IDataManager dataManager)
		{
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _dbController = new DbController(_connectionString);
            _requestsCounter = requestsCounter;
            _dataManager = dataManager;
		}

        [HttpGet]
        [Route("GetTickets")]
        public IEnumerable<Ticket> GetTicket()
        {
            _requestsCounter.IncrementRequest();
            return _dataManager.getTicketList();
        }

    }
}

