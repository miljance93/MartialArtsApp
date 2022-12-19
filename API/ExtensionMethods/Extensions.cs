using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace API.ExtensionMethods
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {           
            services.AddScoped<IMartialArtRepository, MartialArtRepository>();          
            services.AddScoped<IUserFollowingRepository, UserFollowingRepository>();           
            services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();

            return services;
        }
    }
}
