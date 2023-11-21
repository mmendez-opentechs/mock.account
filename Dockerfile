FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mock.Account/Mock.Account.csproj", "Mock.Account/."]
RUN dotnet restore "Mock.Account/Mock.Account.csproj"
COPY . .
RUN dotnet build "Mock.Account/Mock.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mock.Account/Mock.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "Mock.Account.dll"]