using System;
using minimalApi_test.Models;
using static minimalApi_test.Enums.Enum;

namespace minimalApi_test.Components
{
    //implementazione classe per l'accesso dei dati che estende l'interfaccia IDataManager
	public class DataManager : IDataManager
	{
        private List<Ticket> _ticketsList;
        private int _counter;

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
                _counter++;
                var t = new Ticket
                {
                    Id = $"TCKATMA{_counter.ToString().PadLeft(3,'0')}",
                    Description = $"Biglietto tratta {$"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}"}",
                    Price = _rnd.Next(),
                    Route = $"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}",
                    Aviable = _rnd.Next(2) == 1
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

