## ASP.NET Core on Mac 

# Docker 

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Password!' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
Unable to find image 'mcr.microsoft.com/mssql/server:2019-latest' locally


## Migration Commands in cli

dotnet ef migrations add InitialCreate

dotnet ef database update


## Reference 
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

https://learn.microsoft.com/en-us/ef/core/cli/dotnet

Changing .net version 
https://stackoverflow.com/questions/42077229/switch-between-dotnet-core-sdk-versions


