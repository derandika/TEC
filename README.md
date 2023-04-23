# TEC

# Introduction 
- TEC API solution projects built on Visual Studio 2022 and .NET core 7.0
- TEC UI project built on VS Code and Angular 14

# Solution Project Structure
- TEC.API - Aspnet core api project for api controllers(course controller), REST API method endpoints and automapper configured for dto to model mapping.
- TEC.Domain - Domain classes and Data transfer object classes.
- TEC.Repository - Repository generic classes and unitofwork pattern. EF core code first migration to initialise the database.
- TEC.API.Test - Unit tests for controller methods with xunit and mock 
- TEC.UI - Angular UI project with course crud components, services, modules etc.

# Getting Started
- Clone the git repo to local and open the TEC.sln solution file in VS2022
- Rebuild the solution to restore packages and build projects.
- Update the appsettings.json in TEC.API project with database connection string.
- Set the default project to TEC.Repository from package manager console and run the update-database command to initialise the database 
- Run the TEC.API startup project to access the swagger.
- Open the TEC.UI folder from VS Code and run the npm install to restore the node_modules
- Run the ng serve --o to start the angular ui project.
- Click on the Add Course nav bar link to add new course. Courses nav bar link to view the courses.  