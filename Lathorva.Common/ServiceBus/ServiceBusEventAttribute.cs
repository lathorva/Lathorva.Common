using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.ServiceBus
{
    public class ServiceBusEventAttribute : Attribute
    {
        public string Name { get; }
        public ServiceBusEventAttribute(string name)
        {
            Name = name;
        }
    }
}
