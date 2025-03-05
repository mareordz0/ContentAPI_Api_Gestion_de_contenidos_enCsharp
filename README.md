# 🚀 ContentAPI - API de Gestión de Contenidos

API desarrollada en C# para gestión básica de contenido (artículos/publicaciones), con operaciones CRUD y documentación integrada.

## 📋 Características principales
- **CRUD Completo**: Crear, leer, actualizar y eliminar contenidos
- **Documentación Automática**: Integración con Swagger/OpenAPI
- **Base de Datos**: Configuración con SQL Server y Entity Framework Core
- **Validaciones**: Reglas para campos obligatorios y longitud máxima
- **Pruebas**: Colección de Postman lista para usar

## 🛠 Tecnologías utilizadas
- **C#** (.NET 8)
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **Swagger** (OpenAPI)
- **Postman**


📡 Endpoints disponibles
Método	Ruta	Descripción
GET	/api/Contenido	Obtener todos los contenidos
POST	/api/Contenido	Crear nuevo contenido
PUT	/api/Contenido/{id}	Actualizar contenido
DELETE	/api/Contenido/{id}	Eliminar contenido

📚 Documentación técnica
La API incluye documentación interactiva con Swagger:

Descripción detallada de todos los endpoints

Pruebas directamente desde el navegador

Esquemas de request/response

📦 Estructura del proyecto
Copy
ContentAPI/
├── Controllers/      # Lógica de endpoints
├── Models/           # Entidades y DbContext
├── Migrations/       # Migraciones de base de datos
├── Properties/       # Configuraciones de compilación
└── appsettings.json  # Configuración de la aplicación
