using eServices.Infrastrcutre.Messaging.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eServices.Infrastrcutre.Messaging.Core.Bus
{
    public interface IEventHandler
    {
        public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
        {
            Task Handle(TEvent @event);
        }

        public interface IEventHandler
        {

        }
    }
}
