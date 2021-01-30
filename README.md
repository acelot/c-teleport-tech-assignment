# C-Teleport Airports Service API

## Quick start

```sh
docker-compose build && docker-compose up
```

## Endpoints

| URL                                           | Description                               |
|-----------------------------------------------|-------------------------------------------|
| http://localhost:5000/swagger                 | API documentation via Swagger UI          |
| http://localhost:5000/swagger/v1/swagger.json | API documentation in Open API JSON format |
| http://localhost:5000/distance                | Distance API main endpoint                |

Distance API example URLs:

- [Distance between Novosibirsk (OVB) and Moscow (SVO) in miles](http://localhost:5000/distance?origin=OVB&destination=SVO)
- [Distance between Moscow (DME) and Los Angeles (LAX) in kilometers](http://localhost:5000/distance?origin=DME&destination=LAX&unit=kilometers)

## Development prerequisites

- Microsoft .NET 5.0 ([dotnet-install.sh](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script))
- Docker version 18 or higher
- Visual Studio Code with [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

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