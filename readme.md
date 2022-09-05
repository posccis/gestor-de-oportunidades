#  API DE GERENCIAMENTO DE OPORTUNIDADES 	💻 

<hr>  

## 🔍 Descrição

### Trata-se de uma API para gerenciar vendedores e suas oportunidades de vendas dentro de uma organização.

## 📝 Como utilizar

### 🔌API
- Primeiramente você vai precisar obter o repositório.
- Obtido o repositório abra a solução que está em '[pasta local]\GerenciamentoDeOportunidades'.
- Aberta a solução vá até 'Dados/OportunidadesContext.cs' e altere a variavel 'stringDeConexao' para a string de conexão do seu SQLServer Local.
- No PowerShell, dentro da pasta '\GerenciamentoDeOportunidades\GerenciamentoDeOportunidades' execute o comando 'dotnet ef migrations add InitialMigration'. 
- Em seguinda, ainda no PowerShell, execute o comando 'dotnet ef database update'.
- Execute o comando 'cd..' para voltar uma pasta e acesse a pasta '\GerenciamentoDeOportunidades\GerenciamenetoDeOportunidadesAPI' e execute o comando 'dot net run'
- e então nossa API está funcionando!
- Com a API em execução acesse 'https://localhost:7000/swagger/index.html' para acessar a documentação feita no Swagger e testar os endpoints. 

### 🎨 Aplicativo Angular
- Através do PowerShell(Recomendo utilizar outro como o git bash) acesse a pasta '[pasta local]\gerenciamento-de-oportunidades' e execute o comando 'npm install'
- Em seguida execute o comando 'ng serve' e acesse 'http://localhost:4200/'

## 🔧 Ferramentas Utilizadas
- Visual Studio: Inicialmente eu não gostava do VS, porém, o atual intellisense, o gerenciador de pacote NuGet, os diversos consoles, a organização do explorador de soluções e outras ferramentas como a conexão direta com o SQLServer fizeram dele meu favorito para desenvolvimento .Net.
- SQLServer: Já possuo bastante familiaridade até mesmo com as funções próprias do SQLServer, gosto do Management Studio por ser bem objetivo e não ser poluído, por ser da própria Microsoft o uso dele com o .Net se torna mais prático tendo até mesmo pacotes do EntityFramework especificos pra ele.
- EntityFrameWork core: O EntityFramework é quase essencial por conta da práticidade que ele trás para a manipulação do banco de dados. Ele tira a necessidade do desenvolvedor estar construindo consultas basicas como insert, update, select e etc, além disso, ele facilita a conexão com o banco, da liberdade para escolher entre Code-First e DB-First. No caso eu quase sempre prefiro utilizar o Code-First porque com os métodos do EntityFramework eu consigo definir o banco, as tabelas e os relacionamentos, fora isso, o proprio EntityFramwork se encarrega de criar o banco. E ainda sobre as consultas, ele continuar permitindo consultas em SQL puro, que eu precisei nesse projeto.
- Insomnia: Gosto de utilizar o Insomnia desde que eu descobri ele. Sempre prefiro softwares mais minimalistas para evitar o excesso de informação.
- AngulrTS: Também gosto do Angular, porém, gosto por ser muito bem estruturado e organizado. Ele ser estruturado trás uma bela praticidade na hora do desenvolvimento por saber exatamente onde cada coisa está, além disso, a facilidade de importação e e uso de bibliotecas como o Bootstrap também agilizam muito o desenvolvimento. Por fim, também foi por estar familiarizado com a ferramenta.

## 📡Etapas do aplicativo

 - 📍O primeiro endpoint 'https://localhost:7000/api/usuario' tem a função de cadastrar os vendedores. Para o cadastro é necessário o e-mail qual vai servir como Id ou chave primaria, a região na qual o vendedor irá atender e o nome do vendedor. A classe  Usuario em si possui, além desses atributos, a lista de oportunidades, pois um vendedor pode possuir múltiplas oportunidades.
 - 📍 O segundo endpoint 'https://localhost:7000/api/oportunidades' precisa do anterior. O anterior cadastra os vendedores enquanto que o segundo cadastra as oportunidades e cada oportunidade precisa está relacionada a um vendedor e apenas um. Para o cadastro da oportunidade é necessário o CNPJ da empresa, o nome e o valor da oportunidade.
 - Ao cadastrara oportunidade o CNPJ é suficiente para que o algoritmo obtenha através da api publica as demais informações para complementar o objeto da classe Oportunidade qual também possui os atributos 'razão social', 'descrição da atividade principal' e o código do IBGE do estado.
 - 📍No projeto temos um Enum no qual os valores da chaves são os mesmos dos códigos do IBGE oque facilita no cadastro dos vendedores e também na consulta ao banco no momento em que vamos buscar os vendedores através da região. 
 - 📍Para finalizar o cadastro da oportunidade é necessário ter efetuado esse trabalho de localizar a região da empresa e os vendedores da região. Para escolher o vendedor que será responsável pela oportunidade, o algoritmo obtém uma lista com todos os vendedores menos o ultimo vendedor daquela região a receber uma oportunidade e dentro dessa lista ele escolhe um índice aleatório dentro do alcance da lista, caso nenhum vendedor tenha recebido uma oportunidade naquela região, o algoritmo irá selecionar o primeiro da lista de vendedores da região.
 - 📍Feito o cadastro do vendedor e da oportunidade de venda, o terceiro endpoint 'https://localhost:7000/api/usuario/{email}' se encarrega de retornar para o usuário os dois. Ele retorna o objeto Usuario completo contendo a lista de oportunidades.