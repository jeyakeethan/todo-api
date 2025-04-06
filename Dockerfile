# Use .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /out

# Install EF Core tools globally
RUN dotnet tool install --global dotnet-ef

# Use .NET Runtime for the final container
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy compiled app
COPY --from=build /out .

# Expose API port (adjust if needed)
EXPOSE 5194

# Run DB migrations and start the app
CMD ["sh", "-c", "dotnet ef database update && dotnet todo-api.dll"]
