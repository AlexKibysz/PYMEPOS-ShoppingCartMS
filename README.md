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

## Configuracion de EF Core
### Crear y Configurar el Context Model




## Docker, Kubernetes y Compose
