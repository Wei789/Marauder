using AutoMapper;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;

namespace Marauder.BLL
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<acct_company, CompanyView>();
        }
    }
}
