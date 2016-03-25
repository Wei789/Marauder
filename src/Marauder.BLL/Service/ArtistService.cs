using AutoMapper.QueryableExtensions;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Linq;

namespace Marauder.BLL.Service
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<ArtistViewModel> GetAll()
        {
            IQueryable<Artist> result = this.unitOfWork.Repository<Artist>().Get();
            return result.Project().To<ArtistViewModel>();
        }
    }
}
