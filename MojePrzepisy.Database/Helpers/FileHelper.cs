using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MojePrzepisy.Database.Helpers
{
    public static class FileHelper
    {
        private static string _connectionString = @"Your Connection string";
        private static string _containerName = "ContainerName";

        public static async Task<string> UploadImage(IFormFile file)
        {
            var guid = Guid.NewGuid();
            string FileName = guid + "-" + file.FileName;
            BlobContainerClient blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(FileName); //file.FileName
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            //zwraca full path do azure blob
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<bool> DeleteImage(string ImageName)
        {
            try
            {
                BlobContainerClient blobServiceClient = new BlobContainerClient(_connectionString, _containerName);
                BlobClient blobClient = blobServiceClient.GetBlobClient(ImageName);
                await blobClient.DeleteIfExistsAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static async Task<string> EditImage(IFormFile NewFile, string OldFileName)
        {
            try
            {
               var IsImageDeleted = await DeleteImage(OldFileName);
               if (IsImageDeleted == true)
               {
                   var guid = Guid.NewGuid();
                   string FileName = guid + "-" + NewFile.FileName;
                   BlobContainerClient blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
                   BlobClient blobClient = blobContainerClient.GetBlobClient(FileName); 
                   var memoryStream = new MemoryStream();
                   await NewFile.CopyToAsync(memoryStream);
                   memoryStream.Position = 0;
                   await blobClient.UploadAsync(memoryStream);
                   //zwraca full path do azure blob
                   return blobClient.Uri.AbsoluteUri;
               }
               else
               {
                   return "Error";
               }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
