#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DrDoc.WebApi/DrDoc.WebApi.csproj", "DrDoc.WebApi/"]
RUN dotnet restore "DrDoc.WebApi/DrDoc.WebApi.csproj"
COPY . .
WORKDIR "/src/DrDoc.WebApi"
RUN dotnet build "DrDoc.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DrDoc.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrDoc.WebApi.dll","--urls=http://0.0.0.0:90"]