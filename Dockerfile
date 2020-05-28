FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TelegramBot/TelegramBot.csproj", "src/TelegramBot/"]
COPY ["src/TelegramBot.Core/TelegramBot.Core.csproj", "src/TelegramBot.Core/"]
RUN dotnet restore "src/TelegramBot/TelegramBot.csproj"
COPY . .
WORKDIR "/src/src/TelegramBot"
RUN dotnet build "TelegramBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelegramBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TelegramBot.dll