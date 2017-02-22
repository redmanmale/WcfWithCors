﻿using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Redmanmale.WcfWithCors.Cors
{
    public class EnableCorsBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var requiredHeaders = new Dictionary<string, string>
            {
                {"Access-Control-Allow-Origin", "*"},
                {"Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS"},
                {"Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization,kbn-version"}
            };
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomHeaderMessageInspector(requiredHeaders));
        }

        public void Validate(ServiceEndpoint endpoint) { }

        public override Type BehaviorType
        {
            get { return typeof(EnableCorsBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new EnableCorsBehavior();
        }
    }
}
