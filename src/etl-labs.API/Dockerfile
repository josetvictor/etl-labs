FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5274

ENV ASPNETCORE_URLS=http://+:5274

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/etl-labs.API/etl-labs.API.csproj", "src/etl-labs.API/"]
RUN dotnet restore "src/etl-labs.API/etl-labs.API.csproj"
COPY . .
WORKDIR "/src/etl-labs.API"
RUN dotnet build "etl-labs.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "etl-labs.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "etl-labs.API.dll"]
