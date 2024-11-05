# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything to the container and build the app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Use the .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Expose port 80 to make the app accessible outside the container
EXPOSE 80
ENTRYPOINT ["dotnet", "StarshipProject.dll"]
