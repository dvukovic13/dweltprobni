using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using dwprbz.Data;
using Newtonsoft.Json;

namespace dwprbz.Controllers
{

    [ApiController]
    [Route("api/items")]
    public class ItemsController : Controller
    {

        [HttpGet]
        public string Get()
        {
            
            using (MySqlConnection conn = new MySqlConnection("server=localhost; user=root; database=petstoredemo; port=3306; password=admin"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM items", conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    string json = JsonConvert.SerializeObject(dt);

                    return json;

                }
                else return "";
                    



               /* while (reader.Read())
                {

                }*/

            }



         //   return
        }
    }
}
