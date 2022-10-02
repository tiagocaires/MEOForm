# MEOForm
<p align="left"> 
  Projeto Meo.Model<br>
  Contém as classes de domínio e suas respectivas factories.
</p>

<p align="left"> 
  Projeto Meo.Data<br>
  Contem o Contexto de banco de dados, Repositórios e controle de Migrations do EF Core (Migrations e Scripts)
</p>


<p align="left"> 
  Projeto Meo.Service<br>
  Contem as classes de serviços (Interfaces, Mapper, Requests, ViewModels).<br>
  Responsável pela comunicação entre a Api e os modelos e repositórios.
</p>

<p align="left"> 
  Projeto Meo.WebAPI<br>
  Web API responsável por expor os serviços necessários para inclusão de formulário de campanha.<br>
  É necessário informar a String de Conexão com o banco de dados no arquivo appsettings.json, na tag "MeoContext".<br>
  GET {uri}/api/campaign/active - retorna a campanha ativa<br>
  GET {uri}/api/campaign - retorna todas as campanhas cadastradas<br>
  POST {uri}/api/campaign - cadastra uma nova campanha<br>
  GET {uri}/api/campaign/{id} - retorna uma campanha com o Id especificado<br>
  POST {uri}/api/campaign/{id}/reply-form - cadastra um novo formulário de pesquisa
</p>

<p align="left"> 
  Projeto Meo.WebUI<br>
  Projeto MVC para exibição do formulário de pesquisa.<br>
  No arquivo appsettings.json consta a URI da api (UriApi - necessária para comunicação com a API).
</p>


<p align="left"> 
  <b>A solução está configurada para executar os projetos Meo.WebUI e Meo.WebAPI.</b><br>
  <b>Na primeira execução uma campanha de marketing será criada com 4 perguntas.</b>
</p>
