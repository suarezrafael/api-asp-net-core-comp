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

## 📷 Imagens do projeto rodando

- Imagens da aplicação rodando [Prints Swagger](https://github.com/suarezrafael/api-asp-net-core-compasso/wiki/Imagens-da-aplica%C3%A7%C3%A3o-rodando )


  
## ⚙️ Executando os testes

- Clone o repositório https://github.com/suarezrafael/api-asp-net-core-compasso.git
- Abra o arquivo CidadesAPI.sln com o visual Studio 2019.
- Aguarde a Inicialização do aplicativo. Quando o programa estiver pronto e rodando o navegador irá exibir a página https://localhost:44302/swagger/index.html 🤓.
- Para acessar os exemplos em json. Abra o programa POSTMAN. Importe para o POSTMAN o arquivo de coleção Cidades API.postman_collection.json.
- Execute as requisições HTTP cadastradas. 
- Voce pode executar as requisições tanto no POSTMAN como na própria página do swagger.
- Abaixo a Descrição detalhada da coleção de exemplos  JSON POSTMAN CidadesAPI
   1. GET Cidades 
      - Consulta todas cidades para elucidar que dados estão pré-gravados no BD
      - Headers: Accept application/json
	  - URL: https://localhost:44302/api/cidades
   2. GET Cidades hateoas
      - Teste de GET usando application/vnd.marvin.hateoas+json
      - Headers: Accept application/vnd.marvin.hateoas+json
	  - URL: https://localhost:44302/api/cidades/d28888e9-2ba9-473a-a40f-e38cb54f9b35
   3. GET Cidade (unexisting)
      - Consulta de Cidade por ID usando um ID inexistente
      - Headers:
	  - URL: https://localhost:44302/api/cidades/a8d15573-ec65-4f48-97d2-2e7c0a726c33
   4. GET Cidade (Accept: application/json)
      - Consulta de Cidade por ID com JSON result
      - Headers: Accept application/json
	  - URL: https://localhost:44302/api/cidades/d28888e9-2ba9-473a-a40f-e38cb54f9b35
   5. GET Cidade (Accept: application/xml)
      - Consulta de Cidade por ID com XML result
      - Headers: Accept application/xml
	  - URL: https://localhost:44302/api/cidades/d28888e9-2ba9-473a-a40f-e38cb54f9b35
	  
   6. GET Clientes
      - Consulta todos os clientes para elucidar que dados estão pré-gravados no BD
      - Headers:
	  - URL: https://localhost:44302/api/cidades
   7. GET Cliente hateoas
      - Teste de GET usando application/vnd.marvin.hateoas+json
      - Headers: Accept application/vnd.marvin.hateoas+json
	  - URL: https://localhost:44302/api/cidades/d28888e9-2ba9-473a-a40f-e38cb54f9b35
	  
   8. GET Cliente (Accept: application/json)
      - Consulta de Cliente por ID com JSON result
      - Headers: Accept application/json
	  - URL: https://localhost:44302/api/cidades/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b
   9. GET Cliente (Accept: application/xml)
      - Consulta de Cliente por ID com XML result
      - Headers: Accept application/xml
	  - URL: https://localhost:44302/api/cidades/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b
   10. GET Cliente (unexisting Cliente)
       - Consulta de Cidade por ID usando um ID inexistente
       - Headers:
	   - URL: https://localhost:44302/api/cidades/a8d15573-ec65-4f48-97d2-2e7c0a726c33
   11. HEAD Cidades
       - Consulta o cabeçalho da requisição
       - Headers:
	   - URL: https://localhost:44302/api/cidades
   12. GET Filtered Cidades Por Nome
       - Consulta lista Cidades filtrando por Nome
       - Params: Nome=Alegrete
	   - URL: https://localhost:44302/api/cidades?Nome=Alegrete
   13. GET Filtered Cidades Por Estado
       - Consulta lista de Cidades filtrando por Nome
       - Params: Estado=RS
	   - URL: https://localhost:44302/api/cidades?Estado=RS
   14. GET Filtered Cidades Por Nome e Estado
       - Consulta lista de Cidades filtrando por Nome e Estado
       - Params: ?Nome=Alegrete&Estado=RS
	   - URL: https://localhost:44302/api/cidades?Nome=Alegrete&Estado=RS
   15. GET Filtered Clientes Por Nome
       - Consulta lista de Clientes filtrando por NomeCompleto
       - Params: NomeCompleto=Rafael
	   - URL: https://localhost:44302/api/cidades?NomeCompleto=Rafael
   16. POST Cidade
       - Cadastra uma cidade
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
	   - URL: https://localhost:44302/api/cidades
   17. POST Cidade (no body)
       - Teste de cadastrar uma cidade sem o body do request
       - Headers:
	     - KEY: Content-Type VALUE: application/json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
           ```
	   - URL: https://localhost:44302/api/cidades		  
   18. POST Cidade (invalid body)
       - Teste de cadastrar uma cidade com valores inválidos do body 
       - Headers:
	     - KEY: Content-Type VALUE: application/json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   {
		 	 "Nome" : "Cachoeira do Sul",
			 "Estado" : "Valor invalido para o Estado"
	       }	
       - URL: https://localhost:44302/api/cidades		  
   19. POST Cidade to single resource URI
       - Teste de cadastrar uma cidade com valores da URI 
       - Headers:
	     - KEY: Content-Type VALUE: application/json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   {
			 "Nome" : "Cachoeira do Sul",
			 "Estado" : "RS"
	       }	
	   - URL: https://localhost:44302/api/cidades/25141d83-4584-4487-a306-0441695d8e24
   20. POST Cliente
       - Cadastrar um cliente
       - Headers:
	     - KEY: Content-Type VALUE: application/json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   {
			 "nomeCompleto" : "Maria de Lurdes",
			 "sexo" : "F",
			 "dataDeNascimento" : "1968-03-04T00:00:00",
			 "cidadeId" : "d28888e9-2ba9-473a-a40f-e38cb54f9b35"
		   }
           ```
	   - URL: https://localhost:44302/api/clientes		  
   21. POST Cidade (XML input)
       - Cadastrar uma cidade via XML
       - Headers:
	     - KEY: Content-Type VALUE: application/xml
		 - KEY: Accept VALUE: application/json
		 - Body
           ```xml
		   <CidadeParaCriacaoDto xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/Cidades.API.Models">
		      <Estado>RS</Estado>
		      <Nome>Alegrete</Nome>
		   </CidadeParaCriacaoDto>
           ```
	   - URL: https://localhost:44302/api/cidades		  
   22. POST Cidade (XML input, XML output)
       - Cadastrar uma cidade entrada XML com saida XML
       - Headers:
	     - KEY: Content-Type VALUE: application/xml
		 - KEY: Accept VALUE: application/json
		 - Body
           ```xml
		   <CidadeParaCriacaoDto xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/Cidades.API.Models">
		      <Estado>RS</Estado>
		      <Nome>Alegrete</Nome>
		   </CidadeParaCriacaoDto>
           ```
	   - URL: https://localhost:44302/api/cidades		  
   23. POST Cliente (null values)
       - Teste cadastrar Cliente  com valores nulos
       - Headers:
	     - KEY: Content-Type VALUE: application/xml
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   {
			 "nomeCompleto" : null,
			 "sexo" : null,
			 "dataDeNascimento" : null,
			 "cidadeId" : null
		   }
           ```
	   - URL: https://localhost:44302/api/clientes		  
   24. POST Cliente (long NomeCompleto long Sexo)
       - Teste cadastrar Cliente valores longos
       - Headers:
	     - KEY: Content-Type VALUE: application/xml
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   {
		 	 "nomeCompleto": "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
			 "Sexo": "Ye"
		   }
           ```
	   - URL: https://localhost:44302/api/clientes
   25. PATCH Clientes
       - Alteração parcial do cliente
       - Headers:
	    - KEY: Content-Type VALUE: application/json-patch+json
		- KEY: Accept VALUE: application/json
		- Body
          ```json
		  [
			{
			"op": "replace",
			"path": "/nomecompleto",
			"value": "Nome Atualizado"
			}
		  ]
          ```
      - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   26. PATCH Cliente (multiple)
       - Alteração parcial do cliente de multiplos atributos
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			 {
				"op": "replace",
				"path": "/nomecompleto",
				"value": "Outro Nome Alterado"
			 },
			 {
				"op": "replace",
				"path": "/sexo",
				"value": "F"
			 }
		   ]
           ```
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   27. PATCH Cliente (remove)
       - Alteração parcial do cliente apagar atributo
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			{
				"op": "remove",
				"path": "/nomecompleto"
			}
		   ]
           ```
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   28. PATCH Cliente (copy and add)
       - Alteração parcial do cliente copiar um atributo e adicionar
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			{
			  "op": "add",
			  "path": "/nomecompleto",
			  "value": "Novo nome"
			},
			{
			  "op": "copy",
			  "from": "/sexo",
			  "path": "/nomecompleto"
			}
		   ]
           ```
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   29. PATCH Cliente (unexisting cliente)
       - Teste Alteração parcial do cliente cliente inexistente
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			{
			  "op": "add",
			  "path": "/nomecompleto",
			  "value": "Novo nome"
			},
			{
			  "op": "copy",
			  "from": "/sexo",
			  "path": "/nomecompleto"
			}
		   ]
           ```	
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   30. PATCH Cliente (remove sexo)
       - Teste Alteração parcial do cliente remover atributo sexo
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			{
				"op": "remove",
				"path": "/sexo"
			}
		   ]
           ```	
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  		  
   31. PATCH Cliente (remove unexisting property)
       - Teste Alteração parcial do cliente remover de um cliente inexistente
       - Headers:
	     - KEY: Content-Type VALUE: application/json-patch+json
		 - KEY: Accept VALUE: application/json
		 - Body
           ```json
		   [
			{
				"op": "remove",
				"path": "/issonaoexiste"
			}
		   ]
           ```
       - URL: https://localhost:44302/api/clientes/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b		  
   32. DELETE Cliente
       - Excluir Cliente
       - Headers:
		 - Body
	   - URL: https://localhost:44302/api/clientes/d8663e5e-7494-4f81-8739-6e0de1bea7ee
   33. DELETE Cliente (unexisting Cliente)
       - Excluir Cliente
       - Headers:
		 - Body
	   - URL: https://localhost:44302/api/clientes/3f946dbe-edf3-4c44-baef-b683bc355a0f  

## 📌 Versão

Usei [GitKraken](https://www.gitkraken.com/git-client) para controle de versão. Para as versões disponíveis, observe as [tags neste repositório](https://github.com/suarezrafael/api-asp-net-core-compasso/tags). 

## ✒️ Autores

* **Rafael Vieira Suarez** - *Trabalho Inicial* - [suarezrafael](https://github.com/suarezrafael)


