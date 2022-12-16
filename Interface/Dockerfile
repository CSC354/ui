FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interface/Interface.csproj", "Interface/"]
RUN dotnet restore "Interface/Interface.csproj"
COPY . .
WORKDIR "/src/Interface"
RUN dotnet build "Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interface.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interface.dll"]
