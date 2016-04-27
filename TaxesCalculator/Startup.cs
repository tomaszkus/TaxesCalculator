namespace TaxesCalculator
{
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Owin;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Controllers;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = RegisterServices();
            var webApiConfiguration = new HttpConfiguration();

            webApiConfiguration.MapHttpAttributeRoutes();

            var dependencyResolver = new AutofacWebApiDependencyResolver(container);
            webApiConfiguration.DependencyResolver = dependencyResolver;

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(webApiConfiguration);
            app.UseWebApi(webApiConfiguration);
        }

        public IContainer RegisterServices()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<TaxesController>().InstancePerRequest();

            builder.RegisterType<GenercTaxCalculator>().SingleInstance();

            return builder.Build();
        }
    }
}
