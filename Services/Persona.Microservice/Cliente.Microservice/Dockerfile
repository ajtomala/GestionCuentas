
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 1387


COPY ./*.csproj ./
RUN dotnet restore
COPY . .

RUN dotnet build "Cliente.Microservice.csproj" -c Release -o out

RUN dotnet publish "Cliente.Microservice.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY --from=publish /app/out .

ENTRYPOINT ["dotnet", "Cliente.Microservice.dll"]

