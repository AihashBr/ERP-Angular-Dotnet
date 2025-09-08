# Backend Structure - ERP

This document describes the folder structure, the projects created in each one of them, the purpose of each project, and the references between them for the ERP backend.

---

## Folder Structure

src/  
├── Api/  
├── Application/  
├── Domain/  
└── Infrastructure/  

---

### Project Details

- **Api**  
  Project type: **ASP.NET Core Web API**.  
  Responsible for exposing HTTP endpoints, handling authentication, configuring services, middlewares, and frontend integration.

- **Application**  
  Project type: **Class Library (.NET)**.  
  Contains application logic, use cases, services, interfaces, and DTOs.  
  Acts as an intermediate layer between the domain and infrastructure.

- **Domain**  
  Project type: **Class Library (.NET)**.  
  Contains business entities, value objects, enums, and pure business rules.  
  This layer does not depend on any other.

- **Infrastructure**  
  Project type: **Class Library (.NET)**.  
  Contains the concrete implementation of data access (e.g., Entity Framework Core), external services, repositories, and other technical details.

---

## Project References

To maintain separation of concerns and dependencies, project references are configured as follows:

| Referencing Project | Referenced Projects                           | Purpose                                                                                  |
|---------------------|-----------------------------------------------|------------------------------------------------------------------------------------------|
| **Application**     | Domain                                        | To use entities, models, and business rules defined in the Domain layer                  |
| **Infrastructure**  | Application, Domain                           | To implement the contracts defined in Application and access entities from Domain         |
| **Api**             | Application, Infrastructure, Domain           | To expose the application, use the logic from Application, and the implementation from Infrastructure |

---

## Why this organization?

- Facilitates system maintenance and scalability.  
- Enables isolated testing in each layer.  
- Follows the **Clean Architecture** pattern, widely used in professional projects.  
- Clearly separates business rules from technical infrastructure.  

---

For more details, check the dedicated documentation for each layer in the `docs/` folder.  