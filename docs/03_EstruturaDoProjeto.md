# Estrutura do Projeto

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