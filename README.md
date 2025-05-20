# 🚀 StudyBattle API - ASP.NET

An educational API built with .NET for managing challenges and tasks. Users complete tasks step by step, earn scores based on complexity and streaks, and unlock new content as they progress.

## 📌 Features

- ✅ Create challenges and tasks
- 🔒 Unlock tasks in sequence
- 🧠 Track user progress and task completion
- 🧮 Dynamic score calculation (complexity + streak)
- 🗂️ Categorization by themes (e.g., Math, Geography)

## 🛠️ Tech Stack

- **.NET 8.0** — Backend Framework  
- **Entity Framework Core** — ORM for data access  
- **SQL Server** — Relational Database  
- **AutoMapper** — Mapping between entities and DTOs  
- **Swagger (Swashbuckle)** — API documentation  
- **RESTful Architecture**  
- **Dependency Injection** — Clean, testable services  
- **Repository Pattern** — Abstracted data layer 

## 📁 Project Structure

📦 **StudyBattleApi**  
- `/Controllers` → API endpoints  
- `/Services` → Business logic  
- `/Repositories` → Data access layer  

📦 **StudyBattleCore**  
- `/DTOs` → Data Transfer Objects  
- `/Entities` → Database models  
- `/Mapper` → Object mapping configuration  
- `/Enums` → Enum types used across the app  
- `/Migrations` → Entity Framework database migrations  
- `/Data` → Database context and configuration  
- `/Utils` → Extensions and utility classes  
