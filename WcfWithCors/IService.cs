using System.ServiceModel;
using System.ServiceModel.Web;

namespace Redmanmale.WcfWithCors
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "something", ResponseFormat = WebMessageFormat.Json)]
        string GetSomthing();

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }
}
