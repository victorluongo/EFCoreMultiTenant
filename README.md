# EFCoreMultiTenant
Reference guide for EFCore Multi Tenant method in Microsoft EntityFramework Core.



## Requirements

**.NET Core Framework**

https://dotnet.microsoft.com/download

**Visual Studio Code**

https://code.visualstudio.com/


## VS Code Extensions

**C# for Visual Studio Code (powered by OmniSharp)**

https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

**C# Extensions**

https://marketplace.visualstudio.com/items?itemName=kreativ-software.csharpextensions

**C# Snippets**

https://marketplace.visualstudio.com/items?itemName=jorgeserrano.vscode-csharp-snippets

**C# Full namespace autocompletion**

https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.namespace

**SQLite Database Viewer**

https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer


## Documentation

**Microsoft EntityFramework Core**

https://docs.microsoft.com/en-us/ef/core/

**Migrations**

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


## Project Creation Scripts

**Create new solution**

    dotnet new sln -n EFCoreMultiTenant

**Create new console project**

    dotnet new webapi -n EFCoreMultiTenant -o EFCoreMultiTenant -f net5.0

**Add project to solution**

    dotnet sln EFCoreMultiTenant.sln add EFCoreMultiTenant/EFCoreMultiTenant.csproj


## Project packages

**EntityFrameworkCore**

    dotnet add package Microsoft.EntityFrameworkCore --version 5.0.3

**EntityFrameworkCore Design**

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.3

**EntityFrameworkCore Tools**

    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.3

**SQLite**

    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.3

**NewtonsoftJson**

    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.0.0    


