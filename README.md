> This application was developed for Web
Application module, as coursework portfolio project @ WIUT by student ID: 00013292

# Key Store Application
### This repository contains the source code for a Key Store application, designed to securely store and manage keys, with basic CRUD operations and authentication mechanisms.

## Features
Secure Storage: Safely store keys, including API keys, license keys, and other sensitive data.
Basic CRUD Operations: Perform Create, Read, Update, and Delete operations for KeyItems and KeyTypes.
Authentication and Authorization: Implement mechanisms for authentication and authorization.
Scalable Architecture: Utilize a two-layer architecture (API, Data Access Layer) with Dependency Injection for scalability, maintainability, and testability.
Future Features: Consider adding additional functionality such as statistics and a user-friendly web interface (front-end app).
Architecture
The application is built around a two-layer architecture with a separate API layer and Data Access Layer (DAL). Dependency Injection is used to manage dependencies between these layers, ensuring scalability and maintainability.

## Dependencies
- Microsoft.EntityFrameworkCore.SqlServer - Version 8.0.3
- Microsoft.EntityFrameworkCore.Tools - Version 8.0.3
- AutoMapper

## Getting Started
1. Clone the repository: `git clone https://github.com/havaian/WAD.CW1.00013292`
2. Install the dependencies: `dotnet restore`
3. Build the project: `dotnet build`
4. Run the application: `dotnet run`

## References
- [GitHub Repository](https://github.com/havaian/WAD.CW1.00013292)
- [Microsoft.EntityFrameworkCore.SqlServer NuGet Package](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [EF Core NuGet Packages](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Tools NuGet Package](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
- [AutoMapper](https://automapper.org/)