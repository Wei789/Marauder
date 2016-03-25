using Marauder.BLL.ViewModels;
using System.Linq;

namespace Marauder.BLL.Interface
{
    public interface IGenreService
    {
        IQueryable<GenreViewModel> GetAll();
        GenreViewModel GetByGenre(string GenreName);
    }
}
