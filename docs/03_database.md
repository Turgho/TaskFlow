# 🗄 Banco de Dados — TaskFlow

O **TaskFlow** utiliza SQLite como banco de dados para persistir usuários e tarefas.
As tabelas foram modeladas de forma compatível com as entidades `User` e `TodoTask`.

---

## 🧱 Script SQL (DDL)

```sql
-- Usuários
CREATE TABLE Users (
       Id TEXT PRIMARY KEY,                    -- UUIDv7
       Username TEXT NOT NULL,
       Email TEXT NOT NULL UNIQUE,
       PasswordHash TEXT NOT NULL,
       CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
       UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
       LastLoginAt DATETIME                    -- nullable
);

-- Tarefas
CREATE TABLE TodoTasks (
       Id TEXT PRIMARY KEY,                     -- UUIDv7
       UserId TEXT NOT NULL,                    -- Relacionamento com Users
       Title TEXT NOT NULL,
       Description TEXT,                        -- nullable
       Category INTEGER NOT NULL DEFAULT 0,     -- enum TodoTaskCategory
       Priority INTEGER NOT NULL DEFAULT 0,     -- enum TodoTaskPriority (Low=0)
       Status INTEGER NOT NULL DEFAULT 0,       -- enum TodoTaskStatus (Pending=0)
       CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
       UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
       DoneAt DATETIME,                         -- nullable
       FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
```

> Obsercações sobreo os enums:
> - Category → Personal=1, Work=2, Study=3, Other=4
> - Priority → Low=0, Medium=1, High=2
> - Status → Pending=0, Done=1

---

## 🔮 Evoluções Futuras

- Adicionar tags ou múltiplas categorias para cada tarefa.
- Adicionar relacionamentos entre usuários (ex.: equipes ou compartilhamento de tarefas).
- Possível integração com notificações e histórico de alterações.