FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5244

ENV ASPNETCORE_URLS=http://+:5244

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Enviro365Assessment_Grad_DOTNET_version/Enviro365Assessment_Grad_DOTNET_version.csproj", "Enviro365Assessment_Grad_DOTNET_version/"]
RUN dotnet restore "Enviro365Assessment_Grad_DOTNET_version/Enviro365Assessment_Grad_DOTNET_version.csproj"
COPY . .
WORKDIR "/src/Enviro365Assessment_Grad_DOTNET_version"
RUN dotnet build "Enviro365Assessment_Grad_DOTNET_version.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Enviro365Assessment_Grad_DOTNET_version.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enviro365Assessment_Grad_DOTNET_version.dll"]
