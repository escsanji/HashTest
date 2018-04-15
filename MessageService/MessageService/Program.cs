using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:19000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.ReadLine();
            }
        }
    }
}
