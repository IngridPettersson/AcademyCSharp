using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOwnAPI.Models
{

    public class ApiPhotosService
    {
        public List<Photo> apiPhotos = new List<Photo>
        {
            new Photo {AlbumId = 1,Id = 1,Title = "accusamus beatae ad facilis cum similique qui sunt", Url = "https://via.placeholder.com/600/92c952",ThumbnailUrl = "https://via.placeholder.com/150/92c952"},
            new Photo {AlbumId = 1,Id = 2,Title = "accusamus beatae ad facilis cum similique qui sunt", Url = "https://via.placeholder.com/600/771796",ThumbnailUrl = "https://via.placeholder.com/150/771796"},
            new Photo {AlbumId = 1,Id = 3,Title = "accusamus beatae ad facilis cum similique qui sunt", Url = "https://via.placeholder.com/600/24f355",ThumbnailUrl = "https://via.placeholder.com/150/24f355"},

        };

        internal Photo[] GetPhotosJson()
        {
            return apiPhotos.ToArray();
        }
    }
}
