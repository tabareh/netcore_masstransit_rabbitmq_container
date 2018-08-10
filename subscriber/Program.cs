using System;
using Atabareh.Samples.y2018.MassTransitWithContainer.BusService;
using MassTransit;
using GreenPipes;

namespace tabareh.Samples.y2018.MassTransitWithContainer.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Configuarator.ConfiugreBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, Constants.QueueName, e =>
                {
                    e.UseRetry(r => r.Interval(5, TimeSpan.FromSeconds(30)));
                    e.Consumer<MessaegEventConsumer>();
                });
            });
            bus.Start();
            while (true) ;
        }
    }
}
