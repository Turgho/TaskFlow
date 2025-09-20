# ✅ TaskFlow — Gerenciador de Tarefas Minimalista

[![Status](https://img.shields.io/badge/status-em%20desenvolvimento-orange)](https://github.com/Turgho/TaskFlow)
[![Linguagem](https://img.shields.io/badge/Linguagem-C%23-blue)](https://docs.microsoft.com/dotnet/csharp/)
[![Último commit](https://img.shields.io/github/last-commit/Turgho/TaskFlow/dev)](https://github.com/Turgho/TaskFlow/commits/dev)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](./LICENSE)
[![Issues](https://img.shields.io/github/issues/Turgho/TaskFlow/dev)](https://github.com/seu-usuario/TaskFlow/issues)
[![Pull Requests](https://img.shields.io/github/issues-pr/Turgho/TaskFlow/dev)](https://github.com/Turgho/TaskFlow/pulls)

**TaskFlow** é uma API de lista de tarefas (ToDo List) construída em **.NET 8**, aplicando princípios de **Clean Architecture**, boas práticas de **DTOs**, **AutoMapper**, **FluentValidation** e persistência em **SQLite**.  
Ideal para treinar fundamentos de APIs RESTful e boas práticas de arquitetura.

> **Status atual:** Repositório público — desenvolvimento ativo.  
> **Escopo visível aqui:** somente o MVP inicial (CRUD de tarefas).  
> Documentação completa disponível em `docs/`.

---

## 🎯 MVP 1 — Recursos disponíveis neste repositório

Implementação mínima viável para demonstrar o fluxo básico:

- ✅ **Criar tarefa** (título, descrição)
- ✅ **Listar tarefas** (todas ou filtradas por status)
- ✅ **Marcar como concluída**
- ✅ **Atualizar título e descrição**
- ✅ **Remover tarefa**
- ✅ **Persistência SQLite** com migrations (documentação em `docs/database.md`)
- ✅ **Swagger UI** para explorar endpoints

> Recursos como autenticação, usuários e categorias estão planejados para fases futuras (documentados em `docs/roadmap.md`).

---

## 📂 Documentação (pasta `docs/`)

Toda a documentação do projeto está organizada na pasta `docs/`.  
Navegue pelos arquivos para ver detalhes:

- `docs/01_overview.md` — Visão geral
- `docs/02_architecture.md` — Arquitetura e camadas (Clean Architecture)
- `docs/03_database.md` — Modelagem e DDL (SQLite)
- `docs/04_setup.md` — Guia de instalação e uso
- `docs/05_tests.md` — Estratégia de testes e exemplos
- `docs/06_roadmap.md` — Funcionalidades futuras

---

## 🧭 Tecnologias

- **Backend:** C# / .NET 9 (API REST)
- **Banco de Dados:** SQLite + Entity Framework Core
- **Validação:** FluentValidation
- **Mapeamento:** AutoMapper
- **Documentação:** Swagger / OpenAPI
- **Testes:** xUnit (planejado)

---

## 🛠 Como rodar o projeto

Leia o guia completo em `docs/04_setup.md`.

```bash
git clone https://github.com/seu-usuario/TaskFlow.git
cd TaskFlow

docker compose up --build
```

📍 A API estará disponível em:
https://localhost:5001/swagger
