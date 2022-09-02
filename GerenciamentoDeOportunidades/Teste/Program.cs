// See https://aka.ms/new-console-template for more information
using GerenciamentoDeOportunidades;

Console.WriteLine("Hello, World!");
OportunidadesContext oportu = new OportunidadesContext();
Repositorio repo = new Repositorio(oportu);
Usuario usuario = new Usuario()
{
    Nome = "Kaio Luiz",
    Email = "luiz.kaio@gmail.com",
    Regiao = RegioesEnum.Nordeste,
};

Oportunidade opo = new Oportunidade()
{
    Nome = "GRANTO CORRETORA DE SEGUROS LTDA",
    ValorMonetario = 1000.00f,
    CNPJ = "09013155000137"
};


//repo.SelecionarUsuarioPorRegiao(4);
//Console.WriteLine(repo.ObterUsuariosPorRegiao(RegioesEnum.Nordeste));
Manutencao manu = new Manutencao();
//manu.ObterDadosApiCnpj("09.013.155/0001-37");
//manu.EnviarOportunidade(opo);
Console.WriteLine("");