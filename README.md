# E-Commerce Platform

Production-oriented E-Commerce application built with ASP.NET Core, React, and PostgreSQL.

> **Note:** This project is currently under active development (Work in Progress).

## 🏗 Architecture

The project follows Clean / Onion Architecture principles to ensure separation of concerns, testability, and maintainability.

- **`E_Commerce`** - API / Presentation layer (Controllers, Middlewares).
- **`E.Application`** - Application layer / Use Cases (Interfaces, DTOs, Business Logic).
- **`E.Domain`** - Core Business Domain (Entities, Value Objects, Domain Events).
- **`E.Infrastructure`** - Infrastructure and Persistence (EF Core, External Services, Repositories).

## 🛠 Technologies

- **Backend:** ASP.NET Core, C#, Entity Framework Core
- **Frontend:** React
- **Database:** PostgreSQL
- **DevOps / Tools:** Docker, Docker Compose

## 🚀 Quick Start (Getting Started)

The easiest way to run this project locally is using Docker.

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or your target version)
- [Node.js](https://nodejs.org/) (v18+)
- [Docker & Docker Compose](https://www.docker.com/)

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name