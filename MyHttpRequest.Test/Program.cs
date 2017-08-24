using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHettpRequest;

namespace MyHttpRequest.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = HttpHelper.HttpGetConnectToServer("http://192.168.20.234:9090", "");
            Console.Read();
            //192.168.20.234:9090
        }
    }
}
