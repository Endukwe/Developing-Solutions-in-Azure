using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
 
//Send an azure service bus queue message from a source component
namespace privatemessagesender
{
    class Program
    {
        const string ServiceBusConnectionString = " ";   //add a connection string 
        const string QueueName = " ";      //add the name of the queue 
        static IQueueClient queueClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Messages queue...");
            SendMessageAsync().GetAwaiter().GetResult();
            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendMessageAsync()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            try
            {
                string messageBody = " "; //Add the message being sent
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Sending message: {messageBody}");
                await queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await queueClient.CloseAsync();
        }
    }
}