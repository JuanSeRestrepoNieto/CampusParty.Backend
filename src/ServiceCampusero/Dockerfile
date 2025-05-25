FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copiar los csproj y restaurar dependencias
COPY Model/*.csproj ./Campuseros.Model/
COPY Core/*.csproj ./Campuseros.Core/
COPY Data/*.csproj ./Campuseros.Data/
COPY Api/*.csproj ./Campuseros.Api/

RUN dotnet restore ./Campuseros.Api/Api.csproj

# Copiar todo el código
COPY . .

# Publicar
WORKDIR /src/Api
RUN dotnet publish Api.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Api.dll"]