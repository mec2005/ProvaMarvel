# ProvaMarvel
Projeto para validação de conhecimento 

## Começando
Essas instruções fornecerão uma cópia do projeto em execução na sua máquina local para fins de desenvolvimento e teste. 

### Pré-requisitos
* Dotnet core **2.0 para o site.**
* Dotnet core **3.1 para os testes de integração.**
* Visual Studio ou VS Code para edição do código.

### Installing
* Clone ou baixe o repositório para o seu computador
* Copile usando a linha de comando **dotnet build**
* Navegue até a pasta do projeto e execute a linha de comando **dotnet run**
* Acesse no seu browser a url https://localhost:5001/

### Executando os testes de integração
* Execute os testes de integração com o comando **dotnet test**

## Autor
[Marcos Cardoso](https://github.com/mec2005)

## Observações
* O Proposito do código fonte é de demonstrar conhecimento da tecnologia aplicada.
* O Sistema é uma WebApi que simula a api da marvel [Marvel](https://developer.marvel.com/docs#!/public) que retorna informações de 
personagens da franquia.
* Por questão de tempo de desenvolvimento (6hs) foi utilizado um o princípio [KISS](https://pt.wikipedia.org/wiki/Princ%C3%ADpio_KISS) e 
arquitetura MVC.
* Repositório Genérico para obtenção de dados no **InMemoryDB**

### O que mais pode ser implementado
* Mapeamento de entidades de bando de dados com **CodeFirst e Migrations**
* Fluent Validations que permite validar as entradas e saídas de informações de forma mais coesa.
* Classe de ViewModels para retornos nos controllers.
* AutoMapper para conversão das entidades em viewmodels e vice-versa.

