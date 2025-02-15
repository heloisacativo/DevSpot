# DevSpot

## Setup

Create the .env file

> touch .env

> cp .env.example .env

Install dependencies

> dotnet restore

Update the database

> dotnet ef database update

Run DevSpot

> dotnet run

# Learnings

## ASP.NET Core MVC

The MVC pattern (Model-View-Controller) is an architectural pattern that divides an application into three main components: Models, Views, and Controllers.

User requests are routed to a Controller, which uses Models to execute user actions and queries. 

The business logic is implemented in the Models. This makes it easier to test and debug code with dependencies distributed across two or more of these three areas. (This pattern is used in monolithic applications.)

## Microservices Architecture

The application is divided into small, independent services that communicate with each other. Although it shares similarities with the separation of responsibilities in the monolithic MVC pattern, MVC is typically used in a single application. In microservices, the architecture is distributed, with multiple independent applications, each responsible for a specific functionality or service.

## Dependency Injection (DI)

It is a design pattern that allows a class to receive its dependencies from the outside, promoting loose coupling. This makes code maintenance easier, as a dependency can be modified without directly impacting a class.

## Repository Pattern 

Objective: To abstract and encapsulate data access logic. (Interaction is done through the Repository, which is responsible for performing data access operations).

* Controller 

The Controller is a central part of MVC, as I mentioned earlier. It handles user requests. In the Repository Pattern, instead of querying the database directly, it delegates this responsibility to the Repository.

The Repository Pattern has a direct relationship with the Controller, providing an intermediate layer between the business logic and the physical access to the database.


## Configuração 

Crie o arquivo .env

> touch .env

> cp .env.example .env

Instale as dependências

> dotnet restore

Atualize o banco de dados 

> dotnet ef database update

Execute o DevSpot

> dotnet run 

## Aprendizados

### ASP.NET Core MVC 

O MVC pattern (Model-View-Controller) é um architectural pattern que divide aplicação em três componentes principais: Models, Views e Controllers. As solicitações de usuários são encaminhadas para um Controller, que usa os Models para executar ações do usuário e consultas, é no Models onde a lógica de negócios é implementada. Assim, torna-se mais fácil: testar e depurar um código que possui dependências distribuídas em duas ou mais dessas três áreas. (Esse pattern é utilizado em aplicação monolítica)

### Arquitetura de Microservices

A Aplicação é dividida em pequenos serviços independentes que se comunicam entre si. Apesar de ter semelhança na separação de responsabilidade com o monolítico do MVC, o MVC é geralmente usado em uma aplicação única, no microservices acontecem de forma distribuída, com múltiplas aplicações independentes, onde cada uma é responsável por uma funcionalidade ou serviço específico.

### Injeção de dependência (DI)

É um design pattern que permite a uma classe receber suas dependências de fora, promovendo acoplamento frouxo (low coupling), facilitando a manutenção de um código, por exemplo, uma dependência pode ser facilmente modificada sem que haja um impacto direto em uma class.

### Repository Pattern

Objetivo: Abstrair e encapsular a lógica de acesso aos dados. (A interação é feita através do Repository, que é responsável por realizar operações de acesso a dados

* Controller
É uma parte central de MVC, como eu comentei anteriormente, ele lida com requisições do usuário, no Repository Pattern, ao contrário de fazer consultas diretamente no banco de dados, ele delega essa responsabilidade ao Repository.

O Repository Pattern tem uma relação direta com o Controller, que fornece uma camada intermediária entre a lógica de negócio e o acesso físico ao banco de dados.

⭐