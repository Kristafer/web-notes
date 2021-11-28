using System.Linq;
using AutoMapper;
using BCrypt.Net;
using WebNotesApi.Models.Notes;
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
            CreateMap<User, AuthenticateResult>().ReverseMap();
            CreateMap<AuthenticateResponse, AuthenticateResult>().ReverseMap();
            CreateMap<AuthenticateRequest, LoginModel>().ReverseMap();
            CreateMap<RegisterRequest, User>()
                 .ForMember(user => user.PasswordHash, opt => opt.MapFrom(request => BCryptNet.HashPassword(request.Password, SaltRevision.Revision2B)))
                 .ForMember(user => user.Role, opt => opt.MapFrom(request => Role.User));
            CreateMap<CreateNoteModel, Note>()
                .ForMember(x => x.NoteTags, m => m.Ignore());
            CreateMap<CreateNoteRequest, CreateNoteModel>();
            CreateMap<UpdateNoteRequest, UpdateNoteModel>();
            CreateMap<UpdateNoteModel, Note>()
                .ForMember(x => x.NoteTags, m => m.Ignore());
            CreateMap<Note, NoteResponse>().ForMember(x => x.NoteTags, c => c.MapFrom(t => t.NoteTags.Select(x => x.Tag.Value)));

            //TODO add profile to create, update, search model
        }
    }
}
