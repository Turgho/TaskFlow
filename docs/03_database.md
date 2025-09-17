# 🗄 Banco de Dados — TaskFlow

O **TaskFlow** utiliza **SQLite** como banco de dados para persistir as tarefas.

---

## 📋 Modelagem

| Campo           | Tipo       | Descrição |
|-----------------|-----------|-----------|
| **Id**          | INTEGER   | PK, autoincrement |
| **Titulo**      | TEXT      | Obrigatório |
| **Descricao**   | TEXT      | Opcional |
| **Concluida**   | BOOLEAN   | Padrão: false |
| **DataCriacao** | DATETIME  | Preenchido automaticamente |
| **DataConclusao** | DATETIME | Opcional |

---

## 🧱 Script SQL (DDL)

```sql
CREATE TABLE Todo (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Titulo TEXT NOT NULL,
    Descricao TEXT,
    Concluida BOOLEAN NOT NULL DEFAULT 0,
    DataCriacao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataConclusao DATETIME
);
```

---

## 🔮 Evoluções Futuras

- Adicionar usuários (relacionamento 1:N com tarefas).
- Adicionar categorias ou tags.
- Adicionar campo de prioridade.