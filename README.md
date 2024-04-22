# LemkaAPI...

LemkaAPI is a web api project made with .NET 6.

## Installation

Name the database "LemkaDB", then publish it to SQL Server 2016+.

### appsettings.json
```json
{
  "AppSettings": {
    "Secret": "...",
    "Issuer": "...",
    "Audience": "..."
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "AllowedHosts": "*"
}
```

## Usage
...

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
...
