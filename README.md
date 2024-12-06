# .NET Inventory DDD

Este proyecto es una plantilla inicial para una aplicación construida utilizando **Clean Architecture**, **Domain-Driven Design (DDD)** y **CQRS** en **.NET**. Proporciona una base sólida para desarrollar aplicaciones empresariales modulares, escalables y mantenibles.

---

## Estructura del Proyecto

El proyecto sigue una estructura modular basada en los principios de la arquitectura limpia:

- **`Api`**: Contiene la capa de presentación, incluyendo controladores y configuraciones relacionadas con las API.
- **`Application`**: Contiene los casos de uso y lógica específica de la aplicación (aplicación de CQRS).
- **`Domain`**: Define las entidades del dominio, agregados, value objects y reglas de negocio.
- **`Infrastructure`**: Incluye la implementación de persistencia, integraciones externas y configuraciones de infraestructura.

---

## Características Principales

1. **Clean Architecture**
   - Separación clara de responsabilidades entre capas.
   - Bajo acoplamiento y alta cohesión.

2. **Domain-Driven Design (DDD)**
   - Foco en el dominio central del negocio.
   - Uso de agregados, entidades y value objects para modelar el dominio.

3. **Command Query Responsibility Segregation (CQRS)**
   - Separación de comandos y consultas para optimizar rendimiento y escalabilidad.
   - Implementado a través de patrones como Mediator.

4. **Configuración Modular**
   - Fácil extensión de módulos y funcionalidades.

---

## Instalación y Configuración

### Requisitos Previos

- .NET 7 o superior.
- Base de datos (PostgreSQL, SQL Server, etc.).
- Herramienta CLI para migraciones (Ej: `dotnet-ef`).

### Instrucciones

1. **Clonar el Repositorio**
   ```bash
   git clone https://github.com/lucianoigit/.NET-Inventory-DDD
   cd .NET-Inventory-DDD
   ```

2. **Configurar la Base de Datos**
   - Actualiza el archivo `appsettings.json` en el proyecto `Api` con la cadena de conexión de tu base de datos.

3. **Ejecutar Migraciones**
   ```bash
   dotnet ef database update --project Infrastructure
   ```

4. **Ejecutar el Proyecto**
   ```bash
   dotnet run --project Api
   ```
   El servidor estará disponible en: `https://localhost:5001`

---

## Principios de Diseño

1. **Separación de Responsabilidades**
   - Cada capa tiene una responsabilidad clara.
   - La capa `Domain` no depende de detalles de implementación.

2. **Inversión de Dependencias**
   - Uso de interfaces para desacoplar las dependencias entre capas.

3. **CQRS**
   - Comandos: Modifican el estado de la aplicación.
   - Consultas: Recuperan información sin modificar el estado.

---

## Tecnologías Utilizadas

- **.NET 8**: Framework principal.
- **Entity Framework Core**: Para manejo de base de datos.
- **MediatR**: Para implementar CQRS.
- **FluentValidation**: Validación de modelos y comandos.
- **Swagger**: Documentación automática de la API.

---



