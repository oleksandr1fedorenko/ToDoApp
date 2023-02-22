FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TodoAppBe/TodoAppBe/TodoAppBe.csproj", "TodoAppBe/"]
COPY ["TodoAppBe/TodoAppBe/TodoAppBe.csproj", "TodoAppBe/"]
RUN dotnet restore "TodoAppBe/TodoAppBe/TodoAppBe.csproj"
COPY . .
WORKDIR "/src/TodoAppBe"
RUN dotnet build "TodoAppBe/TodoAppBe/TodoAppBe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoAppBe/TodoAppBe/TodoAppBe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoAppBe.dll"]