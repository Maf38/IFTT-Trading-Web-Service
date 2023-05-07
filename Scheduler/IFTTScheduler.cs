namespace IFTT_Trading.Scheduler
{
    public class IFTTScheduler : IHostedService
    {
        private Timer? _timer;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public IFTTScheduler(IServiceScopeFactory serviceScopeFactory) => _serviceScopeFactory = serviceScopeFactory;

        public void Dispose() => _timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer((object? state) => {
                using var scope = _serviceScopeFactory.CreateScope();
                var myService = scope.ServiceProvider.GetRequiredService<IMyService>();
                await myService.Execute(cancellationToken);            // <------ problem
            }), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
