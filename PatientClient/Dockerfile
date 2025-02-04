FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY "PatientClient/PatientClient.csproj" "./PatientClient/"
COPY "PatientRESTApi/PatientRESTApi.csproj" "./PatientRESTApi/"
RUN dotnet restore "PatientClient/PatientClient.csproj"
COPY . .

WORKDIR "/src/PatientRESTApi"
RUN dotnet publish "PatientRESTApi.csproj" -c Release -o /app/api

WORKDIR "/src/PatientClient"
RUN dotnet build "PatientClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PatientClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientClient.dll"]