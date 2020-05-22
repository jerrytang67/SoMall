FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 80

COPY ["publish/TT.SoMall.HttpApi/", "/app"]
FROM base AS final
WORKDIR /app
ENTRYPOINT ["dotnet", "TT.SoMall.HttpApi.Host.dll"]