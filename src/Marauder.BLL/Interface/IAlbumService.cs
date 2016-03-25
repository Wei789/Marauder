using Marauder.BLL.ViewModels;
using System.Linq;

namespace Marauder.BLL.Interface
{
    public interface IAlbumService
    {
        AlbumViewModel GetById(int id);
        IQueryable<AlbumViewModel> GetAll();
        void Delete(int id);
        void Update(AlbumViewModel album);
        void Create(AlbumViewModel instanse);
        void Save();
    }
}
