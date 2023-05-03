using System;
using minimalApi_test.Models;
using static minimalApi_test.Enums.Enum;

namespace minimalApi_test.Components
{
    //implementazione classe per l'accesso dei dati che estende l'interfaccia IDataManager
	public class DataManager : IDataManager
	{
        private List<Ticket> _ticketsList;

		public DataManager()
		{
            _ticketsList = new List<Ticket>();
            Initializate();
		}

        public void Initializate()
        {
            var _rnd = new Random(DateTime.Now.Microsecond);
            for (int i = 0; i < 10; i++)
            {
                var t = new Ticket
                {
                    Id = Guid.NewGuid(),
                    Name = $"TICKET-{i}",
                    Price = _rnd.Next(),
                    Route = $"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}"
                };
                _ticketsList.Add(t);
            }
        }

        public List<Ticket> getTicketList()
        {
            return _ticketsList;
        }
    }
}

