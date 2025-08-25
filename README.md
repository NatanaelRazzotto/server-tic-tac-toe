# 📌 Aplicação Servidora de um Jogo da Velha 

API desenvolvida em **.NET 8** para gerenciar e armazenar informações de partidas de jogo da velha entre dois usuários. A aplicação registra usuários, jogadas e histórico de partidas.
---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/)  
- [Npgsql.EntityFrameworkCore.PostgreSQL 8.0.4](https://www.npgsql.org/efcore/) *(PostgreSQL provider para EF Core)*  
- [DotNetEnv 3.1.1](https://github.com/tonerdo/dotnet-env) *(leitura de variáveis de ambiente via `.env`)*  
- [Swashbuckle.AspNetCore 6.6.2](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) *(Swagger para documentação de API)*  

---

## 📂 Estrutura do Projeto
A aplicação segue o padrão **DDD** (Domain-Driven Design) e está organizada da seguinte forma:

├── src

│   ├── server_tic_tac_toe.Application     # Casos de uso / Serviços

│   │   ├── server_tic_tac_toe.Application.DTOs

│   │   ├── server_tic_tac_toe.Application.Services

│   │   ├── server_tic_tac_toe.Application.UseCases        

│   ├── server_tic_tac_toe.Domain          # Entidades e regras de negócio

│   │   ├── server_tic_tac_toe.Domain.Entities

│   │   ├── server_tic_tac_toe.Domain.Enums

│   │   ├── server_tic_tac_toe.Domain.Exceptions

│   │   ├── server_tic_tac_toe.Domain.Repositories // Contratos (interfaces)

│   │   ├── server_tic_tac_toe.Domain.UseCases // Contratos (interfaces)

│   ├── server_tic_tac_toe.Infrastructure  # Acesso a dados, repositórios, migrations

│   │   ├── server_tic_tac_toe.Infrastructure.Persistence

│   │   ├── server_tic_tac_toe.Infrastructure.Repositories

│   ├── server_tic_tac_toe.Presentation             # Camada de apresentação (Controllers)

│   │   ├── server_tic_tac_toe.Presentation.Controllers

---

## ⚙️ Configuração do Ambiente
1️⃣ Pré-requisitos
- .NET SDK 8
- Docker 
- Visual Studio Code
- 
**Verifique se o SDK Está instalado:**
  
dotnet --list-sdks

**A aplicação está configurada para não exigir HTTPS, mas é recomendado validar os certificados locais caso deseje usar HTTPS:**

dotnet dev-certs https --trust

dotnet dev-certs https --check

---
## 2️⃣ Variáveis de Ambiente
**O Arquivo .env foi postado no repositório, para melhor finalidade de testes, mais segue aqui também, as variaveis de ambiente:**

*OBS: Estas informações serão usadas para criar o banco em DOCKER e rodar o SERVER.*

POSTGRES_DB_HOST="[SEU IP/DOMINIO]"

POSTGRES_DB_PORT="5432"

POSTGRES_DB_NAME="[NOME DO SEU BANCO]" 

POSTGRES_DB_USER="[USUARIO DE ACESSO AO BANCO]" 

POSTGRES_DB_PASSWORD="[SENHA DE ACESSO AO BANCO]" 


APP_WEB_CLIENT="http://localhost:8081"  # URL ou domínio do cliente permitido pelo CORS

---
## ▶️ Executando a Aplicação

1️⃣ Iniciar o Docker
Em primeiro momento se faz necessário iniciar o DOCKER, use o comando (dentro da pastas do projeto):
docker-compose up -d

2️⃣ Restaurar dependências

Em seguida se for a primeira execução apos o clone:
dotnet restore

3️⃣ Aplicar migrações ao banco

dotnet ef database update

4️⃣ Rodar a API

dotnet run

Após isso a API deve estar rodando em:

👉 http://localhost:5180

👉 https://localhost:7157

## 📖 Documentação da API

Com o Swagger habilitado, acesse:

👉 http://localhost:5180/swagger



