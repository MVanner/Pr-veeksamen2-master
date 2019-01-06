FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY GiftAPI/GiftAPI.csproj GiftAPI/
COPY Entities/Entities.csproj Entities/
RUN dotnet restore GiftAPI/GiftAPI.csproj
COPY . .
WORKDIR /src/GiftAPI
RUN dotnet build GiftAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GiftAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GiftAPI.dll"]
