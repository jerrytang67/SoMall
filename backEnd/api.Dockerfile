#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["modules/TT.Extensions/TT.Extensions.csproj", "modules/TT.Extensions/"]
COPY ["modules/TT.RabbitMq/TT.RabbitMq.csproj", "TT.RabbitMq/"]
COPY ["modules/TT.Abp.Shops/TT.Abp.Shops.csproj", "modules/TT.Abp.Shops/"]
COPY ["modules/TT.Abp.VisitorManagement/TT.Abp.VisitorManagement.csproj", "modules/TT.Abp.VisitorManagement/"]
COPY ["modules/TT.Abp.AppManagement/TT.Abp.AppManagement.csproj", "modules/TT.Abp.AppManagement/"]
COPY ["modules/TT.HttpClient.Weixin/TT.HttpClient.Weixin.csproj", "http_modules/TT.HttpClient.Weixin/"]
COPY ["modules/TT.Abp.Mall/TT.Abp.Mall.csproj", "modules/TT.Abp.Mall/"]
COPY ["modules/TT.Abp.Audit/TT.Abp.AuditManagement.csproj", "modules/TT.Abp.Audit/"]
COPY ["modules/TT.Abp.Weixin/TT.Abp.Weixin.csproj", "modules/TT.Abp.Weixin/"]
COPY ["modules/TT.Abp.OssManagement/TT.Abp.OssManagement.csproj", "modules/TT.Abp.OssManagement/"]
COPY ["modules/TT.Abp.Core/TT.Abp.Core.csproj", "modules/TT.Abp.Core/"]
COPY ["modules/TT.Abp.Cms/TT.Abp.Cms.csproj", "modules/TT.Abp.Cms/"]
COPY ["modules/TT.Abp.AccountManagement/TT.Abp.AccountManagement.csproj", "modules/TT.Abp.AccountManagement/"]
COPY ["modules/TT.Abp.FormManagement/TT.Abp.FormManagement.csproj", "modules/TT.Abp.FormManagement/"]
COPY ["src/TT.SoMall.EntityFrameworkCore/TT.SoMall.EntityFrameworkCore.csproj", "src/TT.SoMall.EntityFrameworkCore/"]
COPY ["src/TT.SoMall.EntityFrameworkCore.DbMigrations/TT.SoMall.EntityFrameworkCore.DbMigrations.csproj", "src/TT.SoMall.EntityFrameworkCore.DbMigrations/"]
COPY ["src/TT.SoMall.Application.Contracts/TT.SoMall.Application.Contracts.csproj", "src/TT.SoMall.Application.Contracts/"]
COPY ["src/TT.SoMall.Domain.Shared/TT.SoMall.Domain.Shared.csproj", "src/TT.SoMall.Domain.Shared/"]
COPY ["src/TT.SoMall.Domain/TT.SoMall.Domain.csproj", "src/TT.SoMall.Domain/"]
COPY ["src/TT.SoMall.HttpApi/TT.SoMall.HttpApi.csproj", "src/TT.SoMall.HttpApi/"]
COPY ["src/TT.SoMall.HttpApi.Host/TT.SoMall.HttpApi.Host.csproj", "src/TT.SoMall.HttpApi.Host/"]
COPY ["src/TT.SoMall.Application/TT.SoMall.Application.csproj", "src/TT.SoMall.Application/"]
RUN dotnet restore "src/TT.SoMall.HttpApi.Host/TT.SoMall.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/TT.SoMall.HttpApi.Host"
RUN dotnet build "TT.SoMall.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TT.SoMall.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TT.SoMall.HttpApi.Host.dll"]