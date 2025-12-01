using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDiscordGateway();

var host = builder.Build();

host.AddModules(typeof(Program).Assembly);

await host.RunAsync();
