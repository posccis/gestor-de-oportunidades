using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GerenciamentoDeOportunidades
{
    public class Manutencao
    {
        private readonly OportunidadesContext oportu;
        private readonly Repositorio repo;


        public Manutencao()
        {
            oportu = new OportunidadesContext();
            repo = new Repositorio(oportu);
        }

        #region Métodos de Inserção

        public bool EnviarUsuario(Usuario usuario)
        {
            try
            {
                repo.InserirUsuario(usuario);
                return repo.Salvar();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EnviarOportunidade(Oportunidade oportunidade)
        {
            repo.Salvar();
            Usuario usuario = new Usuario();
            bool retorno = false;
            try
            {
                oportunidade = ObterDadosApiCnpj(oportunidade);
                if (repo.InserirOportunidade(oportunidade))
                {
                    usuario = ObterVendedor(oportunidade.CodEstadoIBGE);
                    usuario.Oportunidades = usuario.Oportunidades == null ? new List<Oportunidade>() : usuario.Oportunidades;
                    usuario.Oportunidades.Add(oportunidade);

                    retorno = AtualizarUsuario(usuario);

                }
                repo.Salvar();
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Métodos de Inserção

        #region Métodos de Obtenção
        public Oportunidade ObterDadosApiCnpj(Oportunidade oportunidade)
        {
            JObject dados = new JObject();
            try
            {

                dados = repo.ConsultarCNPJ(oportunidade.CNPJ.ToString());

                oportunidade.DescricaoDeAtividades = dados.GetValue("estabelecimento").SelectToken("atividade_principal").SelectToken("descricao").ToString();
                oportunidade.RazaoSocial = dados.GetValue("razao_social").ToString();
                oportunidade.CodEstadoIBGE = dados.GetValue("estabelecimento").SelectToken("inscricoes_estaduais")[0].SelectToken("estado").SelectToken("ibge_id").ToString();

                return oportunidade;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ObterVendedor(string estadoCod)
        {
            try
            {
                int codReg = int.Parse(estadoCod[0].ToString());

                return repo.SelecionarUsuarioPorRegiao(codReg);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion Métodos de Obtenção

        #region Métodos de Atualização

        public bool AtualizarUsuario(Usuario usuario)
        {
            try
            {
                repo.AtualizarUsuario(usuario);
                return repo.Salvar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Métodos de atualização


    }
}
