using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Entekhab.Application.PersonSalaries;
using Entekhab.Application.PersonSalaries.Commands;
using Entekhab.Persistence;
using Entekhab.Base.Enums;
using Entekhab.Persistence.Base;

namespace Entekhab.Core
{
	public static class DependencyContainer : object
	{
		static DependencyContainer()
		{
		}

		public static void ConfigureServices
			(IConfiguration configuration,
			IServiceCollection services)
		{
			services.AddTransient
				<IHttpContextAccessor,
				HttpContextAccessor>();
		
			services.AddMediatR
				(typeof(MappingProfile).GetTypeInfo().Assembly);

			services.AddValidatorsFromAssembly
				(assembly: typeof(CreatePersonSalaryCommandValidator).Assembly);

			services.AddTransient
				(typeof(MediatR.IPipelineBehavior<,>), typeof(Mediator.ValidationBehavior<,>));

			services.AddAutoMapper
				(profileAssemblyMarkerTypes: typeof(MappingProfile));

			services.AddTransient<Entekhab.Persistence.IUnitOfWork, Entekhab.Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

                Provider databaseProvider =
					(Provider)
					System.Convert.ToInt32(databaseProviderString);

                Options options =
					new Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new UnitOfWork(options: options);
			});

			services.AddTransient<Entekhab.Persistence.IQueryUnitOfWork, Entekhab.Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "QueriesDatabaseProvider")
					.Value;

                Provider databaseProvider =
					(Entekhab.Base.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                Options options =
					new Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Entekhab.Persistence.QueryUnitOfWork(options: options);
			});
		}
	}
}
