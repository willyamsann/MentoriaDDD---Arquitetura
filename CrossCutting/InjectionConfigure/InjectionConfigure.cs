﻿using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.InjectionConfigure
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));

        }
    }
}
