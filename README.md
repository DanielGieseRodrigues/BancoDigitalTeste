# BancoDigitalTeste
...
O primeiro passo para rodar a aplicação locamente vai ser executar o script de Criacao (está no repositório em .txt e .sql ) no banco de dados local para criação das tabelas.
Após, vai ser necessário rodar a solução (Server/ServerSide.sln) no IIS Local para deixar as requisições disponíveis para consulta.
Após isso poderás abrir a página Home no navegador (Client/home.html), lá será exigido um login, o usuário padrão é:
login:teste senha:12345678.

O gerador de relatório de empréstimos é um console app que está em Server/GeradorRelatorios , ele é quem poderia ser usado no agendador de tarefas ou similiar para o processamento periódico ou único.
Estou jogando o arquivo na pasta C:\Temp.
Creio que será preciso trocar as portas nas requisições que atualmente eram as minhas locais = "44390"" para as que serão usadas no novo ambiente. (Checar qual porta vai ser startada)

Nota importante : Existe um conflito entre portas , derivado de um comportamento do navegador , que exigiu que eu baixasse esta extensão do chromee para testar corretamente (Creio que será necessária ativa-la para testar) :
https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi/related?hl=en-US
O conflito só existe no navegador, então se for feito testes com postman ou parecidos não precisaria da extensão.

Qualquer dúvida : daniel.giese.rodrigues@gmail.com
