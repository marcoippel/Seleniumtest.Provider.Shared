using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Seleniumtest.Provider.Shared.Providers
{
    public class AzureBlobStorage : IAzureBlobStorage
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobStorage"/> class.
        /// </summary>
        /// <exception cref="System.Exception">There is in the appsettings no key found with name: StorageConnectionString</exception>
        public AzureBlobStorage()
        {
            string connectionString = ConfigurationManager.AppSettings["AzureBlob:StorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new NullReferenceException("There is in the appsettings no key found with name: AzureBlob:StorageConnectionString");
            }

            CloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        }
        
       
        public void Save(string blobContainerName, byte[] file, string fileName, string contentType)
        {
            CloudBlobClient blobClient = CloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(blobContainerName);
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            blockBlob.Properties.ContentType = contentType;
            blockBlob.UploadFromByteArray(file, 0, file.Length);
        }
    }
}
