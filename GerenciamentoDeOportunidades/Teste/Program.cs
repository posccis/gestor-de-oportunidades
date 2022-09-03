// See https://aka.ms/new-console-template for more information
using GerenciamentoDeOportunidades;
using GerenciamentoDeOportunidades.Dados;

Console.WriteLine("Hello, World!");
OportunidadesContext oportu = new OportunidadesContext();
Repositorio repo = new Repositorio(oportu);
Usuario usuario = new Usuario()
{
    Nome = "Roberto  Carlos",
    EmailId = "robertao@gmail.com",
    Regiao = RegioesEnum.Nordeste,
};

Oportunidade opo = new Oportunidade()
{
    Nome = "NARCISO ENXOVAIS DO BRASIL LTDA",
    ValorMonetario = 1000.00f,
    CNPJ = "22.299.487/0012-40"
};


//repo.SelecionarUsuarioPorRegiao(4);
//Console.WriteLine(repo.ObterUsuariosPorRegiao(RegioesEnum.Nordeste));
Manutencao manu = new Manutencao();
//manu.EnviarUsuario(usuario);
repo.ConsultarCNPJ("09.013.155/0001-37");
//manu.ObterDadosApiCnpj("09.013.155/0001-37");
//manu.ObterVendedorPorEmail("claudio.000@gmail.com");
//manu.EnviarOportunidade(opo);
Console.WriteLine("");