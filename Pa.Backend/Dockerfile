FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5115

ENV ASPNETCORE_URLS=http://+:5115

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Pa.Backend/Pa.Backend.csproj", "Pa.Backend/"]
RUN dotnet restore "Pa.Backend/Pa.Backend.csproj"
COPY . .
WORKDIR "/src/Pa.Backend"
RUN dotnet build "Pa.Backend.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Pa.Backend.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pa.Backend.dll"]
