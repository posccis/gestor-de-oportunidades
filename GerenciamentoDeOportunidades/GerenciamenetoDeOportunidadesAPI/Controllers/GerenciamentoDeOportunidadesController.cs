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
        [AcceptVerbs("POST"), Route("api/usuario")]
        [HttpPost]
        public IActionResult EnviarUsuario([FromBody]Usuario usuario) 
        {
            try
            {
                ex.ValidarUsuarioInsercao(usuario);
                return manu.EnviarUsuario(usuario)  ? Ok() : BadRequest() ;
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
