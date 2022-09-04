using GerenciamentoDeOportunidades;

namespace GerenciamenetoDeOportunidadesAPI
{
    public class ExceptionsTratamento
    {
        public ExceptionsTratamento()
        {}

        public void ValidarUsuarioInsercao(Usuario usuario) 
        {
            if (usuario == null) throw new GerenciamentoDeOportunidadesException("O usuario a ser cadastrado não pode ser nulo!");
            if(usuario.EmailId == null || String.IsNullOrEmpty(usuario.EmailId) || usuario.EmailId == "") throw new GerenciamentoDeOportunidadesException("É necessário informar o email do vendedor!");
            if (usuario.Regiao == null) throw new GerenciamentoDeOportunidadesException("É necessário informar a região ou o código da região do usuário!");

        }
    }
}
