using Microsoft.Azure.Cosmos;
using System;
using CosmosDbHelper;
using Models;
using System.Threading.Tasks;

namespace CosmosDbCruds
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The Azure Cosmos DB endpoint for running this sample.
            string EndpointUri = "";
            // The primary key for the Azure Cosmos account.
            string PrimaryKey = "";

            // The name of the database and container we will create
            string databaseId = "MyProductCatalog";
            string containerId = "Products";

            // The Cosmos client instance
            CosmosClient cosmosClient = new CosmosClient(EndpointUri,PrimaryKey);

            // The database we will create
            Database database = Task.Run(async () => await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId)).Result;

            // The container we will create.
            Container container = Task.Run(async () => await database.CreateContainerIfNotExistsAsync(containerId, "/Id")).Result;

            CosmosDbClient<Product> mClient = new CosmosDbClient<Product>(cosmosClient, databaseId, containerId);

            Product product = new Product
            {
                Id = "1",
                Product_Name = "Football",
                Product_Description = "A grey foorball with black spots",
                Product_Price = "15.00 USD",
                Product_Availability = "Unavailable"
            };

            await mClient.AddItemAsync(product);
            Console.WriteLine($"Added product: {product}");
        }
    }
}
