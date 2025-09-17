# 🧪 Testes — TaskFlow

O projeto planeja utilizar **xUnit** para testes unitários.

---

## 📋 Estratégia de Testes

- **Unitários** → Testar casos de uso e validações.
- **Integração** → Testar endpoints reais com banco em memória.
- **Validações** → Testar regras de negócio com FluentValidation.

---

## 📚 Estrutura de Pastas

```plaintext
TaskFlow.Tests/
└── TaskFlow.Tests/
├── Application/
├── Infrastructure/
└── Api/
```

---

## ✅ Cobertura Esperada

- Criar tarefa → sucesso e falha.
- Atualizar tarefa → sucesso e falha.
- Marcar como concluída → sucesso.
- Remover tarefa → sucesso.
