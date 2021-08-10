# :cloud: API Asp NET Core 3.1 Entity Framework LocalDB

Desafio API REST p/ cadastrar:

- [x] Cadastrar cidade 
- [x] Cadastrar cliente 
- [x] Consultar cidade pelo nome 
- [x] Consultar cidade pelo estado 
- [x] Consultar cliente pelo nome
- [x] Consultar cliente pelo Id
- [x] Remover cliente
- [x] Alterar o nome do cliente - Foi corrigida a instalação do ASpnetCore.Mvc.NewtonsoftJson 

- Considere o cadastro com dados básicos:
 - Cidades: nome e estado
 - Cliente: nome completo, sexo, data de nascimento, idade e cidade onde mora.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos
 - Visual Studio 2019
 - Carga de trabalho do Visual Studio 2019 Web application ASP NET Core
 - .NET Core 3.1
 - POSTMAN (para testar)

### 🔧 Instalação

- Instalar [VisualStudio 2019 Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16) 
- Instalar Carga de Trabalho no Visual Studio Aplicações Web em .NET Core
- Instalar [POSTMAN Cliente](https://www.postman.com/downloads/)

## 🛠️ Construído com

 - Carga de trabalho do Visual Studio 2019 Web application 
 - .NET Core 3.1
 - POSTMAN para testar
 
* [VisualStudio 2019 Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16) -IDE
* [POSTMAN Cliente](https://dl.pstmn.io/download/latest/win64) - Platform for API Development
* [GitKraken](https://www.gitkraken.com/git-client) - maneira mais fácil, segura e poderosa para aproveitar o Git


  
## ⚙️ Executando os testes

- Clone o repositório https://github.com/suarezrafael/api-asp-net-core-compasso.git
- Abra o arquivo CidadesAPI.sln com o visual Studio 2019.
- Aguarde a Inicialização do aplicativo. Quando o programa estiver pronto e rodando o navegador irá exibir a página https://localhost:44302/swagger/index.html 🤓.
- Para acessar os exemplos em json. Abra o programa POSTMAN. Importe para o POSTMAN o arquivo de coleção Cidades API.postman_collection.json.
- Execute as requisições HTTP cadastradas. 
- Voce pode executar as requisições tanto no POSTMAN como na própria página do swagger.
- Abaixo a Descrição detalhada da coleção POSTMAN CidadesAPI
   1. GET Cidades 
      - Consulta todas cidades para elucidar que dados estão pré-gravados no BD
      - Headers: Accept application/json
   2. GET Cidades hateoas
      - Teste de GET usando application/vnd.marvin.hateoas+json
      - Headers: Accept application/vnd.marvin.hateoas+json
   3. GET Cidade (unexisting)
      - Consulta de Cidade por ID usando um ID inexistente
      - Headers:
   4. GET Cidade (Accept: application/json)
      - Consulta de Cidade por ID com JSON result
      - Headers: Accept application/json
   5. GET Cidade (Accept: application/xml)
      - Consulta de Cidade por ID com XML result
      - Headers: Accept application/xml
	  
   6. GET Clientes
      - Consulta todos os clientes para elucidar que dados estão pré-gravados no BD
      - Headers:
   7. GET Cliente hateoas
      - Teste de GET usando application/vnd.marvin.hateoas+json
      - Headers: Accept application/vnd.marvin.hateoas+json
	  
   8. GET Cliente (Accept: application/json)
      - Consulta de Cliente por ID com JSON result
      - Headers: Accept application/json
   9. GET Cliente (Accept: application/xml)
      - Consulta de Cliente por ID com XML result
      - Headers: Accept application/xml
   10. GET Cliente (unexisting Cliente)
      - Consulta de Cidade por ID usando um ID inexistente
      - Headers:
   11. HEAD Cidades
      - Consulta o cabeçalho da requisição
      - Headers:
   12. GET Filtered Cidades Por Nome
      - Consulta lista Cidades filtrando por Nome
      - Params: Nome=Alegrete
   13. GET Filtered Cidades Por Estado
      - Consulta lista de Cidades filtrando por Nome
      - Params: Estado=RS
   14. GET Filtered Cidades Por Nome e Estado
      - Consulta lista de Cidades filtrando por Nome e Estado
      - Params: ?Nome=Alegrete&Estado=RS
   15. GET Filtered Clientes Por Nome
      - Consulta lista de Clientes filtrando por NomeCompleto
      - Params: NomeCompleto=Rafael
   11. POST Cidade
      - Consulta o cabeçalho da requisição
      - Headers:
	    - KEY: Content-Type VALUE: application/json
		- KEY: Accept VALUE: application/json
		- Body
          ```json
		  {
			"Nome" : "Cachoeira do Sul",
			"Estado" : "RS"
	      }
          ```
   12. Teste Readme.md
		  
## 📌 Versão

Usei [GitKraken](https://www.gitkraken.com/git-client) para controle de versão. Para as versões disponíveis, observe as [tags neste repositório](https://github.com/suarezrafael/api-asp-net-core-compasso/tags). 

## ✒️ Autores

* **Rafael Vieira Suarez** - *Trabalho Inicial* - [suarezrafael](https://github.com/suarezrafael)

## 🎁 Expressões de gratidão

* Teste importante para selecionar e elucidar o desenvolvedor qual nível ele se encontra para conhecer melhor as habilidades técnicas.
Obs.: Estou focado a iniciar o aprendizado sobre o modelo de arquitetura de microserviço. 
Entrei no grupo de toolbox para aprender docker também. Creio que até este desafio não irei utilizar tais conceitos e ferramenta e confiar no que já tenho consolidado.

Muito obrigado compasso 📢
