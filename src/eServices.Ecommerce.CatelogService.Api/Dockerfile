#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["eServices.Ecommerce.CatelogService.Api/eServices.Ecommerce.CatelogService.Api.csproj", "eServices.Ecommerce.CatelogService.Api/"]
RUN dotnet restore "eServices.Ecommerce.CatelogService.Api/eServices.Ecommerce.CatelogService.Api.csproj"
COPY . .
WORKDIR "/src/eServices.Ecommerce.CatelogService.Api"
RUN dotnet build "eServices.Ecommerce.CatelogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eServices.Ecommerce.CatelogService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eServices.Ecommerce.CatelogService.Api.dll"]