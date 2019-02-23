using Autofac;
using QuoteMe.MVC.Services.FinancePlanCalculator;

namespace QuoteMe.MVC.DependencyRegistration
{
    public static class DependencyRegistry
    {
        public static void RegisterAll(ContainerBuilder builder)
        {
            builder.RegisterType<InterestFreeFinancePlanCalculator>().As<IFinancePlanCalculator>().SingleInstance();
        }
    }
}