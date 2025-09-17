# Banco de Dados

| Campo         | Tipo     | Restrição/Descrição                   |
| ------------- | -------- | ------------------------------------- |
| Id            | INTEGER  | PK, autoincrement                     |
| Titulo        | TEXT     | Obrigatório, mínimo 3 caracteres      |
| Descricao     | TEXT     | Opcional, até 500 caracteres          |
| Concluida     | BOOLEAN  | Padrão: false                         |
| DataCriacao   | DATETIME | Preenchido automaticamente ao criar   |
| DataConclusao | DATETIME | Opcional, preenchido quando concluída |

## Estrutura da Tabela

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