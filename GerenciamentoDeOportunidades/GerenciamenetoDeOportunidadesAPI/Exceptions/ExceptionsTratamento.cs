using GerenciamentoDeOportunidades;
using System.Net.Mail;

namespace GerenciamenetoDeOportunidadesAPI
{
    public class ExceptionsTratamento
    {
        public ExceptionsTratamento()
        {}

        public void ValidarUsuarioInsercao(Usuario usuario) 
        {
            if (usuario == null) throw new GerenciamentoDeOportunidadesException("O usuario a ser cadastrado não pode ser nulo!");
            if (usuario.EmailId == null || String.IsNullOrEmpty(usuario.EmailId) || usuario.EmailId == "") throw new GerenciamentoDeOportunidadesException("É necessário informar o email do vendedor!");
            ValidarEmail(usuario.EmailId);
            if (usuario.Regiao == null) throw new GerenciamentoDeOportunidadesException("É necessário informar a região ou o código da região do usuário!");
            if (usuario.Nome == "" || String.IsNullOrEmpty(usuario.Nome)) throw new GerenciamentoDeOportunidadesException("É necessário informar o nome do usuário!");

        }

        public void ValidarOportunidadeInsercao(Oportunidade oportunidade)
        {
            if (oportunidade == null) throw new GerenciamentoDeOportunidadesException("A oportunidade a ser cadastrada não pode ser nula!");
            if (oportunidade.CNPJ == null || String.IsNullOrEmpty(oportunidade.CNPJ) || oportunidade.CNPJ == "") throw new GerenciamentoDeOportunidadesException("É necessário informar o CNPJ da empresa!");
            if (oportunidade.Nome == null || String.IsNullOrEmpty(oportunidade.Nome) || oportunidade.Nome == "") throw new GerenciamentoDeOportunidadesException("É necessário informar o nome da empresa!");
            if (oportunidade.ValorMonetario <= 0 ) throw new GerenciamentoDeOportunidadesException("O valor monetario da empresa precisa ser maior do que 0!");

        }

        public void ValidarEmail(string email) 
        {
            bool valido = true;
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch 
            {

                valido = false;
            }
            finally
            {
                if (!valido) throw new GerenciamentoDeOportunidadesException("Email invalido!");
            }
            
            
        }

        public void ValidarUsuarioObtencao(Usuario usuario) 
        {
            if (usuario == null) throw new GerenciamentoDeOportunidadesException("Não foi possivel encontrar o usuário em nosso sistema!");

        }
    }
}
