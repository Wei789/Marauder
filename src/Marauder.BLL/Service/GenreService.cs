using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Linq;

namespace Marauder.BLL.Service
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<GenreViewModel> GetAll()
        {
            IQueryable<Genre> result = this.unitOfWork.Repository<Genre>().Get();
            return result.Project().To<GenreViewModel>();
        }

        public GenreViewModel GetByGenre(string GenreName)
        {
            Genre result = this.unitOfWork.Repository<Genre>().Get(x => x.Name == GenreName, includeProperties: "Albums").Single();
            return Mapper.Map<GenreViewModel>(result);
        }
    }
}
