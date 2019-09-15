using System.Data.OleDb;

namespace AccesoDatos
{
    public abstract class ConnectionToOleDb
    {
        private readonly string connectionString;
        public ConnectionToOleDb()
        {
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\jontn\\Documents\\Database.accdb;";
        }
        protected OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }
    }
}
