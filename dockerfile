# --------------------
# Build
# --------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies first
COPY JAXPORT/JAXPORT.csproj JAXPORT/
RUN dotnet restore JAXPORT/JAXPORT.csproj

# Copy application source
COPY JAXPORT/ JAXPORT/

WORKDIR /src/JAXPORT

# Build/publish release
RUN dotnet publish JAXPORT.csproj \
    -c Release \
    -o /app/publish


# --------------------
# Runtime
# --------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "JAXPORT.dll"]