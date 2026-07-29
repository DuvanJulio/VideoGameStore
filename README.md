# 🎮 VideoGameStore API

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![MariaDB](https://img.shields.io/badge/MariaDB-10.11-003545?logo=mariadb&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20%2F%20Onion-blue)
![JWT Auth](https://img.shields.io/badge/Security-JWT%20Bearer-green)

**VideoGameStore API** es el backend de una tienda digital de videojuegos desarrollado en **.NET 10**. Gestiona el catálogo de juegos digitales, membresías de usuarios y el procesamiento de pedidos, con autenticación y control de acceso por roles.

El proyecto está construido bajo los principios de **Clean Architecture (Arquitectura Limpia)** y aplica el patrón de diseño **CQRS (Command Query Responsibility Segregation)** con **MediatR**.

---

## 🏛️ Arquitectura del Proyecto

El sistema está organizado en 4 capas principales para garantizar una separación clara de responsabilidades:

```text
VideoGameStore/
├── Domain/              # Núcleo de la aplicación: Entidades, Enums, Excepciones y Contratos.
├── Application/         # Reglas de negocio: CQRS (Commands & Queries con MediatR), DTOs e Interfaces.
├── Infrastructure/      # Implementación técnica: EF Core (MariaDB), Repositorios, JWT y Middlewares.
└── Presentation/        # Entrada HTTP: Controladores RESTful, Configuración OpenAPI y Scalar.
```

### 🧩 Patrones y Prácticas Utilizadas
- **Clean Architecture / Onion Architecture**
- **CQRS** (MediatR)
- **Repository Pattern & Unit of Work**
- **Data Seeding Automático** (Roles iniciales: `Admin`, `Cliente`)
- **Manejo Global de Excepciones** mediante Middleware y respuestas `Failure<T>`
- **Encriptación Segura de Contraseñas** con `BCrypt.Net-Next`

---

## 🛠️ Tecnologías y Librerías

- **Framework:** .NET 10 Web API
- **Base de Datos:** MariaDB / MySQL
- **ORM:** Entity Framework Core 10 (Pomelo / Microting)
- **Autenticación & Autorización:** JWT (JSON Web Tokens) Bearer
- **Mediador & CQRS:** MediatR 14
- **Validación:** FluentValidation 12
- **Documentación API:** OpenApi & Scalar.AspNetCore 2

---

## 🚀 Funcionalidades Principales

### 🔐 Autenticación y Autorización
- Registro de usuarios con contraseña encriptada (BCrypt).
- Inicio de sesión con generación de JWT Bearer Token.
- Control de acceso por Roles (`Admin` y `Cliente`).
- Contexto de usuario autenticado inyectable (`ICurrentUser`).

### 🎮 Catálogo de Videojuegos y Productos
- Gestión CRUD de videojuegos, plataformas y tipos de productos.
- Paginación y filtrado de resultados (`PagedResponse<T>`).

### 🏷️ Membresías y Entregas
- Gestión de tipos de membresías y suscripciones.
- Tipos de entrega configurables para los productos digitales.

### 🛒 Pedidos y Órdenes
- Procesamiento de órdenes de compra.
- Estado de órdenes mediante Enums (`Pending`, `Completed`, `Cancelled`).

---

## ⚙️ Configuración e Instalación

### Prerrequisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [MariaDB](https://mariadb.org/) o MySQL Server
- Herramienta CLI de Entity Framework Core (`dotnet tool install -g dotnet-ef`)

### 1. Clonar el repositorio
```bash
git clone https://github.com/tu-usuario/VideoGameStore.git
cd VideoGameStore/VideoGameStore
```

### 2. Configurar la Base de Datos y JWT
Asegúrate de configurar la cadena de conexión a tu base de datos MariaDB y la clave secreta JWT en `appsettings.json` o mediante User Secrets:

```json
{
  "AppEnvironment": {
    "DATABASE_STRING_BUILDER": {
      "ConnectionString": "Server=localhost;Database=videogamestore;User=root;Password=tu_password;"
    }
  },
  "Jwt": {
    "Key": "TuClaveSecretaSuperSeguraDeAlMenos32Caracteres!",
    "Issuer": "VideoGameStoreApi",
    "Audience": "videogamestore-client"
  }
}
```

### 3. Ejecutar las Migraciones (Creación de Base de Datos y Roles iniciales)
```bash
dotnet ef database update
```

### 4. Ejecutar el Proyecto
```bash
dotnet run
```

---

## 📚 Documentación e Interacción con la API (Scalar / OpenAPI)

Una vez iniciada la aplicación en entorno de desarrollo (`Development`), puedes acceder a la documentación interactiva e interfaz visual de pruebas en:

- **Scalar UI:** `https://localhost:7174/scalar/v1` (o el puerto configurado)
- **OpenAPI Json:** `https://localhost:7174/openapi/v1.json`

---

## 👤 Autor

Desarrollado por **Duván Julio**.

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.
