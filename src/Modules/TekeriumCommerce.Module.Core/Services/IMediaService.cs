﻿using System.IO;
using System.Threading.Tasks;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Services
{
    public interface IMediaService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string getThumbnailUrl(Media media);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(string fileName);
    }
}