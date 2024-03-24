using System.Security.Claims;
using authority;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Endpoints
{
    public static class ImagesEndpoint
    {
        private static string ImagesPath { get; set; } = "";
        private static string APIUrl { get; set; } = "";
        public static void MapImagesApi(this RouteGroupBuilder group, string imagesPath, string apiUrl)
        {
            ImagesPath = imagesPath;
            APIUrl = apiUrl;
            group.MapPost("/", UploadImage);
        }

        private static async Task<Ok<string>> UploadImage(ClaimsPrincipal claimsPrincipal, [FromForm] IFormFile file)
        {
            var user = claimsPrincipal.GetUser();
            var filename = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
            var path = Path.Combine(ImagesPath, user.Guid.ToString());
            Directory.CreateDirectory(path);

            var fileFinalAddress = Path.Combine(path, filename);
            using var stream = File.Create(fileFinalAddress);
            await file.CopyToAsync(stream);

            return TypedResults.Ok(APIUrl.TrimEnd('/') + "/" + fileFinalAddress.TrimStart('/'));
        }
    }
}