# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj và restore packages
COPY ["Hung_Models.csproj", "./"]
RUN dotnet restore "Hung_Models.csproj"

# Copy toàn bộ source và publish
COPY . .
RUN dotnet publish "Hung_Models.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Hung_Models.dll"]
