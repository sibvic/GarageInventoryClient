## Multi-stage build for Blazor WebAssembly client (served by Nginx)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers (paths relative to build context)
COPY GarageInventoryClient.csproj ./
RUN dotnet restore GarageInventoryClient.csproj

# copy everything else and publish
COPY . .
WORKDIR /src
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Use nginx to serve the static site
FROM nginx:alpine AS runtime
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80

# simple healthcheck
HEALTHCHECK --interval=30s --timeout=5s --retries=3 CMD wget -qO- http://localhost/ || exit 1


