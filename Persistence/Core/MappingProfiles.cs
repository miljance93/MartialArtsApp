using Application.DTO;
using AutoMapper;
using Domain;
using Domain.IdentityAuth;
using Domain.Models;

namespace Persistence.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, ClientDTO>();
            CreateMap<ClientDTO, ApplicationUser>();
            CreateMap<ApplicationUser, CoachDTO>();
            CreateMap<CoachDTO, ApplicationUser>();
            CreateMap<MartialArt, MartialArtDTO>();
            CreateMap<MartialArtDTO, MartialArt>();
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<ScheduleDTO, Schedule>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<Post, PostDTO>()
                .ForMember(x => x.CoachId, o => o.MapFrom(p => p.CoachId));
            CreateMap<PostDTO, Post>();
            CreateMap<Mentorship, MentorshipDTO>();
            CreateMap<MentorshipDTO, Mentorship>();
            CreateMap<Skill, CoachSearchDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<UserFollowing, UserFollowingDTO>();
            CreateMap<UserFollowingDTO, UserFollowing>();
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>();
            //CreateMap<PagedList<ApplicationUser>, PagedList<ClientDTO>>();
            //CreateMap<PagedList<ClientDTO>, PagedList<ApplicationUser>>();
        }
    }
}
