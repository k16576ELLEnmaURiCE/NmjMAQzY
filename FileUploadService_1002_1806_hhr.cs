// 代码生成时间: 2025-10-02 18:06:47
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFileUploadApp
{
    public class FileUploadService
    {
        private const string UploadUrl = "https://yourserver.com/upload"; // Replace with your actual upload URL

        /// <summary>
        /// Uploads the selected file to the server.
        /// </summary>
        /// <param name="fileStream">The file stream to be uploaded.</param>
        /// <param name="fileName">The name of the file to be uploaded.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                // Create a new HTTP client
                using (var httpClient = new HttpClient())
                {
                    // Prepare the multipart/form-data content
                    using (var content = new MultipartFormDataContent())
                    {
                        // Add the file to the content
                        content.Add(new StreamContent(fileStream), "file", fileName);

                        // Send a POST request to the server with the file
                        var response = await httpClient.PostAsync(UploadUrl, content);

                        // Check if the response is successful
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"Upload failed with status code: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the file upload
                Debug.WriteLine($"Error occurred while uploading file: {ex.Message}");
                throw;
            }
        }
    }
}
