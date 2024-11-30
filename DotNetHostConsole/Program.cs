using DotNetHostConsole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var appBuilder = Host.CreateApplicationBuilder(args); //configures the host with defaults

appBuilder.Services.AddHostedService<PrintMessageBackgroundService>();

var app = appBuilder.Build(); // creates the app

app.Run();
