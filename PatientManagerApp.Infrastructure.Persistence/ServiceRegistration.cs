using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Infrastructure.Persistence.Contexts;
using PatientManagerApp.Infrastructure.Persistence.Repository;

namespace PatientManagerApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            #region Context
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(opts => opts.UseInMemoryDatabase("TestingDb"));
            } else
            {
                services.AddDbContext<ApplicationContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            }
            #endregion

            #region Repositories

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

        }


    }
}
