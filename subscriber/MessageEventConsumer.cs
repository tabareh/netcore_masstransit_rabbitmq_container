using MassTransit;
using System.Threading.Tasks;
using System;
using Atabareh.Samples.y2018.MassTransitWithContainer.BusService;

namespace tabareh.Samples.y2018.MassTransitWithContainer.Subscriber
{
    public class MessaegEventConsumer : IConsumer<MessageEvent>
    {
        public Task Consume(ConsumeContext<MessageEvent> context)
        {
            System.Console.WriteLine("*** Message Received ***");
            System.Console.WriteLine($"Event Text:{context.Message.EventText}");
            System.Console.WriteLine($"Event Time:{context.Message.EventTime}");
            Console.WriteLine("Thred Id: (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");
            return Task.FromResult(0);
        }

    }
}
