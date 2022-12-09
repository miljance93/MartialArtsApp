using Application.DTO;
using AutoMapper;
using Domain;
using Domain.IdentityAuth;
using System.Linq;

namespace Persistence.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, ClientDTO>().ReverseMap();
            CreateMap<ApplicationUser, CoachDTO>().ReverseMap();
            CreateMap<MartialArt, MartialArtDTO>()
                .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsCoach).User.UserName)).ReverseMap();
            CreateMap<MartialArtAttendee, AttendeeDTO>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.User.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Post, PostDTO>()
                .ForMember(x => x.CoachId, o => o.MapFrom(p => p.CoachId))
                .ReverseMap();
            CreateMap<Mentorship, MentorshipDTO>().ReverseMap();
            CreateMap<Skill, CoachSearchDTO>();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserFollowing, UserFollowingDTO>().ReverseMap();
            CreateMap<AuditLogs, AuditLogsDTO>().ReverseMap();
            CreateMap<Photo, Photo>();
            CreateMap<ApplicationUser, Application.Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
            //CreateMap<PagedList<ApplicationUser>, PagedList<ClientDTO>>();
            //CreateMap<PagedList<ClientDTO>, PagedList<ApplicationUser>>();

            //CreateMap<Comment, CommentDTO>().ReverseMap()
            //    .ForMember(x => x.Author.FirstName, y => y.MapFrom(z => z.DisplayName))
            //    .ForMember(x => x.Author.UserName, y => y.MapFrom(z => z.Username));
        }
    }
}
