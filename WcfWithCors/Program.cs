using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Redmanmale.WcfWithCors.Cors;

namespace Redmanmale.WcfWithCors
{
    internal static class Program
    {
        internal static void Main()
        {
            var service = new Service();
            var host = new WebServiceHost(service);
            host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), new Uri("http://127.0.0.1:8090"));
            foreach (var endpoint in host.Description.Endpoints)
            {
                endpoint.Behaviors.Add(new EnableCorsBehavior());
            }
            host.Open();

            Console.WriteLine("Up and running");
            Console.ReadKey();
        }
    }
}
