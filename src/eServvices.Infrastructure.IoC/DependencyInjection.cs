using eServices.Infrastrcutre.Messaging.Core.Bus;
using eServices.Infrastructure.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eServvices.Infrastructure.IoC
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
