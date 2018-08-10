using System;
using System.Threading.Tasks;
using Atabareh.Samples.y2018.MassTransitWithContainer.BusService;
using MassTransit;
using System.Linq;

namespace Atabareh.Samples.y2018.MassTransitWithContainer.publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var endPoint = Task.Run(async () => await initiateEndPionts()).Result;
            while (true)
            {
                Console.Write("Enter a message to be sent:");
                var message = Console.ReadLine();
                endPoint.Send<MessageEvent>(new MessageEvent(message, DateTime.Now));
            }
        }

        public static async Task<ISendEndpoint> initiateEndPionts()
        {
            // var rabbitUrl = "rabbitmq://localhost/";
            var rabbitUrl = Constants.RabbitMqUri;

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(rabbitUrl), hst =>
                {
                    hst.Username(BusService.Constants.Username);
                    hst.Password(BusService.Constants.Password);
                });
            }); ;
            var eventUri = new Uri($"{rabbitUrl}{Constants.QueueName}");
            var endPoint = await bus.GetSendEndpoint(eventUri);
            return endPoint;
        }
    }
}
