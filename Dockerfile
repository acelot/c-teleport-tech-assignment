FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS builder

WORKDIR /app

COPY ./ ./

RUN dotnet publish -c Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

WORKDIR /app

COPY --from=builder /app/CTeleport.AirportsService.Api/bin/Release/net5.0/publish ./

CMD [ "dotnet", "CTeleport.AirportsService.Api.dll" ]