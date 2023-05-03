using System;
using minimalApi_test.Models;

namespace minimalApi_test.Components
{
	//interfaccia per l'accesso ai dati
	public interface IDataManager
	{
		public void Initializate();
		public List<Ticket> getTicketList();
		public void ChangeAviable(string a);
	}
}

