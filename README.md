# FirstDotNet
Create First Web App Using Dot Net Technologie

>dotnet new webapi -n appName

---

**To run the Server**

>d

### install dependencies

dotnet add package Microsoft.EntityFrameworkCore --version 5.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.10
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.10


**start migrations**

dotnet ef migrations add InitialMigration

to watch changes u must connect in SqlServer as SA user and run :

>sqlcmd -S localhost -U SA
>use tempdb;
>go
>SELECT * FROM INFORMATION_SCHEMA.TABLES;
>go

and then u will see the name of database in our case (Catalog)

>dotnet ef migrations remove

change data in Model file , to be changed after in migration

>dotnet ef migrations add InitialMigration

then to update database

>dotnet ed database update
