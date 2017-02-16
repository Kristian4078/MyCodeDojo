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
            TestObj obj = new TestObj()
            {      
                id = 8,    
                note = "Still Updating",
                note2 = "1234567890"
            };
            //DAL.Post<TestObj>(obj, "test_table");
            DAL.Put<TestObj>(obj, "id", "test_table");
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
    }

    class TestObj {  
        public int id { get; set; }
        public string note { get; set; }
        public string note2 { get; set; }
    }
}
