using GerenciamentoDeOportunidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamenetoDeOportunidadesAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciamentoDeOportunidadesController : ControllerBase
    {
        Manutencao manu = new Manutencao();
        #region POST
        [AcceptVerbs("POST")]
        [HttpPost("usuario")]
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



        [AcceptVerbs("POST")]
        [HttpPost("oportunidades")]
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
    }
}
