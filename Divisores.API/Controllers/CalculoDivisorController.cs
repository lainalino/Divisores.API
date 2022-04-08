using Divisores.Infra.Enum;
using Microsoft.AspNetCore.Mvc;
using Divisores.Infra.Services.Interface;

namespace Divisores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoDivisorController : Controller
    {

        private readonly ICalculoDivisorService _calculoDivisorService;
        public CalculoDivisorController(ICalculoDivisorService calculoDivisorService)
        {
            _calculoDivisorService = calculoDivisorService;
        }

        [HttpGet]

        [Route("{numero}/verificar-divisores")]
        public IActionResult CalcularDivisores(int numero)
        {
            try
            {
                //OPÇÃO 1
               
                var retorno = _calculoDivisorService.CalcularDivisores(numero);
                var msgRetorno = _calculoDivisorService.MsgRetorno(retorno, numero);

                //OPÇÃO 2

                var lDivisores = _calculoDivisorService.RetornarDivisores(numero);
                var lPrimos = _calculoDivisorService.RetornarPrimos(lDivisores);
                var msgCompleta = _calculoDivisorService.MontarMensagemRetorno(numero, lDivisores, lPrimos);

                return Ok(msgRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
