using AutoMapper;
using Microsoft.Practices.Unity;
using Repository;
using Repository.Interfaces;
using System.Web.Http;
using FluentValidation.WebApi;

namespace refactor_me
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			var formatters = GlobalConfiguration.Configuration.Formatters;
			formatters.Remove(formatters.XmlFormatter);
			formatters.JsonFormatter.Indent = true;
			var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
			FluentValidationModelValidatorProvider.Configure(config);
			var container = new UnityContainer();
			container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
			container.RegisterInstance<IMapper>(mapper);
			config.DependencyResolver = new UnityResolver(container);

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
