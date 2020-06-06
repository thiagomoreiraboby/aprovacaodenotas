# aprovacaodenotas
Mini projeto de validação de notas ficais

Este projeto implemente um sistema de aprovação de notas fiscais de compras.
Foi desenvolvido com as tecnologias: Asp.Net Core e Angular.
A API foi desenvolvida em Asp.Net Core utilizando para persistência o Entity Framework core, modelado utilizado padrões como DDD e CQRS e com autenticação JWT e é integrado com o Swagger.
O Front foi desenvolvido em Angular 9 com Bootstrap.

Ele possui as seguintes funcionalidades: 
•	Login de usuário.
•	Pesquisa e aprovação de notas de compras
•	Listagem de usuário cadastrado


Precisa ter instalado na sua maquina o dotnet core 3 ou superior e nodejs.

Para rodar a API vá ate a pasta “aprovacaodenotas\Aprovacao\src\API”  e execute o comando “dotnet run” a API ficara disponível na url: https://localhost:44369

Para rodar o Front vá ate a pasta “aprovacaodenotas\Aprovacao\src\UIAngular”  e execute o comando “ng serve” o Front ficara disponível na url: https://localhost:4200

Para logar no sistema tem usuário: admin e senha: admin. 
Os demais usuários cadastrados por padrão possuem a senha:123 



