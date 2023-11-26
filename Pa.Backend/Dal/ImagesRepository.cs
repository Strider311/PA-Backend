using Pa.Backend.Interfaces;
using Pa.Backend.Models;

namespace Pa.Backend.Dal
{

    public class ImagesRepository : IImageRepository, IDisposable
    {
        private PaContext context;

        public ImagesRepository(PaContext context)
        {
            this.context = context;
        }

        public void AddNewImage(ImageDbModel image)
        {
            context.Images.Add(image);
        }

        public void DeleteImage(Guid id)
        {
            ImageDbModel image = context.Images.Find(id);
            context.Images.Remove(image);
        }

        public ImageDbModel GetImageById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageDbModel> GetImages()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateImage(Guid id)
        {
            throw new NotImplementedException();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}