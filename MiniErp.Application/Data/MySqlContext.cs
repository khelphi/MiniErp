using Microsoft.Extensions.Options;
using MiniErp.Application.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Data
{
    public class MySqlContext
    {

        private MySqlConnection connection;

        /*
        //criando o Construtor
        public MySqlContext(IOptions<AppConnectionSettings> appSettings)
        {
            connectionString = AppSettings.MySqlConnection;
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        */

        public MySqlConnection conexao()
        {
            connection = new MySqlConnection(AppSettings.MySqlConnection);
            connection.Open();
            return connection;
        }

    }
}
