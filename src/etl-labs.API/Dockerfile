# Use a imagem do SDK do .NET 7.0 como base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copie os arquivos do projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Development -o out

# Use a imagem do Runtime do .NET 7.0 para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 32041
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "etl-labs.API.dll"]