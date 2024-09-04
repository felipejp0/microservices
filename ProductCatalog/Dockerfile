# Use uma imagem oficial do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo de projeto e restaure as dependências
COPY ProductCatalog.csproj .
RUN dotnet restore

# Copie o restante do código e compile a aplicação
COPY . .
RUN dotnet publish -c Release -o /app

# Use uma imagem oficial do .NET Runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Exponha a porta em que a aplicação irá rodar
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "ProductCatalog.dll"]