# StarShipProject_SWAPI_Exercise
This was a Coding Exercise I did for Goengineer as part of the application project. I showcases a  .NET 8 ASP.NET Core MVC project using bootstrap and SQL server with EntityCoreFramework with UI and full CRUD functionality

Intructions on how to run this App

* Make sure that SQL server is installed
* Make sure that .NET 8 SDK is installed

Clone the Repository 
"git clone https://github.com/Camthack13/StarShipProject_SWAPI_Exercise.git"
"cd starshipproject"

Configure the Database connection
- In the project folder open the appsettings.json and appsettings.Development.json and
update the connection strings to match your local database

Run the Database Migrations
"dotnet ef database update"

Run the application
"dotnet run"

Access the application
- Follow the link "http://localhost:5036"
