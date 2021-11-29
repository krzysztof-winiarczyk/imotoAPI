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
        public int CanSaveImage(int announcementId);
    }

    public class ImageService : IImageService
    {
        private readonly int _maxPhotosNumberInAnnoucement = 5;

        private readonly ImotoDbContext _dbContext;
        private readonly IUserContextService _userContextService;

        public ImageService(ImotoDbContext dbContext, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }

        public int CanSaveImage(int announcementId)
        {
            var announcement = _dbContext
                .Annoucements
                .FirstOrDefault(a => a.Id == announcementId);

            //No announcement
            if (announcement is null)
                return 404;

            
            int numberOfImages = _dbContext
                .Annoucement_Images
                .Where(ai => ai.AnnoucementId == announcement.Id)
                .ToList()
                .Count;

            //To many images
            if (numberOfImages >= _maxPhotosNumberInAnnoucement)
                return 409;
            
            int userId = _userContextService.GetUserId;
            string userRole = _userContextService.GetUserRole;

            //Invoking user is not owner of announcement
            if (userRole == "użytkownik" && announcement.UserId != userId)
                return 403;

            return 200;
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
