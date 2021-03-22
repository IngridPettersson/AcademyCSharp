using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Models.ViewModels;

namespace WebAPI.Models
{
    public class PhotosService
    {
        IHttpClientFactory httpClient;

        public PhotosService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PhotosIndexVM[]> GetAllPhotos()
        {
            HttpClient client = httpClient.CreateClient();
            string url = "https://jsonplaceholder.typicode.com/photos";
            string json = await client.GetStringAsync(url);

            Photo[] photoArr = JsonConvert.DeserializeObject<Photo[]>(json);

            return photoArr
                .Select(o => new PhotosIndexVM
                {
                    Title = o.Title,
                    URL = o.Url
                })
                .ToArray();
        }
    }
}
