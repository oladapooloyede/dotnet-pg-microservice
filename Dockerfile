# Stage 1: Build
FROM registry.access.redhat.com/ubi9/dotnet-100 AS build
USER 0
WORKDIR /src

COPY src/*.csproj ./
RUN dotnet restore

COPY src/ ./
RUN dotnet publish -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM registry.access.redhat.com/ubi9/dotnet-100-aspnet AS runtime
WORKDIR /app

COPY --from=build /app/publish .

USER 1001

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "dotnet-pg-microservice.dll"]
