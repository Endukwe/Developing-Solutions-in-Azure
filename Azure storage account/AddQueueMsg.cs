...
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue; 

class Program
{
    static async Task SendMessageAsync(string newsMessage) //Method creates classes necessary to add mesage to the storage acc queue
{
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

    CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

    CloudQueue queue = queueClient.GetQueueReference("newsqueue");
    bool createdQueue = await queue.CreateIfNotExistsAsync();
    if (createdQueue)
    {
        Console.WriteLine("The queue of news articles was created.");
    }

    CloudQueueMessage articleMessage = new CloudQueueMessage(newsMessage);
    await queue.AddMessageAsync(articleMessage);
}

    static void Main(string[] args)
{
    if (args.Length > 0)
    {
        string value = String.Join(" ", args);
        SendMessageAsync(value).Wait();
        Console.WriteLine($"Sent: {value}");
    }
}

}