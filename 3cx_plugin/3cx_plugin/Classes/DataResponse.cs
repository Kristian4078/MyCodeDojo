using _3cx_plugin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cx_plugin.Classes
{
    class DataResponse<T> : IDataResponse<T> where T : class
    {
        public List<T> Data { get; set; }
    }
}
