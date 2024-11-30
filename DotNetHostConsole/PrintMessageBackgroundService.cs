using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetHostConsole;

internal class PrintMessageBackgroundService : BackgroundService
{
    private readonly ILogger<PrintMessageBackgroundService> _logger;
    private readonly IConfiguration _config;
    public PrintMessageBackgroundService(ILogger<PrintMessageBackgroundService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string message = _config.GetValue<string>(nameof(message)) ?? ""; 

        while(!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(message);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
