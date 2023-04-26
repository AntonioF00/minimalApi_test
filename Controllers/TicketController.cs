using Microsoft.AspNetCore.Mvc;
using minimalApi_test.Data;
using minimalApi_test.Models;
using static minimalApi_test.Enum.Enum;

namespace minimalApi_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly Random _rnd;
        private readonly DbController _dbController;
        private readonly string _connectionString;
        private List<Ticket> _tickets;

        public TicketController(IConfiguration configuration)
		{
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbController = new DbController(_connectionString);
            _tickets = new List<Ticket>();
            _rnd = new Random();
            Init();
		}

        [HttpGet(Name = "GetTicket/{id}")]
        public IEnumerable<Ticket> GetId(Guid id)
        {
            return _tickets.FindAll(x => x.id.Equals(id)).ToList();
        }

        [HttpGet(Name = "GetTicket")]
        public IEnumerable<Ticket> Get()
        {
            return _tickets.ToList();
        }

        [HttpGet(Name = "BuyTicket/{id}")]
        public IEnumerable<Ticket> Buy(Guid id)
        {
            return _tickets.FindAll(x => x.aviable == false).ToList();
        }

        public void Init()
        {
            for(int i = 0; i < 10; i++)
            {
                var t = new Ticket
                {
                    id = new Guid(),
                    name = $"TICKET-{i}",
                    price = _rnd.NextDouble(),
                    route = $"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}"
                };
                _tickets.Add(t);
            }
        }
    }
}

