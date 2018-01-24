using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lathorva.Common.ServiceBus
{
    /// <summary>
    /// Generic method for triggering event into service bus logic
    /// </summary>
    public interface IServiceBusEventTrigger
    {
        Task TriggerEventAsync(string name, object data);
    }
}
