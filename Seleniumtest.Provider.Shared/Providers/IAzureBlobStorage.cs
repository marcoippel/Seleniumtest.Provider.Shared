namespace Seleniumtest.Provider.Shared.Providers
{
    public interface IAzureBlobStorage
    {
        void Save(string blobContainerName, byte[] file, string fileName, string contentType);

    }
}