using System.ServiceModel;

namespace Redmanmale.WcfWithCors
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class Service : IService
    {
        public string GetSomthing()
        {
            return "Hello!";
        }

        public void GetOptions() { }
    }
}