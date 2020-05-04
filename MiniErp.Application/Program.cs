using MiniErp.Application.Settings;
using System;

namespace MiniErp.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"+ AppSettings.MySqlConnection);

        }
    }
}
