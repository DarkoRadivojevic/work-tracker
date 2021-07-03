#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WorkTracker.Web/WorkTracker.Web.csproj", "WorkTracker.Web/"]
COPY ["WorkTracker.Business/WorkTracker.Business.csproj", "WorkTracker.Business/"]
COPY ["WorkTracker.Data/WorkTracker.Data.csproj", "WorkTracker.Data/"]
RUN dotnet restore "WorkTracker.Web/WorkTracker.Web.csproj"
COPY . .
WORKDIR "/src/WorkTracker.Web"
RUN dotnet build "WorkTracker.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkTracker.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkTracker.Web.dll"]
