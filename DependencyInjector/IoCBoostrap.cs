using CrossCutting;
using DataPersistence.Contexts;
using DataPersistence.Contracts;
using DataPersistence.Repositories;
using Domain.Repository;
using Domain.Services;
using Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjector
{
    public class IoCBoostrap : IDependencyInjectionManager
    {
        public void Register(IServiceCollection serviceCollection)
        {
            RegisterContexts(serviceCollection);
            RegisterRepositories(serviceCollection);
            RegisterDomainServices(serviceCollection);
        }

        private void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBookRepository), typeof(BookRepository));
        }

        private void RegisterContexts(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBookstoreContext), typeof(BookstoreContext));
        }

        private void RegisterDomainServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBookService), typeof(BookService));
            serviceCollection.AddSingleton(typeof(IDatabaseConfigurationProvider), typeof(LocalSqliteConfigurationProvider));
        }
    }
}
