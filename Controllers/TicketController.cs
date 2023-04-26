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
		}

        [HttpGet(Name = "GetTicket/{id}")]
        public IEnumerable<Ticket> GetId(Guid id)
        {
            List<Ticket> list = (List<Ticket>)Get();
            return list.FindAll(x => x.id.Equals(id));
        }

        [HttpGet(Name = "GetTicket")]
        public IEnumerable<Ticket> Get()
        {
            for (int i = _tickets.Count; i < 5; i++)
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
            return _tickets.ToList();
        }

        public T RandomEnumValue<T>()
        {
            var v = Citys.GetValues(typeof(T));
            return (T)v.GetValue(_rnd.Next(v.Length));
        }
    }
}

