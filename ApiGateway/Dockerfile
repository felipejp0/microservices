# Use a imagem base do .NET SDK para compilar a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diret�rio de trabalho no container
WORKDIR /source

# Copie os arquivos do projeto para o diret�rio de trabalho
COPY . .

# Restaure as depend�ncias e publique a aplica��o
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Use a imagem do .NET Runtime para rodar a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Defina o diret�rio de trabalho no container
WORKDIR /app

# Copie os arquivos publicados da etapa de build
COPY --from=build /app .

# Exponha a porta em que a aplica��o ir� rodar
EXPOSE 80

# Defina o comando de entrada para rodar a aplica��o
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
