using Application.DTO;
using AutoMapper;
using Domain;
using Domain.IdentityAuth;

namespace RepositoryLayer.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, ClientDTO>();
            CreateMap<ApplicationUser, CoachDTO>();
            CreateMap<MartialArt, MartialArtDTO>();
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Post, PostDTO>()
                .ForMember(x => x.CoachId, o => o.MapFrom(p => p.CoachId));
            CreateMap<Mentorship, MentorshipDTO>();
            CreateMap<Skill, CoachSearchDTO>();
        }
    }
}
