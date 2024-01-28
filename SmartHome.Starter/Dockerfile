FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SmartHome.Starter/SmartHome.Starter.csproj", "SmartHome.Starter/"]
RUN dotnet restore "SmartHome.Starter/SmartHome.Starter.csproj"
COPY . .
WORKDIR "/src/SmartHome.Starter"
RUN dotnet build "SmartHome.Starter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartHome.Starter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartHome.Starter.dll"]
