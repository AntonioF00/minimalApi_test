using minimalApi_test.Components;
using minimalApi_test.Models;

namespace minimalApi_test.Datas
{
    public class OutputGetTickets : IOutputGetTickets
	{
        private List<TicketDto> _ticketsDtoList;
        private readonly IDataManager _dataManager;

		public OutputGetTickets(IDataManager dataManager)
		{
            _ticketsDtoList = new List<TicketDto>();
            _dataManager = dataManager;
            Initialize();
		}

        public List<TicketDto> getTickets()
        {
            return _ticketsDtoList;
        }

        public void Initialize()
        {
            List<Ticket> list = _dataManager.getTicketList();

            list.ForEach(e => {
                if(e.Aviable)
                    _ticketsDtoList.Add(new TicketDto
                    {
                        TicketId = e.Id,
                        Price = e.Price,
                        Route = e.Route,
                        TicketDescription = e.Description
                    });
            });
        }
    }
}

