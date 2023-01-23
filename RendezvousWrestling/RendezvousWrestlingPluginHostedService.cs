using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RendezvousWrestling.FightSystem;
using Volo.Abp;

namespace RendezvousWrestling
{
    public class RendezvousWrestlingPluginHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly RendezVousWrestlingGame _examplePlugin;

        public RendezvousWrestlingPluginHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider,
            RendezVousWrestlingGame vcBot)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _examplePlugin = vcBot;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _application.Initialize(_serviceProvider);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _application.Shutdown();
            return Task.CompletedTask;
        }
    }
}
