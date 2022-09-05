# API DE GERENCIAMENTO DE OPORTUNIDADES

<hr>  

## Descrição

### Trata-se de uma API para gerenciar vendedores e suas oportunidades de vendas dentro de uma organização.

## Como utilizar

### API
- Primeiramente você vai precisar obter o repositório.
- Obtido o repositório abra a solução que está em '[pasta local]\GerenciamentoDeOportunidades'.
- Aberta a solução vá até 'Dados/OportunidadesContext.cs' e altere a variavel 'stringDeConexao' para a string de conexão do seu SQLServer Local.
- No PowerShell, dentro da pasta '\GerenciamentoDeOportunidades\GerenciamentoDeOportunidades' execute o comando 'dotnet ef migrations add InitialMigration'. 
- Em seguinda, ainda no PowerShell, execute o comando 'dotnet ef database update'.
- Execute o comando 'cd..' para voltar uma pasta e acesse a pasta '\GerenciamentoDeOportunidades\GerenciamenetoDeOportunidadesAPI' e execute o comando 'dot net run'
- e então nossa API está funcionando!
- Com a API em execução acesse 'https://localhost:7000/swagger/index.html' para acessar a documentação feita no Swagger e testar os endpoints. 

### Aplicativo Angular
- Através do PowerShell(Recomendo utilizar outro como o git bash) acesse a pasta '[pasta local]\gerenciamento-de-oportunidades' e execute o comando 'npm install'
- Em seguida execute o comando 'ng serve' e acesse 'http://localhost:4200/'

## Ferramentas Utilizadas
- Visual Studio: Inicialmente eu não gostava do VS, porém, o atual intellisense, o gerenciador de pacote NuGet, os diversos consoles, a organização do explorador de soluções e outras ferramentas como a conexão direta com o SQLServer fizeram dele meu favorito para desenvolvimento .Net.
- SQLServer: Já possuo bastante familiaridade até mesmo com as funções próprias do SQLServer, gosto do Management Studio por ser bem objetivo e não ser poluído, por ser da própria Microsoft o uso dele com o .Net se torna mais prático tendo até mesmo pacotes do EntityFramework especificos pra ele.
- EntityFrameWork core: O EntityFramework é quase essencial por conta da práticidade que ele trás para a manipulação do banco de dados. Ele tira a necessidade do desenvolvedor estar construindo consultas basicas como insert, update, select e etc, além disso, ele facilita a conexão com o banco, da liberdade para escolher entre Code-First e DB-First. No caso eu quase sempre prefiro utilizar o Code-First porque com os métodos do EntityFramework eu consigo definir o banco, as tabelas e os relacionamentos, fora isso, o proprio EntityFramwork se encarrega de criar o banco. E ainda sobre as consultas, ele continuar permitindo consultas em SQL puro, que eu precisei nesse projeto.
- Insomnia: Gosto de utilizar o Insomnia desde que eu descobri ele. Sempre prefiro softwares mais minimalistas para evitar o excesso de informação.
- AngulrTS: Também gosto do Angular, porém, gosto por ser muito bem estruturado e organizado. Ele ser estruturado trás uma bela praticidade na hora do desenvolvimento por saber exatamente onde cada coisa está, além disso, a facilidade de importação e e uso de bibliotecas como o Bootstrap também agilizam muito o desenvolvimento. Por fim, também foi por estar familiarizado com a ferramenta.