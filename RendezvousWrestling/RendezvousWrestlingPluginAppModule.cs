using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RendezvousWrestling
{

    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class RendezvousWrestlingPluginAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHostedService<RendezvousWrestlingPluginHostedService>();
        }

        public const string RemoteServiceName = "Default";
    }
}
