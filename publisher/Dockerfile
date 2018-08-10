FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY publisher/publisher.csproj publisher/
RUN dotnet restore publisher/publisher.csproj
COPY . .
WORKDIR /src/publisher
RUN dotnet build publisher.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish publisher.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
