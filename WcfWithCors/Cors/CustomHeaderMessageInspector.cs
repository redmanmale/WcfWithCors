using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Redmanmale.WcfWithCors.Cors
{
    public class CustomHeaderMessageInspector : IDispatchMessageInspector
    {
        private readonly IReadOnlyDictionary<string, string> _requiredHeaders;

        public CustomHeaderMessageInspector(Dictionary<string, string> headers)
        {
            _requiredHeaders = headers ?? new Dictionary<string, string>();
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
            foreach (var item in _requiredHeaders)
            {
                httpHeader?.Headers.Add(item.Key, item.Value);
            }
        }
    }
}
