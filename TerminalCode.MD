//Setup solution and project

//Buatkan solution
dotnet new sln -n FasKesY  

//Buatkan project
dotnet new webapi -n API
dotnet new claslib -n Domain
dotnet new claslib -n Infrastructure
dotnet new claslib -n Application
dotnet new claslib -n Representation

//Tambahkan reference ke Solution
dotnet sln add API/API.csproj 
dotnet sln add Domain/Domain.csproj 
dotnet sln add Infrastructure/Infrastructure.csproj
dotnet sln add Application/Application.csproj
dotnet sln add Representation/Representation.csproj

//Set Reference
//Domain ke Application
cd Application
dotnet add reference ../Domain/Domain.csproj

//Dependency Project To API
cd API
dotnet add reference ../Application/Application.csproj
dotnet add reference ../Infrastructure/Infrastructure.csproj
dotnet add reference ../Representation/Representation.csproj

//Set Dependency
Domain - MediatR
Domain - FluentValdation.DependencyInjectionExtensions 
Infrastructure - Microsoft.Extensions.DependencyIjection.Abstrations


//Configuration Dependecy Injection
Application - Public Static Class DependencyInjection


//Program.cs
builder.Services
    .AddApplication()
    .AddRepresentation()
    .AddInfrastructure();
// Using Serilog
// Dependency SeriLog.AspNetCore on API Project

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console());


//Appsetting
"SeriLog" :  {
    "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo" : [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "Logs/log-.txt",
          "rollingInterval": "Day",
          "roolOnFileSizeLimit": true,
          "formatter": "Serilog.Formatting.Compact.CompactJsonFormatter, Serilog"
        }
      }
    ],
    "Enrich": ["FromLogContext", "WithMachineName", "WithThreadId"]
  }