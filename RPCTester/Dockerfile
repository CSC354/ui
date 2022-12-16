FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RPCTester/RPCTester.csproj", "RPCTester/"]
RUN dotnet restore "RPCTester/RPCTester.csproj"
COPY . .
WORKDIR "/src/RPCTester"
RUN dotnet build "RPCTester.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RPCTester.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPCTester.dll"]
