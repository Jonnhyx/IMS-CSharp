using System.Data.OleDb;
using System.IO;

namespace AccesoDatos
{
    public abstract class ConnectionToOleDb
    {
        private readonly string connectionString;
        public ConnectionToOleDb()
        {
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database.accdb;";
            //connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\jontn\\Documents\\Database.accdb;";
        }
        protected OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }
    }
}
