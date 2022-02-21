using AutoMapper;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<RegistrationRequest, User>();
            CreateMap<RegistrationRequest, AuthenticateRequest>();
        }
    }
}
