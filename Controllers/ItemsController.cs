using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using dwprbz.Data;

namespace dwprbz.Controllers
{

    [ApiController]
    [Route("api/items")]
    public class ItemsController : Controller
    {

            
        [HttpGet]
        public string Get()
        {
            //MyDbContext myDbContext = new MyDbContext();
            MyDbContext myDbContext = MyDbContext.Instance;
            MySqlConnection connection = myDbContext.connection;

            if(connection != null && connection.State == ConnectionState.Closed)
                myDbContext.connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM items", connection);
            MySqlDataReader reader = cmd.ExecuteReader();


            using(connection){
                using(reader){
                    if(reader.HasRows){
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        string json = JsonConvert.SerializeObject(dt);
                        
                        return json;
                    }
                    else return "";
                }
            }

            /*if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);

                string json = JsonConvert.SerializeObject(dt);
                
                reader.Close();

                if(connection.State == ConnectionState.Open)
                    connection.Close();

                
                
                return json;

            }
            else return "";*/





            /*using (MySqlConnection conn = new MySqlConnection("server=localhost; user=root; database=petstoredemo; port=3306; password=admin"))
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
                    


            }*/



            //   return
        }
    }
}
