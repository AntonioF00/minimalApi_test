using System.Data.Common;

namespace minimalApi_test.Datas
{
    public class DbController
    {
        private readonly DbConnection _connection;
        public DbController(string connectionSring)
        {
            _connection = ConnectionFactory.GetConnection(0, connectionSring);
        }



    }
}
