FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Prøveeksamen2/Prøveeksamen2.csproj Prøveeksamen2/
COPY Entities/Entities.csproj Entities/
RUN dotnet restore Prøveeksamen2/Prøveeksamen2.csproj
COPY . .
WORKDIR /src/Prøveeksamen2
RUN dotnet build Prøveeksamen2.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Prøveeksamen2.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Prøveeksamen2.dll"]
