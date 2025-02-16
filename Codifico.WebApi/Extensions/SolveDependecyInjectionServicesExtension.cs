using Codifico.BusinessServices.Mapper;
using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Repository.Repository.Service;
using Codifico.Services.Mapper;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Codifico.WebApi.Extensions
{
	public static class SolveDependecyInjectionServicesExtension
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IMapper<SalesDatePrediction, SalesDatePredictionDto>), typeof(SalesDatePredictionMapper));
			services.AddScoped(typeof(IMapper<GetClientOrder, ClientOrderDto>), typeof(ClientOrderMapper));
			services.AddScoped(typeof(IMapper<Employee, EmployeeDto>), typeof(EmployeeMapper));
			services.AddScoped(typeof(IMapper<Shipper, ShipperDto>), typeof(ShipperMapper));
			services.AddScoped(typeof(IMapper<Product, ProductDto>), typeof(ProductMapper));

			Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("Codifico.Services");
			Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("Codifico.BusinessServices");
			Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("Codifico.Repository");
			Assembly assemblyDataImplementation = AppDomain.CurrentDomain.Load("Codifico.Repository");

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Command"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Invoker"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Service"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Mapper"))
				.AsPublicImplementedInterfaces();
		}
	}
}
