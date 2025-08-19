# CRUD de Usuários

Bem-vindo(a) ao **CRUD de Usuários**.

Este projeto foi desenvolvido para **gerenciar usuários** de forma eficiente, utilizando tecnologias modernas e seguindo **boas práticas de desenvolvimento**. Ele utiliza padrões de arquitetura de software para deixar o código mais **organizado, modular e escalável**, facilitando a manutenção e futuras melhorias.  

📚💡 Este projeto é ideal para quem deseja aprofundar seus conhecimentos em **.NET**, **APIs RESTful**, **banco de dados relacionais** e **boas práticas de desenvolvimento**, como **mapeamento de entidades para DTOs**, **Repository Pattern** e **Injeção de Dependências**.

## 🏗 Arquitetura do Projeto  
O projeto segue uma abordagem **clean architecture**, separando responsabilidades e garantindo um código mais limpo e reutilizável. Entre os principais padrões adotados, destacam-se:  

- **Camada de Apresentação (Controllers)** – Responsável **exclusivamente** por receber requisições e retornar respostas. *(Optei por manter as controllers o mais enxutas possível, garantindo um código mais claro, organizado e de fácil manutenção.)*  
- **Camada de Aplicação (Services)** – Contém a **lógica** de negócio e orquestra chamadas executando as implementações das interfaces;  
- **Camada de Infraestrutura (Repositories)** – Faz a comunicação com o banco de dados utilizando o **ORM Dapper**;  

Essa estrutura permite que o projeto seja **escalável** e **facilmente testável**, garantindo maior qualidade no desenvolvimento.

## 🛠 Tecnologias Utilizadas  
- **.NET** (C#) – Para a construção do backend robusto e escalável;  
- **Dapper** – ORM Utilizado para o gerenciamento do banco de dados;  
- **SQL Server** – Como banco de dados relacional;  
- **ASP.NET Core Web API** – Para expor endpoints do CRUD;  
- **Swagger** – Para documentação interativa da API;  

## ✨ Funcionalidades  
✔ Criar, editar, visualizar e excluir usuários;  
✔ Validações de entrada para garantir dados consistentes;  
✔ Arquitetura modular e escalável;  
✔ API documentada e testável com Swagger;  

💻 Desenvolvido por Bruno Alves  
📩 bruno.edualves4@gmail.com  
