#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TT.SoMall.IdentityServer/TT.SoMall.IdentityServer.csproj", "src/TT.SoMall.IdentityServer/"]
COPY ["src/TT.SoMall.EntityFrameworkCore.DbMigrations/TT.SoMall.EntityFrameworkCore.DbMigrations.csproj", "src/TT.SoMall.EntityFrameworkCore.DbMigrations/"]
COPY ["modules/TT.Abp.VisitorManagement/TT.Abp.VisitorManagement.csproj", "modules/TT.Abp.VisitorManagement/"]
COPY ["modules/TT.Abp.Shops/TT.Abp.Shops.csproj", "modules/TT.Abp.Shops/"]
COPY ["modules/TT.Abp.AppManagement/TT.Abp.AppManagement.csproj", "modules/TT.Abp.AppManagement/"]
COPY ["modules/TT.Core/TT.Core.csproj", "modules/TT.Core/"]
COPY ["http_modules/TT.HttpClient.Weixin/TT.HttpClient.Weixin.csproj", "http_modules/TT.HttpClient.Weixin/"]
COPY ["modules/TT.Abp.Mall/TT.Abp.Mall.csproj", "modules/TT.Abp.Mall/"]
COPY ["TT.RabbitMq/TT.RabbitMq.csproj", "TT.RabbitMq/"]
COPY ["modules/TT.Abp.Audit/TT.Abp.AuditManagement.csproj", "modules/TT.Abp.Audit/"]
COPY ["modules/TT.Abp.Weixin/TT.Abp.Weixin.csproj", "modules/TT.Abp.Weixin/"]
COPY ["modules/TT.Abp.OssManagement/TT.Abp.OssManagement.csproj", "modules/TT.Abp.OssManagement/"]
COPY ["modules/TT.Abp.Core/TT.Abp.Core.csproj", "modules/TT.Abp.Core/"]
COPY ["src/TT.SoMall.Domain/TT.SoMall.Domain.csproj", "src/TT.SoMall.Domain/"]
COPY ["src/TT.SoMall.Domain.Shared/TT.SoMall.Domain.Shared.csproj", "src/TT.SoMall.Domain.Shared/"]
COPY ["src/TT.SoMall.EntityFrameworkCore/TT.SoMall.EntityFrameworkCore.csproj", "src/TT.SoMall.EntityFrameworkCore/"]
COPY ["modules/TT.Abp.Cms/TT.Abp.Cms.csproj", "modules/TT.Abp.Cms/"]
COPY ["modules/TT.Abp.AccountManagement/TT.Abp.AccountManagement.csproj", "modules/TT.Abp.AccountManagement/"]
COPY ["modules/TT.Abp.FormManagement/TT.Abp.FormManagement.csproj", "modules/TT.Abp.FormManagement/"]
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