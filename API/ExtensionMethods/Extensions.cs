using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using System.Collections.Generic;

namespace API.ExtensionMethods
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IMartialArtRepository, MartialArtRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IMentorshipRepository, MentorshipRepository>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IUserFollowingRepository, UserFollowingRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserAccessor, UserAccessor>();

            return services;
        }
    }
}
