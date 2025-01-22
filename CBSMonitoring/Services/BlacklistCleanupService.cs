
using CBSMonitoring.Data;

namespace CBSMonitoring.Services
{
    public class BlacklistCleanupService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BlacklistCleanupService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => CleanupExpiredTokens());
        }

        private async Task CleanupExpiredTokens()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var expiredTokens = dbContext.BlacklistedTokens.Where(bt => bt.Expiration <= DateTime.UtcNow);
            dbContext.BlacklistedTokens.RemoveRange(expiredTokens);
            await dbContext.SaveChangesAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
