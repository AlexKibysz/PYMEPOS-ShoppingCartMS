# Microservicio Carrito de Compra

Este microservicio está hecho basándome en el libro Microservices in .NET, Second Edition  - Gammelgaard, Christian Horsdal

## Configurar StyleCop

```sh
# Title: Agrego Paquete Nuget
dotnet add package StyleCop.Analyzers
```

luego creo en la raiz del proyecto un archivo
`stylecop.json`

### Agrego Reglas StyleCop

para buscar mas informacion de como armar este json con distintas reglas revisar:

<https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/Configuration.md>

```json
{
  "settings": {
    "documentationRules": {
      "companyName": "MiEmpresa",
      "copyrightText": "Copyright © MiEmpresa 2025",
      "xmlHeader": true,
      "documentExposedElements": true,
      "documentInternalElements": false,
      "documentPrivateElements": false,
      "documentInterfaces": true,
      "documentPrivateFields": false
    },
    "orderingRules": {
      "usingDirectivesPlacement": "outsideNamespace",
      "systemUsingDirectivesFirst": true,
      "elementOrder": [
        "kind",
        "accessibility",
        "constant",
        "field",
        "constructor",
        "property",
        "method",
        "event"
      ]
    },
    "namingRules": {
      "allowCommonHungarianPrefixes": false,
      "allowedHungarianPrefixes": [],
      "includeInferredTupleElementNames": true,
      "includeInferredAnonymousTypeMemberNames": true
    },
    "layoutRules": {
      "newlineAtEndOfFile": "require",
      "allowConsecutiveUsings": false,
      "allowConsecutiveBlankLines": false
    },
    "maintainabilityRules": {
      "allowMembersWithMultipleStatements": true,
      "maxLineLength": 120
    },
    "readabilityRules": {
      "allowBuiltInTypeAliases": true,
      "allowDefaultExpression": true,
      "allowNullLiteral": true
    }
  }
}
```

- **documentationRules** – Forzar comentarios XML para elementos públicos.

- **orderingRules**  
  - `using` fuera del namespace  
  - `System.*` primero  
  - Orden de elementos: constantes, campos, constructores, propiedades, métodos, etc.

- **namingRules** – Reglas básicas de nombres de variables y prefijos.

- **layoutRules** – Formato de líneas, saltos de línea al final de archivo, evitar líneas en blanco consecutivas.

- **maintainabilityRules** – Control de longitud máxima de línea y complejidad básica.

- **readabilityRules** – Permite alias de tipos (`int` vs `Int32`), expresiones por defecto y null literals.

## Entidades y Relaciones

Estaba entre crear la carpeta Dto en vez de Models, pero en este caso estas clases definen el dominio del microservicio por lo que serian Models

- Creo la carpeta *Models*
- Creo la Entidad *product*
- Creo la Entidad *shoppingCart* que contiene una lista de *product*

## Configuracion de HttpClientFactory o HttpClient

## Configuracion de Middlewares

### Configuracion de Polly



### Ponerle un volumen para persistencia de datos
por ahora no necesito

## Configuracion de EF Core
### Crear y Configurar el Context Model
```cs
using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartMS.Models;


public class ShoppingCartContext : DbContext //hago que ShoppingCartContext implemente DbContex
{
  //Inyecta la configuracion 
    public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
        : base(options)
    {
    }
    //Agrego los DbSet para crear las tablas correspondientes
    public DbSet<ShoppingCart> ShoppingCartItems
    {
        get; set;
    }

    public DbSet<Product> Products
    {
        get; set;
    }
}
```

#### Manejo de ConnectionString y Secrets

Vamos a agregarla al appsetings primero
```json
 "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=MiDb;User Id=sa;Password=TuPassword123!;"
  }
```

Esto lo vamos a hacer en el Program.cs ya que si vemos en el constructor inyecta la configuracion
```cs
builder.Services.AddDbContext<ShoppingCartContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```
Como vemos el program.cs tiene el builder.Configuration.GetConnectionString("DefaultConnection") que toma los datos del appsetings 


##### Uso de dotnet-secrets
Nuestra forma utilizando appsetings no es tan segura ni preparada para un ambiente productivo por lo que vamos a agregar el uso de dotnet-secrets

*Set a user secrets ID to enable secret storage*
```sh
dotnet user-secrets init
```


*Secret Desarrollo*
```sh 
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=MiDb;User Id=sa;Password=TuPassword123!;TrustServerCertificate=True;
```

## Docker, Kubernetes y Compose
### Bases de Datos
```sh
 podman pod create --name dev-sql-pod -p 1433:1433 
```


```sh
podman run -dt \                                      
  --pod dev-sql-pod \
  --name sql-server \
  -e 'ACCEPT_EULA=Y' \
  -e 'SA_PASSWORD=TuPassword123!' \
  -v sqlserver-data:/var/opt/mssql \
  mcr.microsoft.com/mssql/server:2022-latest

```Server=localhost,1433;Database=MiDb;User Id=sa;Password=TuPassword123!;TrustServerCertificate=True;