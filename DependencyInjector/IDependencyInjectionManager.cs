using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjector
{
    public interface IDependencyInjectionManager
    {
        void Register(IServiceCollection serviceCollection);
    }
}
