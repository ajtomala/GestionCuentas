
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 1387


COPY ./*.csproj ./
RUN dotnet restore
COPY . .

RUN dotnet publish "Cuentas.Microservicio.Ui.csproj" -c Release -o out

RUN dotnet build "Cuentas.Microservicio.Ui.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY --from=publish /app/out .

ENTRYPOINT ["dotnet", "Cuentas.Microservicio.Ui.dll"]
