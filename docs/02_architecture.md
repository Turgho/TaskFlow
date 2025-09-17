# 🏗 Arquitetura — TaskFlow

O projeto segue **Clean Architecture**, dividida em camadas bem definidas.

---

## 📂 Estrutura de Pastas

```
TaskFlow.sln
│
├─ TaskFlow.Api/                  # Camada Presentation
│   ├─ Controllers/
│   └─ Program.cs
│
├─ TaskFlow.Application/          # Camada Application
│   ├─ DTOs/
│   │   ├─ TodoCreateDto.cs
│   │   ├─ TodoUpdateDto.cs
│   │   └─ TodoReadDto.cs
│   ├─ Interfaces/
│   │   └─ ITodoRepository.cs
│   ├─ Validators/
│   │   ├─ TodoCreateValidator.cs
│   │   └─ TodoUpdateValidator.cs
│   └─ Services/
│       └─ TodoService.cs         # Lógica de aplicação
│
├─ TaskFlow.Domain/               # Camada Domain
│   └─ Entities/
│       └─ Todo.cs
│
├─ TaskFlow.Infrastructure/       # Camada Infrastructure
│   ├─ Data/
│   │   └─ TodoContext.cs
│   └─ Repositories/
│       └─ TodoRepository.cs
│
└─ TaskFlow.Tests/                # Camada Testes
    └─ TodoServiceTests.cs
```

---

## 🧱 Camadas

- **Domain** → Entidades, interfaces, regras de negócio.
- **Application** → Casos de uso, DTOs, validações, mapeamentos.
- **Infrastructure** → Persistência, repositórios, implementação de interfaces.
- **API** → Controllers, endpoints REST.
- **Tests** → Testes unitários e de integração.

---

## 🔄 Fluxo de Dados

1. **Controller** recebe a requisição.
2. **Application** processa o caso de uso.
3. **Domain** aplica regras de negócio.
4. **Infrastructure** persiste ou lê do banco.
5. **Controller** retorna resposta para o cliente.