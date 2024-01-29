# Use a imagem do SDK do .NET 7.0 como base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copie os arquivos do projeto e restaure as dependências
COPY . ./
RUN dotnet restore

# COPY . ./
RUN dotnet publish -c Release -o dist

# Use a imagem do Runtime do .NET 7.0 para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app/dist
COPY --from=build-env /app/dist .
ENTRYPOINT ["dotnet", "etl-labs.Hangfire.dll"]