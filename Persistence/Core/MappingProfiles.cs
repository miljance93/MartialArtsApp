﻿using Application.DTO;
using AutoMapper;
using Domain;
using Domain.IdentityAuth;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            string currentUsername = null;
            CreateMap<ApplicationUser, ClientDTO>().ReverseMap();
            CreateMap<ApplicationUser, CoachDTO>().ReverseMap();
            CreateMap<MartialArt, MartialArtDTO>()
                .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsCoach).User.UserName)).ReverseMap();
            CreateMap<MartialArtAttendee, AttendeeDTO>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.User.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.User.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.User.Followings.Count))
                .ForMember(d => d.Following, o => o.MapFrom(s => s.User.Followers.Any(x => x.Observer.UserName == currentUsername)));
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Post, PostDTO>()
                .ForMember(x => x.CoachId, o => o.MapFrom(p => p.CoachId))
                .ReverseMap();
            CreateMap<Mentorship, MentorshipDTO>().ReverseMap();
            CreateMap<Skill, CoachSearchDTO>();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserFollowing, UserFollowing>().ReverseMap();
            CreateMap<AuditLogs, AuditLogsDTO>().ReverseMap();
            CreateMap<Photo, Photo>();
            CreateMap<ApplicationUser, Application.Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(x => x.DisplayName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
                .ForMember(d => d.Following, o => o.MapFrom(s => s.Followers.Any(x => x.Observer.UserName == currentUsername)));
            //CreateMap<PagedList<ApplicationUser>, PagedList<ClientDTO>>();
            //CreateMap<PagedList<ClientDTO>, PagedList<ApplicationUser>>();

            CreateMap<Comment, CommentDTO>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.Author.FirstName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Author.UserName))
                .ForMember(x => x.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));


            CreateMap<MartialArt, MartialArt>();
        }
    }
}
