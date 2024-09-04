using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Configurar o Config Server
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    // Adicionar Config Server
    config.AddConfigServer(context.HostingEnvironment);
});

// Adicionar Eureka Discovery Client
builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configurar middleware
app.UseRouting();
app.UseAuthorization();

// Mapear endpoints
app.MapControllers();

// Iniciar o cliente de descoberta
app.UseDiscoveryClient();

app.Run();
