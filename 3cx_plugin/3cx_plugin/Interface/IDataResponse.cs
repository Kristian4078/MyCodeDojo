using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3cx_plugin.Interface
{
    interface IDataResponse<T> where T : class
    {
        List<T> Data { get; set; }
    }
}
