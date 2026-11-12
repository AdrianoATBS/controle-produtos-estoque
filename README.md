# Controle de Produtos e Estoque

**API REST para gerenciamento de produtos, categorias e controle de movimentações de estoque, desenvolvida com C# e .NET 8.**

##  Preview

\<!-- Adicione aqui capturas de tela da documentação Swagger -->

\<!-- Exemplo: ![Controle de Produtos e Estoque - Swagger]\(./docs/screenshots/swagger.png) -->

##  Descrição

O **Controle de Produtos e Estoque** é uma API REST desenvolvida com o objetivo de praticar conceitos de desenvolvimento backend utilizando C# e .NET 8, com foco principalmente na modelagem e no relacionamento entre entidades.

O projeto foi construído para aprofundar conhecimentos sobre como diferentes entidades se relacionam dentro de uma aplicação, utilizando produtos, categorias e movimentações de estoque como principais elementos do domínio.

A aplicação permite cadastrar e gerenciar categorias e produtos, além de registrar movimentações de entrada e saída de estoque. Também disponibiliza consultas para acompanhar o histórico de movimentações e obter informações relacionadas aos produtos.

Mais do que implementar operações CRUD, o projeto representa uma oportunidade de compreender como os relacionamentos entre entidades são modelados e utilizados na prática, além de aplicar conceitos de arquitetura em camadas, persistência de dados e separação de responsabilidades.

##  Funcionalidades

As funcionalidades foram organizadas em três áreas principais: Categorias, Produtos e Estoque.

### Categorias

- Cadastro de categorias.
- Consulta de todas as categorias.
- Busca de categoria por identificador.
- Alteração do nome de uma categoria.
- Desativação de categoria.
- Reativação de categoria.
- Exclusão de categoria.

### Produtos

- Cadastro de produtos vinculados a categorias.
- Consulta de todos os produtos.
- Busca de produto por identificador.
- Busca de produtos por categoria.
- Alteração das informações de um produto.
- Desativação de produto.
- Reativação de produto.
- Exclusão de produto.

### Controle de estoque

- Registro de movimentações de entrada e saída.
- Atualização da quantidade disponível em estoque.
- Consulta de movimentações por produto.
- Consulta da última movimentação de um produto.
- Consulta de todas as movimentações.
- Filtragem de movimentações por período.

## Stack Tecnológica

As tecnologias e bibliotecas utilizadas no desenvolvimento foram:

| Tecnologia / Biblioteca | Aplicação                                                                |
| ----------------------- | ------------------------------------------------------------------------ |
| C#                      | Linguagem utilizada no desenvolvimento da aplicação.                     |
| .NET 8                  | Plataforma utilizada para construção da API.                             |
| ASP.NET Core            | Criação dos Controllers, endpoints e processamento das requisições HTTP. |
| Entity Framework Core 8 | Mapeamento objeto-relacional e persistência dos dados.                   |
| SQL Server              | Banco de dados relacional utilizado pela aplicação.                      |
| FluentValidation        | Validação dos dados recebidos pelas operações.                           |
| Swashbuckle.AspNetCore  | Geração da documentação interativa da API com Swagger.                   |
| Docker                  | Containerização da aplicação e do banco de dados.                        |
| Docker Compose          | Orquestração dos containers da API e do SQL Server.                      |

##  Decisões Técnicas

Durante o desenvolvimento, algumas decisões foram tomadas para melhorar a organização, a manutenção e a separação de responsabilidades da aplicação.

### Clean Architecture em camadas

A solução foi organizada em quatro projetos: API, Application, Domain e Infrastructure.

Essa abordagem foi escolhida para separar responsabilidades, evitando concentrar as regras de negócio, os fluxos da aplicação, a comunicação HTTP e os detalhes de persistência em um único projeto.

Com essa separação, cada camada possui uma responsabilidade específica, facilitando a manutenção e a evolução do sistema.

### Relacionamento entre entidades

Um dos principais objetivos do projeto foi praticar a modelagem e o relacionamento entre diferentes entidades.

Foram definidas três entidades principais:

- `Categoria`: representa as categorias utilizadas para organizar os produtos.
- `Produto`: representa os produtos cadastrados, relacionados a uma categoria.
- `MovimentacaoEstoque`: representa as operações de entrada e saída realizadas no estoque de um produto.

Essa modelagem permite representar os relacionamentos entre os dados e trabalhar com propriedades de navegação e chaves estrangeiras utilizando o Entity Framework Core.

### Repository Pattern

Foi utilizado o padrão Repository para abstrair as operações de acesso aos dados.

A Application utiliza interfaces que definem os contratos dos repositórios, enquanto a Infrastructure contém suas implementações utilizando o Entity Framework Core.

Essa decisão reduz o acoplamento entre os casos de uso e os detalhes de persistência.

### Use Cases

As operações da aplicação foram organizadas em casos de uso específicos, agrupados por responsabilidade.

Essa abordagem permite que cada operação tenha seu próprio fluxo de execução, facilitando a organização do código e evitando concentrar diferentes responsabilidades em uma única classe.

### FluentValidation

Foi utilizada a biblioteca FluentValidation para definir regras de validação das requisições.

Essa separação permite manter as validações de entrada organizadas, sem concentrá-las diretamente nos Controllers ou misturá-las com os fluxos dos casos de uso.

### Dependency Injection

Foi utilizado o mecanismo de injeção de dependências do .NET para registrar e disponibilizar os serviços da aplicação.

Os registros foram organizados por responsabilidade, permitindo que os Controllers recebam os casos de uso por meio de interfaces e que os casos de uso recebam suas respectivas dependências.

### Tratamento centralizado de exceções

Foi desenvolvido um Middleware próprio para capturar exceções durante o processamento das requisições.

O Middleware identifica os tipos de exceção e os converte em respostas HTTP padronizadas, centralizando o tratamento dos erros e evitando a repetição de blocos `try/catch` nos Controllers.

### Containerização com Docker

Foi utilizado Docker para empacotar a aplicação em uma imagem e executar a API e o SQL Server em containers separados.

O Docker Compose foi utilizado para definir os serviços, a comunicação entre os containers e a persistência dos dados do banco por meio de volumes.

O Dockerfile utiliza uma estratégia multi-stage, separando a etapa de compilação da etapa de execução, permitindo utilizar uma imagem de runtime menor para executar a API.

##  Arquitetura

O projeto utiliza uma organização baseada em **Clean Architecture em camadas**, dividida em quatro projetos:

### API

Responsável pela comunicação HTTP com os clientes, disponibilização dos endpoints, Controllers, Middlewares e configuração inicial da aplicação.

### Application

Responsável pela coordenação dos casos de uso, validação das requisições e comunicação com as abstrações dos repositórios.

### Domain

Concentra as entidades, enums e interfaces fundamentais do domínio, representando os conceitos centrais do sistema.

### Infrastructure

Responsável pelos detalhes de persistência e acesso aos dados, incluindo configurações do Entity Framework Core, contexto do banco de dados, migrations e implementações dos repositórios.

A organização busca manter as responsabilidades separadas e reduzir o acoplamento entre as regras da aplicação e os detalhes de infraestrutura.

##  Estrutura de Pastas

A solução está organizada em quatro projetos:

```text
SistemaControleProdutoEstoque/
│
├── SistemaControleProdutoEstoque.API/
│   ├── Controllers/
│   ├── Extensions/
│   ├── Filters/
│   ├── Middlewares/
│   ├── Responses/
│   ├── Program.cs
│   └── appsettings.json
│
├── SistemaControleProdutosEstoque.Application/
│   ├── DependencyInjection/
│   ├── Exceptions/
│   ├── Requests/
│   ├── Responses/
│   ├── Services/
│   ├── UseCases/
│   └── Validators/
│
├── SistemaControleProdutosEstoque.Domain/
│   ├── Entities/
│   ├── Enums/
│   └── Interfaces/
│
├── SistemaControleProdutosEstoque.Infrastructure/
│   ├── Data/
│   ├── DependencyInjection/
│   ├── Migrations/
│   └── Repositories/
│
├── Dockerfile
├── docker-compose.yml
├── .dockerignore
├── .gitignore
└── SistemaControleProdutoEstoque.sln
```

**Responsabilidade das principais pastas:**

- `Controllers`: recebem as requisições HTTP e direcionam as operações para os casos de uso.
- `Middlewares`: componentes responsáveis pelo processamento das requisições, incluindo o tratamento global de exceções.
- `Responses`: modelos utilizados para padronizar as respostas da API.
- `UseCases`: classes responsáveis por coordenar as operações da aplicação.
- `Requests`: modelos que representam os dados de entrada das operações.
- `Validators`: regras de validação das requisições.
- `Entities`: entidades que representam os conceitos centrais do domínio.
- `Enums`: tipos enumerados utilizados na representação das regras e operações.
- `Interfaces`: contratos utilizados pelas camadas internas.
- `Data`: contexto e configurações de acesso ao banco de dados.
- `Repositories`: implementações responsáveis pela persistência e consulta dos dados.
- `Migrations`: histórico das alterações estruturais do banco de dados.
- `Middlewares`: tratamento global das requisições e exceções.
- `DependencyInjection`: organização dos registros de dependências de cada camada.

##  Como executar o projeto

### Pré-requisitos

- Docker Desktop instalado e em execução.
- Docker Compose disponível.
- Git.

### 1. Clone o repositório

```bash
git clone URL_DO_REPOSITORIO
```

### 2. Acesse a pasta do projeto

```bash
cd SistemaControleProdutoEstoque
```

### 3. Configure as variáveis de ambiente

Crie um arquivo `.env` na raiz do projeto, no mesmo nível do `docker-compose.yml`:

```env
SA_PASSWORD=SuaSenhaForteAqui123!
```

Utilize uma senha forte que atenda aos requisitos do SQL Server.

O arquivo `.env` não deve ser enviado ao repositório.

### 4. Construa e execute os containers

Na raiz do projeto, execute:

```bash
docker compose up --build -d
```

Esse comando constrói a imagem da API e inicia os containers da aplicação e do SQL Server.

### 5. Verifique os containers

```bash
docker compose ps
```

### 6. Acesse a API

A aplicação estará disponível em:

```text
http://localhost:8080
```

**Importante:** o projeto utiliza o ambiente Production no Docker Compose atual. Como o Swagger está habilitado apenas no ambiente Development, sua interface não estará disponível nesse ambiente sem uma configuração adicional.

### Comandos úteis

Parar os containers:

```bash
docker compose stop
```

Iniciar novamente:

```bash
docker compose start
```

Visualizar os logs:

```bash
docker compose logs -f
```

Encerrar e remover os containers:

```bash
docker compose down
```

O volume do SQL Server é preservado ao utilizar `docker compose down`, mantendo os dados do banco.

##  Endpoints

Os endpoints estão organizados em três recursos principais: Categorias, Produtos e Estoque.

### Endpoints de categorias

| Método | Endpoint                         | Descrição                              |
| ------ | -------------------------------- | -------------------------------------- |
| POST   | `/api/categorias`                | Cadastro de categoria.                 |
| GET    | `/api/categorias`                | Lista todas as categorias.             |
| PUT    | `/api/categorias/{id}`           | Altera o nome de uma categoria.        |
| GET    | `/api/categorias/{id}`           | Busca uma categoria por identificador. |
| PUT    | `/api/categorias/{id}/desativar` | Desativa uma categoria.                |
| PUT    | `/api/categorias/{id}/reativar`  | Reativa uma categoria.                 |
| DELETE | `/api/categorias/{id}/deletar`   | Exclui uma categoria.                  |

### Endpoints de produtos

| Método | Endpoint                                       | Descrição                           |
| ------ | ---------------------------------------------- | ----------------------------------- |
| POST   | `/api/produtos`                                | Cadastro de produto.                |
| GET    | `/api/produtos`                                | Lista todos os produtos.            |
| PUT    | `/api/produtos/{id}`                           | Altera informações de um produto.   |
| GET    | `/api/produtos/{id}`                           | Busca um produto por identificador. |
| DELETE | `/api/produtos/{id}`                           | Exclui um produto.                  |
| PUT    | `/api/produtos/{id}/desativar`                 | Desativa um produto.                |
| PUT    | `/api/produtos/{id}/reativar`                  | Reativa um produto.                 |
| GET    | `/api/produtos/buscar-categoria/{categoriaId}` | Busca produtos por categoria.       |

### Endpoints de estoque

| Método | Endpoint                                       | Descrição                                  |
| ------ | ---------------------------------------------- | ------------------------------------------ |
| POST   | `/api/estoque`                                 | Registra uma movimentação de estoque.      |
| GET    | `/api/estoque/buscar-movimentos/{produtoId}`   | Busca movimentações de um produto.         |
| GET    | `/api/estoque/ultima-movimentacao/{produtoId}` | Busca a última movimentação de um produto. |
| GET    | `/api/estoque/todas-movimentos`                | Lista todas as movimentações.              |
| GET    | `/api/estoque/filtrar-por-período`             | Filtra movimentações por período.          |

## Desafios encontrados

Durante o desenvolvimento, alguns dos principais desafios foram:

- Compreender e implementar os relacionamentos entre as entidades `Produto`, `Categoria` e `MovimentacaoEstoque`.
- Organizar a aplicação utilizando Clean Architecture em camadas, entendendo a responsabilidade de cada projeto.
- Trabalhar com Entity Framework Core, configurações de entidades, relacionamentos e migrations.
- Compreender o funcionamento do Dependency Injection e o registro das dependências entre as camadas.
- Implementar um Middleware próprio para o tratamento global de exceções.
- Diferenciar exceções de validação, recursos não encontrados e regras de negócio.
- Compreender como transformar exceções em respostas HTTP padronizadas.
- Containerizar a aplicação e configurar a comunicação entre a API e o SQL Server utilizando Docker Compose.

## Objetivos de aprendizado

O desenvolvimento deste projeto permitiu colocar em prática e aprofundar conhecimentos em:

- C# e .NET 8.
- ASP.NET Core e desenvolvimento de APIs REST.
- Clean Architecture em camadas.
- Modelagem e relacionamento entre entidades.
- Entity Framework Core.
- SQL Server e migrations.
- Repository Pattern.
- Casos de uso e separação de responsabilidades.
- Dependency Injection.
- FluentValidation.
- Middlewares e tratamento de exceções.
- Programação assíncrona com `async` e `await`.
- Docker e Docker Compose.
- Persistência de dados em containers.

## Portfólio

No meu portfólio você encontrará outros projetos desenvolvidos por mim.

**Portfólio:** [Adriano ATBS](https://adriano-atbs.vercel.app/)
