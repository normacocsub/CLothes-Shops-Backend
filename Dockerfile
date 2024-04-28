FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClotheShops/", "ClotheShops/"]
COPY ["Entity/", "Entity/"]
COPY ["Infraestructura/", "Infraestructura/"]
COPY ["Logica/", "Logica/"]
COPY ["Datos/", "Datos/"]

RUN dotnet restore "ClotheShops/ClotheShops.csproj" -r linux-arm64
COPY . .
WORKDIR "/src/ClotheShops"
RUN dotnet build "ClotheShops.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/ClotheShops"
RUN dotnet publish "ClotheShops.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClotheShops.dll"]