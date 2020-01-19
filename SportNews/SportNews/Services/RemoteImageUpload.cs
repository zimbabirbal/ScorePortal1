using System;
using System.Collections.Generic;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Threading.Tasks;
using System.IO;

namespace SportNews.Services
{
    public class RemoteImageUpload
    {
        public async static Task<string> UploadImageToCloudinary(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;

            if (!File.Exists(filePath))
                throw new Exception($"File not found at path: {filePath}");

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("ScoresPortalImg", filePath),
                Folder = "ScoresPortal",
                Phash = true
            };
            var uploadResult = await Task.Run<ImageUploadResult>(() => App.CloudinaryInstance.Upload(uploadParams));
            //var a =UploadResult.Phash.;
            return uploadResult.SecureUri.AbsoluteUri;
        }
    }
}
