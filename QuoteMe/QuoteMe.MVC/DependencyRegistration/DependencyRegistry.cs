using Autofac;
using QuoteMe.Storage;

namespace QuoteMe.MVC.DependencyRegistration
{
    public static class DependencyRegistry
    {
        public static void RegisterAll(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryStorageService>().As<IWritableStorageService>().InstancePerLifetimeScope();
        }
    }
}