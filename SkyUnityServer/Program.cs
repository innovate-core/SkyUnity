using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkyUnityCore.Repositories;
using SkyUnityServer;
using SkyUnityServer.Extensions;
using SkyUnityServer.Services;

try
{
    var host = CreateHostBuilder(args).Build();

    var server = host.Services.GetRequiredService<SkyUnityTPCServer>();

    Thread serverThread = new Thread(server.Start);
    serverThread.IsBackground = false;
    serverThread.Start();

    await host.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"SkyUnity Server fail: {ex.Message}");
}

static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<ConfigurationBuilder>(context.Configuration);
        services.BuildServiceProvider();

        services.AddDatabase(context.Configuration);
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();
        services.AddSingleton<SkyUnityTPCServer>();
    }).ConfigureLogging(logging =>
    {
        logging.AddConsole();
        logging.ClearProviders();
    }).UseContentRoot(Directory.GetCurrentDirectory());