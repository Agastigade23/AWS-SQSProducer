using Amazon.Runtime;
using Amazon.SQS.Model;
using Amazon.SQS;
using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_SQSProducer
{
    public class SQSMessageProducer
    {
        public SQSMessageProducer()
        {

        }

        public async Task Send(String message)
        {
            string accessKey = "AKIAYNE53BNIXEZXR37W";
            string secret = "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";
            string queueUrl = "https://sqs.us-east-1.amazonaws.com/578004126545/Agasti-Queue";

            BasicAWSCredentials creds = new BasicAWSCredentials(accessKey, secret);

            SendMessageRequest sendMessageRequest = new SendMessageRequest(queueUrl, message);

            var sqsClient = new AmazonSQSClient(creds, RegionEndpoint.USEast1);

            await sqsClient.SendMessageAsync(sendMessageRequest);

        }
    }
}
