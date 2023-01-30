

<h1 align="center">AvanadeEstudosAPI</h1>

![GitHub](https://img.shields.io/github/license/kdsreis/AvanadeEstudosAPI?color=gree)

## 💻 About 

Study project in .NET6 C#, under the guidance of career advisor Felipe Pimentel addressing the following topics:

- Have more than 1 project in the solution
- Use the following primitive types (int, bool, datetime, string, arrays (List or Collections))
- Have 1 example of each OOP pillar
- Use SOLID principles
- Have 1 example of Design Pattern (Creation, Behavior or structure)
- Have a relationship between objects (1:1 or 1:n or n:n)
- Use an ORM
- Have a unit test
- Use Swagger to document the API
- Create a README.md

The Project must be a CRUD and the data persisted in a Database running on Docker in WSL2.

## 📁 Libraries

- AutoMapper
- FluentValidation
- Azure Key Vault

## ⚙️ORM

- Entity Framework

## Commands

# Install Entity Framework on Infra layer

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

# Install ef migrations tool

dotnet tool install --global dotnet-ef --version 5.0.1

# Create the migration

dotnet ef migrations add InitialMigration

# Update database with migration

dotnet ef database update

# Install AutoMapper

dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# Install Azure Key Vault

dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.Configuration.AzureKeyVault
dotnet add package Azure.Security.KeyVault.Secrets


---
