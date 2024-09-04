# Use uma imagem oficial do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Etapa 1: Imagem base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo de projeto e restaure as dependências
COPY ConfigServer.csproj .
RUN dotnet restore

# Copie o restante do código e compile a aplicação
COPY . .
RUN dotnet publish -c Release -o /app

# Etapa 3: Publicação
FROM build AS publish
RUN dotnet publish "ConfigServer.csproj" -c Release -o /app/publish

# Etapa 4: Runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConfigServer.dll"]
