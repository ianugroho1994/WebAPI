# Web API - Boilerplate
this repo is a ASP NET Web Server boilerplate to make any web api project start faster

# Prerequisite
- .NET 6 SDK
- Visual Studio 2022
- Swagger

# Project structure
```sh
- root
  -- WebAPI
      -- Program.cs
  -- domains
      --- <domain-details>
          ---- Controllers
          ---- repository
          ---- usecase
          ---- test
  -- common
      --- Enums
      --- Helpers
      --- Interfaces
      --- Models
      --- Consumer.cs
      --- EventMessengger.cs
      --- ModuleRepository.cs
      --- Producer.cs
```

# Design Pattern
## Producer - Consumer
```sh
 ----------                     ----------                     ----------
|          |      Register     |          |        Get        |          |
|          | ----------------> |          | ----------------> |          |
|          |                   |  Module  |                   |          |
| Producer |     register      |          |     accesses      | Consumer |
|          | any class library |Repository| any class library |          |
|          |  that implement   |          |  that implement   |          |
|          |      IModule      |          |      IModule      |          |
|          | ----------------> |          | ----------------> |          |
 ----------                     ----------                     ----------
 ```

