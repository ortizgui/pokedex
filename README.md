# Pokedex CRUD - NET Core

I am creating a basic CRUD in NET Core to study. The theme is Pokedex!

The goal is to implement improvements over time to train my skills.

## What I use in this project

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [Postman](https://www.postman.com/)
* [SQL Server 2019 - Container](https://hub.docker.com/r/microsoft/mssql-server-windows-express/)

## Creating SQL Server Container

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<<SQL_PASSWORD>>' -e 'MSSQL_PID=Express' --name mssql -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

## Configure database access

Configure **connectionString** on .\pokedex\appSettings.json.
Point the server, user and password. On the database, insert the name you want and it will be created on next step by Entity Framework (EF).

When connectionString is already configured, the next step is let EF configure the database for us. Use the command:

```
dotnet ef database update
```

## Running the project

Go to the .\pokedex directory and run the commands:

```
dotnet restore
dotnet run
```

**restore** will restore nuget's dependencies and **run** will run the project.