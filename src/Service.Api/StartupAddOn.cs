using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

using Service.Repositories;
using Service.Providers;

namespace Service.Api
{
    public static class StartupAddOn
    {
        private static MapperConfiguration _mapperConfiguration { get; set; }

        public static void ConfigureServices(
            IServiceCollection services,
            IHostingEnvironment env
            )
        {

            #region dependency injection
            services.AddSingleton<IInventoryRepository, InventoryRepository>();
            services.AddSingleton<IInventoryProvider, InventoryProvider>();
            #endregion

            #region setup mapping
            _mapperConfiguration = MapperDefinition.GetMapperDefinition();
            services.AddSingleton<IMapper>(provider => _mapperConfiguration.CreateMapper());
            #endregion
        }
    }
}
