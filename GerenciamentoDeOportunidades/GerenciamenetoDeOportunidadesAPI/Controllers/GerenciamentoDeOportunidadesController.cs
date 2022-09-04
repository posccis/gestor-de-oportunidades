using GerenciamentoDeOportunidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamenetoDeOportunidadesAPI
{
    [ApiController]
    public class GerenciamentoDeOportunidadesController : ControllerBase
    {
        Manutencao manu = new Manutencao();
        #region POST
        [AcceptVerbs("POST"), Route("api/usuario")]
        [HttpPost]
        public IActionResult EnviarUsuario([FromBody]Usuario usuario) 
        {
            try
            {
                return manu.EnviarUsuario(usuario)  ? Ok() : BadRequest() ;
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
                return manu.EnviarOportunidade(opo) ? Ok() : BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion POST

        #region GET

        [AcceptVerbs("GET"), Route("usuario/{email}")]
        [HttpGet]
        public ActionResult<Usuario> ObterUsuario(string email)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario = manu.ObterVendedorPorEmail(email);
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
