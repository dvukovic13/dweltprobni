using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwprbz.Data
{
    public class MyDbContext
    {
        public MySqlConnection connection { get; set; }

        public MyDbContext(IConfiguration configuration)
        {
            connection = new MySqlConnection(configuration.GetConnectionString("Default"));
        }


        public static MyDbContext Instance { get; set; }

    }
}
