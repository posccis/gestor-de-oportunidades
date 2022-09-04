using GerenciamentoDeOportunidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamenetoDeOportunidadesAPI
{
    [ApiController]
    public class GerenciamentoDeOportunidadesController : ControllerBase
    {
        Manutencao manu = new Manutencao();
        ExceptionsTratamento ex = new ExceptionsTratamento();
        #region POST
        /// <summary>
        /// Cadastra um usuário(vendedor) no sistema de Gerenciamento.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns code="201">Confirmando a criação.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "emailId": "xxxx@xxx.com",
        ///        "nome": "xxxxxx",
        ///        "regiao": 1
        ///     }
        ///
        /// </remarks>
        [AcceptVerbs("POST"), Route("api/usuario")]
        [HttpPost]
        public IActionResult EnviarUsuario([FromBody]Usuario usuario) 
        {
            try
            {
                ex.ValidarUsuarioInsercao(usuario);
                return manu.EnviarUsuario(usuario)  ? StatusCode(StatusCodes.Status201Created, usuario) : BadRequest() ;
            }
            catch (GerenciamentoDeOportunidadesException)
            {

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra uma oportunidade no sistema de gerenciamento. 
        /// </summary>
        /// <param name="opo"></param>
        /// <returns code="201">Confirmando a criação.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "nome": "xxxxxx",
        ///        "valormonetario": 1,
        ///        "cnpj": "00.000.000/0000-00"
        ///     }
        ///
        /// </remarks>
        [AcceptVerbs("POST"), Route("api/oportunidade")]
        [HttpPost]
        public IActionResult EnviarOportunidade([FromBody] Oportunidade opo)
        {
            try
            {

                ex.ValidarOportunidadeInsercao(opo);
                return manu.EnviarOportunidade(opo) ? Ok() : BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion POST

        #region GET
        /// <summary>
        /// Retorna um vendedor com suas oportunidades. Necessário informar o email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns code="200">Retorna o objeto completo.</returns>
        [AcceptVerbs("GET"), Route("api/usuario/{email}")]
        [HttpGet]
        public ActionResult<Usuario> ObterUsuario(string email)
        {
            Usuario usuario = new Usuario();
            try
            {
                ex.ValidarEmail(email);
                usuario = manu.ObterVendedorPorEmail(email);
                ex.ValidarUsuarioObtencao(usuario);
                return StatusCode(StatusCodes.Status200OK, usuario);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        #endregion GET
    }
}
