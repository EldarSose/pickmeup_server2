FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

RUN apt-get update && apt-get install -y krb5-user libgssapi-krb5-2

COPY --from=build /app .
ENTRYPOINT ["dotnet", "PickMeUp.User.API.dll"]
