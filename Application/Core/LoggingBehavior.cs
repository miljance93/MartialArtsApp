using Application.DTO;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditLogsRepository _auditLogsRepository;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor, IAuditLogsRepository auditLogsRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _auditLogsRepository = auditLogsRepository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //1.Iz HttpContext - a(treba da se injectuje sa IHttpContextAccessor) pokupiti informacije o request-u
            //(Url, isUserAuthenticated, httpMetodu, BodyRequest - a)

            var auditLogsDto = new AuditLogsDTO
            {
                Body = _httpContextAccessor.HttpContext.Request.Body.ToString(),
                Method = _httpContextAccessor.HttpContext.Request.Method,
                Url = _httpContextAccessor.HttpContext.Request.GetDisplayUrl()
            };

            _logger.LogInformation($"\t\n~Method: {auditLogsDto.Method} \t\n\n~Body: {auditLogsDto.Body} \t\n\n~Url: {auditLogsDto.Url}");

            //   ovo se izvrsava pri povratku response-a.

            var response = await next();

            //2.Pamtimo log u bazu(Date, isUserAuthenticated, httpMethod, Url, Response)
            await _auditLogsRepository.PostAsync(auditLogsDto);

            _logger.LogInformation("Action completed!");

            return response;
        }
    }
}
