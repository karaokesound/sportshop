using Sportshop.Domain.Models;

namespace Sportshop.Application.Services.Product
{
    public class ProductService : IProductService
    {
        public async Task<Guid> AppendThumbnailAndGetIdAsync(ThumbnailModel thumbnail, string productName)
        {
            thumbnail.Id = Guid.NewGuid();
            thumbnail.Content = thumbnail.Content;

            thumbnail.FileName = GenerateThumbnailFileName(productName, thumbnail.Id);

            string path = Path.Combine(@"C:\\Users\\karao\\source\\repos\\sportshop\\Sportshop.Persistence\\Thumbnails",
               thumbnail.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await thumbnail.Content.CopyToAsync(stream);
            }

            return thumbnail.Id;
        }

        public void DeleteThumbnail(Guid thumbnailId, string productName)
        {
            var fileName = GenerateThumbnailFileName(productName, thumbnailId);

            string filePathToDelete = Path.Combine(@"C:\\Users\\karao\\source\\repos\\sportshop\\
                                        Sportshop.Persistence\\Thumbnails", fileName);

            if (File.Exists(filePathToDelete))
            {
                File.Delete(filePathToDelete);
            }
        }

        private string GenerateThumbnailFileName(string productName, Guid thumbnailId)
        {
            string[] splittedProductName = productName.ToLower().Split(" ");

            string joinedProductName = string.Join("_", splittedProductName);

            if (splittedProductName.Length > 4)
            {
                splittedProductName = splittedProductName
                .Take(3)
                .ToArray();

                joinedProductName = string.Join("_", splittedProductName);
            }

            return $"{thumbnailId}-{joinedProductName}";
        }
    }
}
