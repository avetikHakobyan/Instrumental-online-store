# Instrumental-online-store

Beat/instrumental online store web application that allows artists/record labels to purchase an instrumental (DVD) and the appropriate licenses online to record a song or simply make a profit out of it.

- Languages used: C#, JavaScript, cshtml, CSS
- Frameworks used: .NET MVC, Blazor, Bootstrap, jQuery

Objectives:
* Create a .NET Core MVC application
* Use Data-first Entity Framework to generate the classes for the data model and database
* Use Code-first Entity Framework to create and manipulate the data model and database
* Use LINQ queries to manipulate the data in the database
* Add Authentication and Authorization to a project using identity
* Set up and use ReST Web Services
* Use SOAP Web Services
* Provide JavaScript access to .NET Web Services via SPA

To run this web application successfully, you need 2 SQL Server databases

-Steps to set up the store and identity databases:

1. Open SSMS and connect to an account
2. Click New Query
3. Paste the script inside "H60Assignment3DB_avh_script.sql"
4. Click Execute
5. Repeat step 2 to 4 for "H60Assignment3Identity_avh_script.sql"

It should create 2 databases: H60Assignment3DB_avh_rc and H60Assignment3Identity_avh_rc

-Change values of User id and password to yours in:

avhH60A03\avhH60Store\avhH60Store\appsettings.json
avhH60A03\avhH60Store\avhH60Services\appsettings.json
avhH60A03\avhH60Store\avhH60Customer\appsettings.json

Everything should be running smoothly

See the file "Test account credentials.txt" to login with different roles
