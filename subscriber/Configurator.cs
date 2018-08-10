using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using GreenPipes;

namespace Atabareh.Samples.y2018.MassTransitWithContainer.BusService
{
    public static class Configuarator
    {
        public static IBusControl ConfiugreBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.UseRetry(r =>
                {
                    r.Handle<RabbitMqConnectionException>();
                    r.Interval(5, TimeSpan.FromSeconds(30));
                });
                var host = cfg.Host(new Uri(BusService.Constants.RabbitMqUri), hst =>
                {
                    hst.Username(BusService.Constants.Username);
                    hst.Password(BusService.Constants.Password);
                });
                registrationAction?.Invoke(cfg, host);
            });
        }

    }
}