using Microsoft.AspNetCore.Mvc;
using minimalApi_test.Datas;
using minimalApi_test.Models;
using static minimalApi_test.Enums.Enum;

namespace minimalApi_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly DbController _dbController;
        private readonly string _connectionString;
        private List<Ticket> _tickets;

        public TicketController(IConfiguration configuration)
		{
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbController = new DbController(_connectionString);
            _tickets = new List<Ticket>();
            Init();
		}

        [HttpGet]
        [Route("GetTicketId/{id}")]
        public IEnumerable<Ticket> GetTid(Guid Id)
        {
            Ticket t = _tickets.Find(x => x.id.Equals(Id));
            List<Ticket> tl = new List<Ticket>();
            tl.Add(t);
            return tl;
        }

        [HttpGet]
        [Route("GetTickets")]
        public IEnumerable<Ticket> GetT() => _tickets.ToArray();

        [HttpGet]
        [Route("GetNonAviableTickets")]
        public IEnumerable<Ticket> GetNonAviableT() => _tickets.FindAll(x => x.aviable == false).ToList();

        [HttpGet]
        [Route("GetAviableTickets")]
        public IEnumerable<Ticket> GetAviableT() => _tickets.FindAll(x => x.aviable == true).ToList();

        [HttpGet]
        [Route("BuyTicket/{id}")]
        public IEnumerable<Ticket> BuyId(Guid id)
        {
            _tickets.Find(x => x.id.Equals(id)).aviable = false;
            return _tickets.FindAll(x => x.aviable == false).ToList();
        }

        public void Init()
        {
            var _rnd = new Random(DateTime.Now.Microsecond);
            for (int i = 0; i < 10; i++)
            {
                var t = new Ticket
                {
                    id = Guid.NewGuid(),
                    name = $"TICKET-{i}",
                    price = _rnd.NextDouble(),
                    route = $"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}"
                };
                _tickets.Add(t);
            }
        }
    }
}

