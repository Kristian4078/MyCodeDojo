using _3cx_plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL data = new DAL();
            City brum = new City()
            {
                city_id = 601,
                city = "Birmingham",
                country_id = 102,
                last_update = DateTime.Now
            };
            data.Post<City>(brum);
           // var actor = data.Get<Actor>("/get/actor/actor_id=200");
            Console.ReadLine();
        }
    }
    class Actor {
        public int actor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime last_update { get; set; }
    }

    class Post {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    class City
    {
        public int city_id { get; set; }
        public string city { get; set; }
        public int country_id { get; set; }
        public DateTime last_update { get; set; }
    }
}
