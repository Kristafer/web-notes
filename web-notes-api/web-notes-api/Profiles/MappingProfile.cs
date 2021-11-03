using AutoMapper;
using BCrypt.Net;
using WebNotesApi.Models.Users;
using WebNotesApplication.Models;
using WebNotesData.Entities;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebNotesApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AuthenticateResult>();
            CreateMap<AuthenticateResponse, AuthenticateResult>().ReverseMap();
            CreateMap<AuthenticateRequest, LoginModel>().ReverseMap();
            CreateMap<RegisterRequest, User>()
                 .ForMember(user => user.PasswordHash, opt => opt.MapFrom(request => BCryptNet.HashPassword(request.Password, SaltRevision.Revision2B)))
                 .ForMember(user => user.Role, opt => opt.MapFrom(request => Role.User));

            //TODO add profile to create, update, search model
        }
    }
}
