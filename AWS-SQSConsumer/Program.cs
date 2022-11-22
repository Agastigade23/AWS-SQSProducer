namespace AWS_SQSConsumer
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            SQSMessageConsumer sqsConsumer = new SQSMessageConsumer();

            await sqsConsumer.Listen();
        }
    }
}