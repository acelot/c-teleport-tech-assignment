# C-Teleport Airports Service API

## Quick start

```sh
docker-compose build && docker-compose up
```

## Endpoints

| URL                                           | Description                               |
|-----------------------------------------------|-------------------------------------------|
| http://localhost:8000/swagger                 | API documentation via Swagger UI          |
| http://localhost:8000/swagger/v1/swagger.json | API documentation in Open API JSON format |
| http://localhost:8000/distance                | Distance API main endpoint                |

## Development prerequisites

- Microsoft .NET 5.0 ([https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script](dotnet-install.sh))
- Docker version 18 or higher
- Visual Studio Code with [https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp](C# extension)

## Building

Regular build:
```sh
dotnet build
```

Publish:
```sh
dotnet publish -c Release
```

## Testing

```sh
dotnet test
```