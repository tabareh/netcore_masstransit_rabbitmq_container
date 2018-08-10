using System;

namespace Atabareh.Samples.y2018.MassTransitWithContainer.BusService
{
    public class MessageEvent
    {
        public MessageEvent(string message, DateTime dateTime)
        {
            this.EventText = message;
            this.EventTime = dateTime;
        }
        public string EventText { get; set; }
        public DateTime EventTime { get; set; }
    }
}