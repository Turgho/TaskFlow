# 🔧 Guia de Instalação — TaskFlow

Este guia explica como configurar e executar o TaskFlow usando Docker e Docker Compose.
Dessa forma, você não precisa instalar manualmente o SDK do .NET ou o SQLite localmente.

---

## 📦 Pré-requisitos

- [Docker](https://docs.docker.com/get-started/get-docker/) instalado.
- [Docker Compose](https://docs.docker.com/compose/install/) instalado.

Verifique se estão corretamente instalados:

```bash
docker --version
docker compose version
```

---

## 🚀 Como rodar o projeto

1. Clone o repositório:

```bash
git clone https://github.com/Turgho/TaskFlow.git
cd TaskFlow
```

2. Suba os containers com Docker Compose:

```bash
docker compose up --build
```

Isso irá:
- Construir a imagem do projeto .NET
- Criar um container com o backend rodando
- Criar o banco SQLite dentro do container (armazenado em volume)

3. Acesse a API via Swagger:

Por padrão, o backend ficará disponível em:

```plaintext
http://localhost:5000
```

---

## 🧪 Rodando os testes

Você pode rodar os testes dentro do container com:

```bash
docker compose exec app dotnet test
```