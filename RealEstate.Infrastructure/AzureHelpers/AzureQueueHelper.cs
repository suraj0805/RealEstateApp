using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.AzureHelpers
{
    public static class AzureQueueHelper
    {
        public static void AddAzureQueueMessage(string message) {
            string storageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            string queueName = ConfigurationManager.AppSettings["StorageQueueName"];

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting(storageConnectionString));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            // Create queue
            queue.AddMessage(new CloudQueueMessage(message));
        }
    }
}
