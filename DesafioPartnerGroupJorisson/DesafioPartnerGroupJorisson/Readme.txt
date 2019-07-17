****************************************************
****************************************************
**	Criado por Jorisson Vitor de Carvalho Sabino  **
**	      Data: 17/07/2019 - Jandira - SP		  **
****************************************************
****************************************************

Para Este Desafio foi Desenvolvido uma API com o Intuito de Gerenciar Marcas e seus respectivos Patrimonios.
Sendo possivel Consultar, Incluir, Alterar e Excluir.

Para Iniciar a utilização do Sistema, deve Criar as tabelas no Banco de Dados, e modificar a String de Conexão 
dentro da Classe conexao.cs, para que seja realizada a conexão.

Para uma melhor Arquitetura foram Separados os Endpoints em dois sendo a Marca e o Patrimonio, para realizar a 
chamada padrão que seriam as consultas deve se faze-lo da seguinte forma:
1) Consulta de Marcas
	.../api/Marca
2) Consulta de Marca por ID
	.../api/Marca/[Numero_IdDaMarca]
3) Consulta dos Patrimonios de uma Marca Especifica pelo ID da Marca
	.../api/Marca/[Numero_IdDaMarca]/Patrimonios
4) Consulta de Patrimonios
	.../api/Patrimonio
5) Consulta de Patrimonios por ID do Patrimonio
	.../api/Patrimonio/[Numero_IdDoPatrimonio]

Os métodos citados acima são Saidas do tipo [GET] Geralmente do tipo de retorno, logo podem ser executados pelo proprio
navegador, já para consumir os métodos dos tipos [POST], [PUT] e [DELETE] deve se utilizar um Aplicativo para facilitar
a chamada, para o caso existe uma ferramenta Gratuita para efetuar esses testes denominada "Postman".
EndPoints do Tipo [POST] - Deve Ser Inserido no Body da Requisição o Objeto Marca no Formato de JSON: 
1)Inserir Marcas
	.../api/Marca  [{"marcaId":1,"nomeMarca":"Marca"}]
2) Inserir Patrimonios
	.../api/Patrimonio [{"idPatrimonio":0,"marcaId":0,"nomePatrimonio":null,"descricaoPatrimonio":null,"nrTombo":0}]

EndPoints do Tipo [PUT] - Deve Ser Inserido no Body da Requisição o Objeto Marca no Formato de JSON:
1) Alterar Dados da Marca -
	.../api/Marca/[Numero_IdDaMarca]  [{"marcaId":1,"nomeMarca":"Marca"}]
2) Alterar Dados do Patrimonio
	.../api/Patrimonio/[Numero_IdDoPatrimonio]  [{"idPatrimonio":0,"marcaId":0,"nomePatrimonio":null,"descricaoPatrimonio":null}]

EndPoints do Tipo [DELETE]
1) Deletar Marca por ID da Marca
	.../api/Marca/[Numero_IdDaMarca]
2) Deletar Patrimonio por ID do Patrimonio
	.../api/Patrimonio/[Numero_IdDoPatrimonio]

Observação Importante, não é possivel Cadastrar duas Marcas com o mesmo nome.
Caso Exista algo errado na chamada dos métodos o mesmo não está retornando erros , porem o mesmo não realiza a conclusão do método
É utilizado esta forma de validação ao tentar chegar nos casos negativos.
Não é possivel incluir um Patrimonio sem que exista uma regra já inclusa na base, isto deixa a base mais consistente.

Espero que gostem!
