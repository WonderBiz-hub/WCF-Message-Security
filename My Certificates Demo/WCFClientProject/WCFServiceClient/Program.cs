using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi I am Client");

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logLocation = Path.Combine(executableLocation, "ClientLog.txt");
            
            ServiceReference1.Service1Client svcClient = null;
            try
            {
                svcClient = new ServiceReference1.Service1Client("NetTcpBinding_IService1");
                Console.WriteLine("Waiting for Service");

                svcClient.Open();

                Console.WriteLine("Service is opened for me");

                string fromService = svcClient.GetData(143);
                Console.WriteLine(fromService);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION :- "+ ex.Message.ToString());

                StringBuilder sbl = new StringBuilder();
                sbl.Append( DateTime.Now.ToString() + "\n EXCEPTION  :- " + ex.Message.ToString());
                sbl.Append( DateTime.Now.ToString() + "\n INNER EXCEPTION  :- " + ex.InnerException.ToString());
                sbl.Append(DateTime.Now.ToString() + "\n STACK TRACE  :- " + ex.StackTrace.ToString());

                File.AppendAllText(logLocation, sbl.ToString());

            }

            Console.Read();
            if (svcClient!=null)
            {
                svcClient.Close();
            }

        }
    }
}
