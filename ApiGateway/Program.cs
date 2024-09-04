using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Steeltoe.Discovery.Client;
using Ocelot.Provider.Eureka;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços do Discovery Client (Eureka)
builder.Services.AddDiscoveryClient(builder.Configuration);

// Configurar Ocelot com Eureka
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddEureka();

var app = builder.Build();

// Usar Discovery Client
app.UseDiscoveryClient();

// Endpoint simples para retornar uma mensagem estática
app.MapGet("/", () => "Oi. Estou funcionando!");

// Usar Ocelot como middleware
await app.UseOcelot();

app.Run();
