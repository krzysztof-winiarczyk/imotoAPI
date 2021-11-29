using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Services
{
    public interface IImageService
    {
        public void AddPhoto(int annoucementId, string fileName);
    }

    public class ImageService : IImageService
    {
        private readonly ImotoDbContext _dbContext;

        public ImageService(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPhoto(int annoucementId, string fileName)
        {
            var image = new Image
            {
                FileName = fileName
            };

            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();

            var announcementImage = new Annoucement_Image
            {
                AnnoucementId = annoucementId,
                ImageId = image.Id
            };

            _dbContext.Annoucement_Images.Add(announcementImage);
            _dbContext.SaveChanges();
        }
    }
}
