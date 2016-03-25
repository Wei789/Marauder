using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Linq;

namespace Marauder.BLL.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AlbumViewModel GetById(int id)
        {
            Album result = this.unitOfWork.Repository<Album>().GetByID(id);
            return Mapper.Map<AlbumViewModel>(result);
        }

        public IQueryable<AlbumViewModel> GetAll()
        {
            IQueryable<Album> result = this.unitOfWork.Repository<Album>().Get(includeProperties: "Genre,Artist");
            return result.Project().To<AlbumViewModel>();
        }

        public void Delete(int id)
        {
            Album delete = this.unitOfWork.Repository<Album>().GetByID(id);
            this.unitOfWork.Repository<Album>().Delete(delete);
        }

        public void Update(AlbumViewModel album)
        {
            this.unitOfWork.Repository<Album>().Update(Mapper.Map<Album>(album));
        }

        public void Create(AlbumViewModel instanse)
        {
            this.unitOfWork.Repository<Album>().Create(Mapper.Map<Album>(instanse));
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }
    }
}
