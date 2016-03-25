using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Linq;

namespace Marauder.BLL.Interface
{
    public interface IArtistService
    {
        IQueryable<ArtistViewModel> GetAll();
    }
}
