## ASP.NET Core on Mac 

# Docker 

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Password!' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
Unable to find image 'mcr.microsoft.com/mssql/server:2019-latest' locally


## Migration Commands in cli

dotnet ef migrations add InitialCreate

dotnet ef database update


## Run and Build 

dotnet build 
dotnet run



## Reference 
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

https://learn.microsoft.com/en-us/ef/core/cli/dotnet

Changing .net version 
https://stackoverflow.com/questions/42077229/switch-between-dotnet-core-sdk-versions


# Auto Mapper 

https://docs.automapper.org/en/stable/


# Video Sessions

 https://www.youtube.com/watch?v=eURGzVP-FZs&list=PL3ewn8T-zRWgO-GAdXjVRh-6thRog6ddg&index=2

 

