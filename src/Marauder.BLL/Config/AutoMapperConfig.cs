using AutoMapper;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Marauder.BLL
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Genre, GenreViewModel>();
            Mapper.CreateMap<Album, AlbumViewModel>();
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<Artist, ArtistViewModel>();
            Mapper.CreateMap<Cart, CartViewModel>();


            Mapper.CreateMap<IList<CartViewModel>, ShoppingCartViewModel>()
                .ForMember(x => x.CartTotal, y => y.MapFrom(z => z.Sum(c => c.Count * c.Album.Price)))
                    .ForMember(x => x.CartItems, y => y.MapFrom(model => model));
            //Mapper.CreateMap<Genre, AlbumViewModel>();
            //Mapper.CreateMap<Genre, AlbumViewModel>()
            //    .ForMember(x => x.GenreName, y => y.MapFrom(z => z.Name));

            //Mapper.CreateMap<AlbumViewModel, Album>()
            //    .ForMember(x => x.Genre, y => y.MapFrom(model => model));
            //Mapper.CreateMap<AlbumViewModel, Genre>().ReverseMap()
            //    .ForMember(x => x.GenreName, y => y.MapFrom(z => z.Name));
        }
    }
}
