
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Insttantt.Workflow.EndPointApi/Insttantt.Workflow.EndPointApi.csproj", "Insttantt.Workflow.EndPointApi/"]
COPY ["Insttantt.Persistence.Repositories/Insttantt.Workflow.Persistence.Repositories.csproj", "Insttantt.Persistence.Repositories/"]
COPY ["Insttantt.Workflow.Persistence.EntityFramework/Insttantt.Workflow.Persistence.EntityFramework.csproj", "Insttantt.Workflow.Persistence.EntityFramework/"]
COPY ["Insttantt.Workflow.Models/Insttantt.Workflow.Models.csproj", "Insttantt.Workflow.Models/"]
COPY ["Insttantt.Workflow.Shared/Insttantt.Workflow.Shared.csproj", "Insttantt.Workflow.Shared/"]
COPY ["Insttantt.Workflow.CQRServices/Insttantt.Workflow.CQRServices.csproj", "Insttantt.Workflow.CQRServices/"]
COPY ["Insttantt.Workflow.Dtos/Insttantt.Workflow.Dtos.csproj", "Insttantt.Workflow.Dtos/"]
COPY ["Insttantt.Workflow.Rules/Insttantt.Workflow.Rules.csproj", "Insttantt.Workflow.Rules/"]
RUN dotnet restore "Insttantt.Workflow.EndPointApi/Insttantt.Workflow.EndPointApi.csproj"
COPY . .
WORKDIR "/src/Insttantt.Workflow.EndPointApi"
RUN dotnet build "Insttantt.Workflow.EndPointApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Insttantt.Workflow.EndPointApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insttantt.Workflow.EndPointApi.dll"]