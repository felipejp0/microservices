# Use a imagem base do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho no container
WORKDIR /source

# Copie os arquivos do projeto para o diretório de trabalho
COPY . .

# Restaure as dependências e publique a aplicação
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Use a imagem do .NET Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Defina o diretório de trabalho no container
WORKDIR /app

# Copie os arquivos publicados da etapa de build
COPY --from=build /app .

# Exponha a porta em que a aplicação irá rodar
EXPOSE 80

# Defina o comando de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
