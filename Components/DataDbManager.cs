using System;
using System.Data.Common;
using minimalApi_test.Models;
using Npgsql;

namespace minimalApi_test.Components
{
    public static class NpgsqlHelper
    {
        public static void OpenAndlog(this NpgsqlConnection connection)
        {
            connection.Open();

        }
    }




	public class DataDbManager : IDataManager
	{
        private IConfiguration _configuration;
        private NpgsqlConnection _connection;


		public DataDbManager(IConfiguration configuration)
		{
            _configuration = configuration;
		}

        public void GetConnection()
        {
            _connection = new NpgsqlConnection(_configuration["ConnectionString"]);
        }

             

        public void ChangeAviable(string TicketId)
        {
            _connection.Open();
            _connection.OpenAndlog();


            var command = new NpgsqlCommand();

            command.CommandText = $"UPDATE tickets SET aviable = false WHERE ticketId = {TicketId}";

            var res = command.ExecuteNonQuery();

            _connection.Close();
        }

        public void ChangeQuantity(string command, int qta, string ticketID)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> getTicketList()
        {
            throw new NotImplementedException();
        }

        public void Initializate()
        {
            throw new NotImplementedException();
        }
    }
}

