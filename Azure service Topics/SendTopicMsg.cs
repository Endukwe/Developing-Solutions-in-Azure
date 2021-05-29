using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace performancemessagesender
{
    class Program
    {
        const string ServiceBusConnectionString = ""; // add connection string
        const string TopicName = " "; //add topic ame
        static ITopicClient topicClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Performance topic...");
            SendMessageAsync().GetAwaiter().GetResult();
            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendMessageAsync()
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            try
            {
                string messageBody = " "; //add mesage
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Sending message: {messageBody}");
                await topicClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await topicClient.CloseAsync();
        }
    }
}