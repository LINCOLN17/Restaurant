using AutoMapper;
using Restaurant.BLL.Entities;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Restaurant.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression Mapping(this IMapperConfigurationExpression configurationExpression, UserManager<User> userManager)
        {
            Mapper.Initialize(cfg =>
            {
                // Maps
                cfg.CreateMap<User, BaseUserVm>()
                    .ForMember(dest => dest.Roles, member => member.MapFrom(src =>
                         userManager.GetRolesAsync(src).Result
                    ));
                cfg.CreateMap<Reservation, ReservationVm>();
            });
            return configurationExpression;
        }
    }
}
