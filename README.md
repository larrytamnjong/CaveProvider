# CaveProvider

Backend Application for the CaveProvider School Management System.

Before running this code, you should have experience with the following:
- C#
- ASP.NET
- ASP.NET Identity
- Entity Framework

## Getting Started

### Prerequisites
 - Visual Studio
 - Dot Net SDK
 - Postgres
 - SqlServer

### How to Run
1. Make sure you configure both the API and Identity API as startup projects
   ![image](https://github.com/user-attachments/assets/90e34587-232f-4c40-8c06-03be7035d586)
2. The Solution has 2 database providers one for Postgres and one for SqlServer. The default is for Postgress you can change the database provider in the ```appsettings.json``` file of both the API and the Identity API.
   You can set the Provider to either **Postgres** or **SqlServer**


### How to Contribute
1. Fork the repository.
2. Clone your fork:
   ```
   git clone https://github.com/yourusername/caveprovider.git
   ```
   ```
   cd caveprovider
   ```
   ```
   dotnet run
   ```
