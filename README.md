# CRM
Exemplo de sistema para cadastro de clientes e implementado com microserviços desenvolvidos com .NET Core 3.1

## CRM.Auth
Serviço que fornece autenticação por OAuth através do IdentityServer4. (não terminado)

## CRM.BFF
Serviço que implementa o padrão Backend For Front-end que funciona como gateway para comunicação do front-end com os restantes serviços.

## CRM.Cadastro
Serviço que segue o padrão tático do Domain Driven Design e que gerencia o cadastro de clientes. Os dados são armazenados numa base MySQL e o instalador de base é executado na subida da aplicação.

## CRM.CEP
Serviço que serve de proxy para o ViaCEP e mantém uma cache dos resultados.

TBD
------
- Implementar a autenticação dos serviços
- Passar o armazenamento da cache do CRM.CEP para fora da aplicação (Redis?)
- Tratamento no Portal para erros nas respostas
- Criar testes unitários para o Portal
- Criar os testes E2E
- Pipeline de geração das imagens e subida dos containers
