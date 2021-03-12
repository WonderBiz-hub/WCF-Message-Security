using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using WcfServiceLibrary1;

namespace ServiceHostConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This is service host");

            try
            {
                ServiceHost host = new ServiceHost(typeof(SampleWCFServiceLibrary.Service1));
                host.Open();
                Console.WriteLine("Service Hosted Sucessfully");
                Console.Read();
                host.Close();
            }
            catch (Exception ex )
            {
                Console.WriteLine("Exception :- "+ex.Message.ToString());
            }

            Console.Read();

            

        }
    }
}
