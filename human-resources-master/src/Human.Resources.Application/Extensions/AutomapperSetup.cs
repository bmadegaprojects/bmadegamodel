using AutoMapper;
using Human.Resources.Service.Automapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Human.Resources.Application.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DtoToEntityProfile), typeof(EntityToDtoProfile));
        }
    }
}
