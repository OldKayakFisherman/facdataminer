FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FACDataImportService/FACDataImportService.csproj", "src/FACDataImportService/"]
RUN dotnet restore "src/FACDataImportService/FACDataImportService.csproj"
COPY . .
WORKDIR "/src/src/FACDataImportService"
RUN dotnet build "FACDataImportService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FACDataImportService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FACDataImportService.dll"]
