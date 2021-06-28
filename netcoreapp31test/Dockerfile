#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV APPLICATIONINSIGHTS_CONNECTION_STRING=InstrumentationKey=a63d0ee3-fa4d-4d14-bafd-4e2beda53c56;IngestionEndpoint=https://eastus-3.in.applicationinsights.azure.com/
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=Microsoft.ApplicationInsights.StartupBootstrapper
ENV DOTNET_STARTUP_HOOKS=/agentfiles/StartupHook/Microsoft.ApplicationInsights.StartupHook.dll
WORKDIR /src
ADD "netcoreapp31test/dotnetcoreagent-2.8.39.tar.gz" /agentfiles/
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["netcoreapp31test/netcoreapp31test.csproj", "netcoreapp31test/"]
RUN dotnet restore "netcoreapp31test/netcoreapp31test.csproj"
COPY . .
WORKDIR "/src/netcoreapp31test"
RUN dotnet build "netcoreapp31test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "netcoreapp31test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "netcoreapp31test.dll"]