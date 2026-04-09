# 🗂️ TaskManager

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?style=for-the-badge&logo=blazor)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-18-316192?style=for-the-badge&logo=postgresql)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp)

**🇧🇷 [Português](#-sobre-o-projeto) | 🇺🇸 [English](#-about-the-project)**

</div>

---

## 🇧🇷 Português

### 📋 Sobre o Projeto

O **TaskManager** é uma aplicação web fullstack de gerenciamento de tarefas, desenvolvida com foco em produtividade e organização. Permite criar, organizar, filtrar e acompanhar tarefas com prioridades e prazos.

### ✨ Funcionalidades

- 🔐 **Autenticação** — Cadastro e login com JWT
- ➕ **Criar tarefas** — Título, descrição, prioridade e prazo
- ✅ **Concluir tarefas** — Marcar como concluída com um clique
- 🗑️ **Deletar tarefas** — Remoção rápida
- 🔍 **Filtros** — Todas, Pendentes, Concluídas, Alta Prioridade, Atrasadas
- 📊 **Contadores** — Visão geral do total, pendentes, concluídas e atrasadas
- ⚠️ **Detecção de atraso** — Tarefas com prazo vencido são destacadas automaticamente

### 🛠️ Tecnologias

| Camada | Tecnologia |
|--------|-----------|
| Frontend | Blazor WebAssembly (.NET 9) |
| Backend | ASP.NET Core Web API (.NET 9) |
| Banco de Dados | PostgreSQL 18 |
| ORM | Entity Framework Core |
| Autenticação | JWT Bearer Token |
| Estilo | CSS customizado + Inter font |

### 🚀 Como Rodar Localmente

#### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 18](https://www.postgresql.org/download/)

#### 1. Clone o repositório

```bash
git clone https://github.com/Wendell-Roma/TaskManager.git
cd TaskManager
```

#### 2. Configure o banco de dados

Crie um banco chamado `taskmanager` no PostgreSQL e configure a connection string em `TaskManager.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=taskmanager;Username=postgres;Password=SUA_SENHA"
  },
  "JwtSettings": {
    "SecretKey": "sua-chave-secreta-super-longa-minimo-32-chars"
  }
}
```

> ⚠️ **Nunca commite o `appsettings.json` com senhas reais!** Use o `appsettings.Example.json` como referência.

#### 3. Execute as migrations

```bash
cd TaskManager.API
dotnet ef database update
```

#### 4. Rode a API

```bash
cd TaskManager.API
dotnet run
```

A API estará disponível em `http://localhost:5289`

#### 5. Rode o frontend

```bash
cd TaskManager.Web
dotnet run
```

O frontend estará disponível em `http://localhost:5028`

### 📁 Estrutura do Projeto

```
TaskManager/
├── TaskManager.API/          # Web API (endpoints REST)
├── TaskManager.Core/         # Entidades e interfaces
├── TaskManager.Infrastructure/ # Repositórios e contexto EF
└── TaskManager.Web/          # Frontend Blazor WebAssembly
    ├── Layout/               # Layouts da aplicação
    ├── Pages/                # Páginas (Login, Register, Tasks)
    ├── Services/             # AuthService, TaskService
    ├── Models/               # DTOs e modelos
    └── wwwroot/              # Arquivos estáticos (CSS, JS)
```

---

## 🇺🇸 English

### 📋 About the Project

**TaskManager** is a fullstack web task management application, built with a focus on productivity and organization. It allows you to create, organize, filter, and track tasks with priorities and deadlines.

### ✨ Features

- 🔐 **Authentication** — Register and login with JWT
- ➕ **Create tasks** — Title, description, priority, and due date
- ✅ **Complete tasks** — Mark as done with one click
- 🗑️ **Delete tasks** — Quick removal
- 🔍 **Filters** — All, Pending, Completed, High Priority, Overdue
- 📊 **Counters** — Overview of total, pending, completed, and overdue tasks
- ⚠️ **Overdue detection** — Tasks past their deadline are automatically highlighted

### 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Blazor WebAssembly (.NET 9) |
| Backend | ASP.NET Core Web API (.NET 9) |
| Database | PostgreSQL 18 |
| ORM | Entity Framework Core |
| Authentication | JWT Bearer Token |
| Styling | Custom CSS + Inter font |

### 🚀 How to Run Locally

#### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 18](https://www.postgresql.org/download/)

#### 1. Clone the repository

```bash
git clone https://github.com/Wendell-Roma/TaskManager.git
cd TaskManager
```

#### 2. Configure the database

Create a database called `taskmanager` in PostgreSQL and set the connection string in `TaskManager.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=taskmanager;Username=postgres;Password=YOUR_PASSWORD"
  },
  "JwtSettings": {
    "SecretKey": "your-super-long-secret-key-minimum-32-chars"
  }
}
```

> ⚠️ **Never commit `appsettings.json` with real passwords!** Use `appsettings.Example.json` as a reference.

#### 3. Run migrations

```bash
cd TaskManager.API
dotnet ef database update
```

#### 4. Run the API

```bash
cd TaskManager.API
dotnet run
```

The API will be available at `http://localhost:5289`

#### 5. Run the frontend

```bash
cd TaskManager.Web
dotnet run
```

The frontend will be available at `http://localhost:5028`

### 📁 Project Structure

```
TaskManager/
├── TaskManager.API/            # Web API (REST endpoints)
├── TaskManager.Core/           # Entities and interfaces
├── TaskManager.Infrastructure/ # Repositories and EF context
└── TaskManager.Web/            # Blazor WebAssembly frontend
    ├── Layout/                 # Application layouts
    ├── Pages/                  # Pages (Login, Register, Tasks)
    ├── Services/               # AuthService, TaskService
    ├── Models/                 # DTOs and models
    └── wwwroot/                # Static files (CSS, JS)
```

---

<div align="center">

Feito com 💜 por [Wendell Roma](https://github.com/Wendell-Roma)

</div>
