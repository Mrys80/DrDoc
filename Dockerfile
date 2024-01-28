FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM  mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ./src /src/DrDoc.WebApi/

WORKDIR /src/DrDoc.WebApi

RUN dotnet restore --force "DrDoc.WebApi/DrDoc.WebApi.csproj" -v n

RUN dotnet build "DrDoc.WebApi/DrDoc.WebApi.csproj" -c Release -o "/app/build"

RUN dotnet publish "DrDoc.WebApi/DrDoc.WebApi.csproj" -c Release -o "/app/publish"

FROM base AS publish

WORKDIR /app/publish

COPY --from=build /app/publish .

RUN rm -rf /etc/localtime
RUN ln -s /usr/share/zoneinfo/Asia/Tehran /etc/localtime

ENTRYPOINT ["dotnet","DrDoc.WebApi.dll","--urls=http://0.0.0.0:90"]
