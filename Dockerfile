# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project and restore
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source and build
COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy the build output
COPY --from=build /out .

# Expose API port
EXPOSE 8080

# Run the application
CMD ["dotnet", "todo-api.dll"]
