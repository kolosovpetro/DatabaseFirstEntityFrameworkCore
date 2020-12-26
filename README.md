# Database First with Entity Framework Core

Simple example of Database-First approach using Entity Franework Core.

## Packages required

- `Microsoft.EntityFrameworkCore.Design`
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `Microsoft.EntityFrameworkCore.SqlServer`

## CLI commands

- `dotnet ef dbcontext scaffold "Data Source=DESKTOP-P87PH2B;Initial Catalog=CodeFirstEntityFramework;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o SqlServerScaffold`

- `dotnet ef dbcontext scaffold "Server=localhost;User Id=postgres;Password=postgres;Database=CodeFirstEntityFramework;" Npgsql.EntityFrameworkCore.PostgreSQL -o PostgreSqlScaffold`

## Use case

Consider the case when we have a connection string to some database we want to reverse engineer. 

Consider the database 

	[CodeFirstEntityFrameworkCore](https://github.com/kolosovpetro/CodeFirstEntityFrameworkCore)

We have following connection strings:

- `"Server=localhost;User Id=postgres;Password=postgres;Database=CodeFirstEntityFramework;"`
- `"Data Source=DESKTOP-P87PH2B;Initial Catalog=CodeFirstEntityFramework;Integrated Security=true;"`

Using the commands: 

- PostgreSQL: 

	`dotnet ef dbcontext scaffold "Server=localhost;User Id=postgres;Password=postgres;Database=CodeFirstEntityFramework;" Npgsql.EntityFrameworkCore.PostgreSQL -o PostgreSqlScaffold`

- MS SQL Server: 

	`dotnet ef dbcontext scaffold "Data Source=DESKTOP-P87PH2B;Initial Catalog=CodeFirstEntityFramework;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o SqlServerScaffold`