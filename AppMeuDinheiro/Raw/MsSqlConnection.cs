using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMeuDinheiro.Raw
{
    internal class MsSqlConnection
    {
        private SqlConnection Cnn { get; set; }

        public void Open()
        {
            string connectionString = "Server=localhost;User Id=sa;Password=blog_6109;Database=MeuDinheiro;TrustServerCertificate=True;";

            Cnn = new SqlConnection(connectionString);

            Cnn.Open();
        }

        public void Close()
        {
            Cnn.Close();
        }
    }
}
