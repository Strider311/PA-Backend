using Pa.Backend.Models;

namespace Pa.Backend.Interfaces
{

    public interface IImageRepository
    {
        IEnumerable<ImageDbModel> GetImages();

        ImageDbModel GetImageById(Guid id);

        void AddNewImage(ImageDbModel image);

        void DeleteImage(Guid id);

        void UpdateImage(Guid id);

        void Save();
    }
}