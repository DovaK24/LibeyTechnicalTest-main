﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
namespace LibeyTechnicalTestAPI.Middleware
{
    public static class DIExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            services.AddTransient<ILibeyUserAggregate, LibeyUserAggregate>();
            services.AddTransient<ILibeyUserRepository, LibeyUserRepository>();
			services.AddTransient<IDocumentTypeService, DocumentTypeService>();
			services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
			services.AddTransient<IProvinceService, ProvinceService>();
			services.AddTransient<IProvinceRepository, ProvinceRepository>();
			services.AddTransient<IRegionService, RegionService>();
			services.AddTransient<IRegionRepository, RegionRepository>();
			services.AddTransient<IUbigeoService, UbigeoService>();
			services.AddTransient<IUbigeoRepository, UbigeoRepository>();
			return services;
        }
    }
}
