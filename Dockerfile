# Docker

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BetterPlan.Web.ApiRest/BetterPlan.Web.ApiRest.csproj", "BetterPlan.Web.ApiRest/"]
COPY ["BetterPlan.Founds.App.Shared/BetterPlan.Founds.App.Shared.csproj", "BetterPlan.Founds.App.Shared/"]
COPY ["BetterPlan.Founds.Models/BetterPlan.Founds.Models.csproj", "BetterPlan.Founds.Models/"]
COPY ["BetterPlan.Founds.Services/BetterPlan.Founds.Services.csproj", "BetterPlan.Founds.Services/"]
COPY ["BetterPlan.Founds.Infraestructure/BetterPlan.Founds.Infraestructure.csproj", "BetterPlan.Founds.Infraestructure/"]
COPY ["BetterPlan.Founds.Repositories/BetterPlan.Founds.Repositories.csproj", "BetterPlan.Founds.Repositories/"]
COPY ["BetterPlan.Founds.EntityFramework/BetterPlan.Founds.EntityFramework.csproj", "BetterPlan.Founds.EntityFramework/"]
COPY ["BetterPlan.Founds.Core.Shared/BetterPlan.Founds.Core.Shared.csproj", "BetterPlan.Founds.Core.Shared/"]
RUN dotnet restore "BetterPlan.Web.ApiRest/BetterPlan.Web.ApiRest.csproj"
COPY . .
WORKDIR "/src/BetterPlan.Web.ApiRest"
RUN dotnet build "BetterPlan.Web.ApiRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BetterPlan.Web.ApiRest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BetterPlan.Web.ApiRest.dll"]