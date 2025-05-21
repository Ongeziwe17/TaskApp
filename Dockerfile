# official asp.net core runtime image
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

WORKDIR /app
EXPOSE 5000

# official .net sdk image for building app
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS build
WORKDIR /src

# copy project files and restore
COPY *.csproj ./
RUN dotnet restore

# copy everything else the build
COPY . ./
RUN dotnet publish "./TaskApp.csproj" -c Release -o /app/publish

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT [ "dotnet", "TaskApp.dll" ]