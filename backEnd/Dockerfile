FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TT.SoMall.IdentityServer/TT.SoMall.IdentityServer.csproj", "src/TT.SoMall.IdentityServer/"]
COPY ["src/TT.SoMall.EntityFrameworkCore.DbMigrations/TT.SoMall.EntityFrameworkCore.DbMigrations.csproj", "src/TT.SoMall.EntityFrameworkCore.DbMigrations/"]
COPY ["modules/TT.Abp.VisitorManagement/TT.Abp.VisitorManagement.csproj", "modules/TT.Abp.VisitorManagement/"]
COPY ["modules/TT.Core/TT.Core.csproj", "modules/TT.Core/"]
COPY ["modules/TT.Abp.Shops/TT.Abp.Shops.csproj", "modules/TT.Abp.Shops/"]
COPY ["src/TT.SoMall.EntityFrameworkCore/TT.SoMall.EntityFrameworkCore.csproj", "src/TT.SoMall.EntityFrameworkCore/"]
COPY ["src/TT.SoMall.Domain/TT.SoMall.Domain.csproj", "src/TT.SoMall.Domain/"]
COPY ["src/TT.SoMall.Domain.Shared/TT.SoMall.Domain.Shared.csproj", "src/TT.SoMall.Domain.Shared/"]
COPY ["modules/TT.Abp.Weixin/TT.Abp.Weixin.csproj", "modules/TT.Abp.Weixin/"]
COPY ["http_modules/TT.HttpClient.Weixin/TT.HttpClient.Weixin.csproj", "http_modules/TT.HttpClient.Weixin/"]
RUN dotnet restore "src/TT.SoMall.IdentityServer/TT.SoMall.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/TT.SoMall.IdentityServer"
RUN dotnet build "TT.SoMall.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TT.SoMall.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TT.SoMall.IdentityServer.dll"]