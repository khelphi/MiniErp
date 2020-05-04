using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Settings
{
    public class AppSettings
    {
        public static readonly string MySqlConnection;
        public static readonly int MaxResultRegister;

        static AppSettings()
        {
            MySqlConnection = Environment.GetEnvironmentVariable("STR_CONN_MYSQL");
            MaxResultRegister = Convert.ToInt32(Environment.GetEnvironmentVariable("MAX_REG_RETURN"));
        }

    }
}
