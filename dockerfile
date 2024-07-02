# Utilizar la imagen base de .NET 8.0 SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establecer el directorio de trabajo en /app
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código de la aplicación y construirla
COPY . ./
RUN dotnet publish -c Release -o out

# Utilizar la imagen base de .NET 8.0 Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Establecer el directorio de trabajo en /app
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/out ./

# Exponer el puerto que la aplicación escuchará
EXPOSE 80

# Establecer el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "TareasApi.dll"]
