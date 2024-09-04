using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using ProductCatalog.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços do Discovery Client
builder.Services.AddDiscoveryClient(builder.Configuration);

// Configurar o DbContext para o ProductCatalog
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseInMemoryDatabase("ProductCatalogDb")); // Usando banco de dados em memória

// Adicionar serviços de controladores e Swagger
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductCatalog API", Version = "v1" });
});

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Necessário para servir arquivos estáticos
app.UseRouting();
app.UseAuthorization();

// Configurar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductCatalog API V1");
    c.RoutePrefix = "swagger"; // Define o prefixo da rota do Swagger
});

// Mapear endpoints
app.MapControllers();

// Iniciar o cliente de descoberta
app.UseDiscoveryClient();

app.Run();
