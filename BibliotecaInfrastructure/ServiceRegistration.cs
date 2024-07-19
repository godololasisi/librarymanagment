using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaBusiness.Interfaces;
using BibliotecaInfrastructure.ExternalService.Repositories;
using BibliotecaInfrastructure.Persistence.Repositories;
using BibliotecaInfrastructure.Persistence.Repositories.BookRepository;
using BibliotecaInfrastructure.Persistence.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaInfrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            #region Repositories            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPushNotificationRepository, PushNotificationRepository>();
            #endregion

        }
    }
}
