📦 Orderly API

API REST desenvolvida em ASP.NET Core para gerenciamento de produtos e pedidos, com controle de estoque, múltiplos itens por pedido e validação de regras de negócio.

O projeto simula um cenário real de e-commerce/sistema de pedidos, seguindo boas práticas de backend, arquitetura limpa e padronização REST.

🚀 Tecnologias Utilizadas

ASP.NET Core Web API

Entity Framework Core

AutoMapper

SQLite / InMemory

Swagger (OpenAPI)

C#

🧠 Funcionalidades
📦 Produtos

Criar produto

Listar todos os produtos

Buscar produto por ID

Atualizar produto

Remover produto

Controle de estoque

🧾 Pedidos

Criar pedido com múltiplos produtos

Validação de estoque antes da criação

Cálculo automático do total do pedido

Listar pedidos

Buscar pedido por ID

Cada pedido armazena:

Nome do cliente

Data de criação

Itens do pedido

Quantidade e preço unitário por produto

🛡️ Regras de Negócio Implementadas

Um pedido não pode ser criado sem itens

Produtos precisam existir para serem adicionados ao pedido

Estoque é validado antes da criação do pedido

Estoque é reduzido automaticamente após o pedido

Total do pedido é calculado no backend

🏗️ Estrutura do Projeto
Orderly.Api
├── Controllers
│   ├── ProductsController.cs
│   └── OrdersController.cs
├── Models
│   ├── Product.cs
│   ├── Order.cs
│   └── OrderItem.cs
├── DTOs
│   ├── ProductDto.cs
│   ├── CreateProductDto.cs
│   ├── OrderDto.cs
│   ├── CreateOrderDto.cs
│   └── OrderItemDto.cs
├── Data
│   └── AppDbContext.cs
├── Profiles
│   └── MappingProfile.cs
└── Program.cs

▶️ Como Executar o Projeto
Pré-requisitos

.NET SDK instalado

Visual Studio ou VS Code

Passos
git clone https://github.com/annaclarasul/OrderlyProject.git


Abra o projeto no Visual Studio e execute com F5.

Acesse o Swagger:

https://localhost:7205/swagger/index.html

🔎 Exemplos de Uso
➕ Criar Produto

POST /api/Products

{
  "name": "Notebook",
  "description": "Notebook Dell i7",
  "price": 4500,
  "stock": 5
}

🧾 Criar Pedido

POST /api/Orders

{
  "customerName": "João Silva",
  "items": [
    { "productId": 1, "quantity": 2 },
    { "productId": 2, "quantity": 1 }
  ]
}

📄 Resposta
{
  "id": 1,
  "customerName": "João Silva",
  "createdAt": "2025-12-16T15:10:54",
  "total": 9200,
  "items": [
    { "productId": 1, "quantity": 2, "unitPrice": 4500 },
    { "productId": 2, "quantity": 1, "unitPrice": 200 }
  ]
}
