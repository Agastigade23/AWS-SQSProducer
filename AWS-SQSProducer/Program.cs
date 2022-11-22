using Amazon.SQS;
using EventModel;
using System.Text.Json;

namespace AWS_SQSProducer
{
    public class Program
    {
        private static int i = 0;
        static async Task Main(string[] args)
        {
           
            if (i == 0)
                i = 1;
            else
                i++;
            //var message = "New Message for " + DateTime.Now.ToString();
            Random rnd = new();
            int randomnumber = rnd.Next(1, 50);
            var UpdateEventsobj = new UpdateEvent
            {
                EventId = i,
                Event = "Update - " + i,
                FeedEventName = "A",
                stationTime = DateTime.UtcNow.ToString(),
                SessionID = Guid.NewGuid().ToString(),
            };

            for (int i = 0; i < randomnumber; i++)
            {
                UpdateEventsobj.energy = (float)i;
            }
            string jsonString = JsonSerializer.Serialize(UpdateEventsobj);

            SQSMessageProducer sqsMessageProducer = new SQSMessageProducer();

            await sqsMessageProducer.Send(jsonString);

            Console.WriteLine("Message Sent: " + jsonString);
        }
    }
}