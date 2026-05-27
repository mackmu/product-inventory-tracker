# Multi-Tier Product Inventory Management System

A collaborative, multi-tier product inventory management platform built with C# and the .NET ecosystem. The system features an architectural focus on strict security parameters, robust CRUD operations, decoupled data layers, and an automated Azure DevOps CI/CD deployment pipeline.

## Core Technology Stack

* **Backend Framework:** .NET / C#
* **Database Management:** SQL Server / SQL Server Management Studio (SSMS)
* **Architecture Patterns:** Repository Pattern, Separation of Concerns (SoC)
* **DevOps & Automation:** Azure DevOps CI/CD Pipeline (`azure-pipelines.yml`)
* **Version Control Workflow:** Git Flow (Feature/Fix branching methodologies managed via Git Bash / SourceTree)

---

## Architectural Decisions & Engineering

To ensure long-term maintainability, testability, and scalability, this application abandons tightly coupled architectures in favor of solid design principles:

### The Repository Pattern
Data access logic is completely decoupled from the core business layer. By introducing an abstraction layer between the database queries and application controllers, the database engine can be swapped or unit-tested using mock repositories without breaking consumer endpoints.

### Database Constraints & Integrity
The underlying SQL Server layer enforces strict data validation. Quantity management logic balances state transitions carefully, preventing invalid entry states (such as negative stock values) and handling edge-case validation gracefully at the application boundary.

### Production CI/CD Pipeline
Every code integration automatically triggers the built-in Azure DevOps engine. The integrated `azure-pipelines.yml` script compiles the solution, executes the automated test suites using `dotnet test`, and validates building blocks before deployment targets are reached.

---

## Collaborative Workflow & Git Hygiene

This repository serves as a model for collaborative enterprise standards:
* **Linear Branching Hierarchy:** Features and bug fixes are developed on isolated tracks (`feature/`, `cleanup/`) before passing through an upstream merge chain from `Dev` ➔ `Test` ➔ `main`.
* **Clean History Management:** Meticulous stage-filtering ensures zero configuration bloat, keeping development artifacts localized and public portfolio histories clear and readable.

---

## Getting Started

### Prerequisites
* .NET SDK
* SQL Server & SSMS

### Local Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/mackmu/product-inventory-tracker.git

2. Navigate into the root project directory:
   ```bash
   cd product-inventory-tracker

3. Build the solution and restore dependencies: 
   dotnet build

4. Run the application layer:
   dotnet run --project ProductInventoryTracker
   
