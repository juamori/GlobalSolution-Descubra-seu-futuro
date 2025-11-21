# 🎓 Descubra Seu Futuro

> Projeto desenvolvido como parte da disciplina de **Orientação Profissional**, com o propósito de ajudar pessoas em início de carreira ou em transição profissional a entender o mercado, descobrir novas oportunidades e planejar o próprio futuro de forma estratégica.

---

## 🧭 Propósito do Projeto

O **Descubra Seu Futuro** tem como objetivo principal **ajudar pessoas a se conectarem com trilhas de aprendizado, mentores e oportunidades** que promovam inclusão produtiva e desenvolvimento profissional.

Com base em dados e competências do mercado, o sistema permite:
- Visualizar **competências e habilidades em alta**;
- Descobrir **trilhas de aprendizado** alinhadas a diferentes setores;
- Conectar-se a **mentores e áreas de empregabilidade**.

---

## 🧩 Estrutura do Projeto

O projeto segue o padrão **ASP.NET Core MVC**, utilizando **Entity Framework Core** para persistência de dados e **SQL Server LocalDB** como banco de dados.

### **Camadas e Pastas**
```📁 DescubraSeuFuturo
┣ 📂 Controllers # Controladores MVC (CRUD)
┣ 📂 Data # Contexto de banco de dados (AppDbContext)
┣ 📂 Migrations # Controle de versões do banco
┣ 📂 Models # Classes das entidades principais
┣ 📄 appsettings.json # Configurações da aplicação
┣ 📄 Program.cs # Ponto de entrada da aplicação
┗ 📄 DescubraSeuFuturo.csproj 
```
---

## 🧠 Modelos Principais

| Entidade | Descrição |
|-----------|------------|
| `Competencia` | Representa uma competência valorizada no mercado de trabalho. |
| `Curso` | Contém informações sobre cursos relacionados a áreas de desenvolvimento. |
| `Empregabilidade` | Relaciona oportunidades de emprego e áreas em crescimento. |
| `Habilidade` | Conjunto de habilidades técnicas e comportamentais. |
| `Mentor` | Profissional que pode orientar os usuários em suas trajetórias. |
| `Setor` | Segmentos e ramos de atuação do mercado. |
| `TrilhaAprendizado` | Caminhos de aprendizado sugeridos para o desenvolvimento profissional. |
| `Usuario` | Representa a pessoa que usa a aplicação. |

---
## 📖 Documentação Técnica

O projeto foi desenvolvido em **ASP.NET Core MVC** com **Entity Framework Core** e **SQL Server LocalDB**.  
Segue o fluxo principal de funcionamento:

1. O usuário acessa o sistema via navegador.
2. As páginas de CRUD permitem cadastrar e visualizar dados como Competências, Trilhas, Cursos e Mentores.
3. O `AppDbContext` faz a conexão entre as entidades e o banco de dados.
4. Todas as tabelas são geradas automaticamente pelas Migrations.

---

## ⚙️ Tecnologias Utilizadas

- **.NET 8.0**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **C#**
- **SQL Server LocalDB**
- **Bootstrap** (para o layout padrão das views)

---

## 🚀 Como Executar o Projeto Localmente

### 1. Clonar o repositório:
```bash
git clone https://github.com/seuusuario/descubraseufuturo.git
cd descubraseufuturo
```
### 2. Restaurar dependências:
```
dotnet restore
```

### 3. Aplicar as migrações:
```
dotnet ef database update
```

### 4. Rodar o projeto:
```
dotnet run
```

### O sistema estará disponível em:
```
https://localhost:5001
```
---

## Versionamento da API

Esta API utiliza versionamento via URL. A versão atual implementada é **v1**.
As rotas seguem o padrão: `/api/v{version}/[controller]`.

Exemplos de endpoints (v1):
- `GET /api/v1/jobs` — lista todas as vagas.
- `GET /api/v1/jobs/{id}` — obtém detalhes de uma vaga específica.
- `POST /api/v1/jobs` — cria uma nova vaga.
- `PUT /api/v1/jobs/{id}` — atualiza uma vaga existente.
- `DELETE /api/v1/jobs/{id}` — remove uma vaga.

Observação: o versionamento está configurado em `Program.cs` com `ApiVersioning` e rotas do tipo `Route("api/v{version:apiVersion}/[controller]")`.


---

## Documentação via Swagger

A documentação interativa da API está exposta via Swagger (Swashbuckle). Após rodar a aplicação localmente, acesse:

- `https://localhost:5001/swagger` (HTTPS)
- ou `http://localhost:5000/swagger` (HTTP)

No Swagger você pode ver todos os endpoints, modelos de entrada/saída e testar os requests diretamente pelo navegador.


---

## Banco de Dados

O projeto está configurado por padrão para usar **SQLite** (arquivo local) via Entity Framework Core — isso facilita execução local e correção automática.
- Connection string no `appsettings.json` (chave `DefaultConnection`): `Data Source=descubra_seu_futuro.db`.
- Para migrar o banco (aplicar migrations):
  ```
  dotnet ef database update
- Caso prefira usar SQL Server, altere a DefaultConnection em appsettings.json para algo como:
```
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DescubraSeuFuturo;Trusted_Connection=True;"
```
- Em Program.cs substitua UseSqlite por UseSqlServer.
---

## Vídeo demonstrativo

Link do vídeo demonstrativo (máx. 5 minutos): **COLE_AQUI_O_LINK_DO_YOUTUBE**

---

## 🔄 Fluxo de Dados

![Fluxo de Dados](Docs/Fluxo.png)

## 🧩 Funcionalidades Implementadas
```
✅ CRUD completo para todas as entidades
✅ Migrations e persistência com EF Core
✅ Interface gerada automaticamente com Scaffold
✅ Estrutura modular e organizada
✅ Código limpo e comentado
```
## 🤝 Autoria 
- Julia Amorim RM99609
- Lana Leite RM551143
- Matheus Cavasini RM97722
