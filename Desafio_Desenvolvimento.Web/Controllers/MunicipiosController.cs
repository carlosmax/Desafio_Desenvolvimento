using Desafio_Desenvolvimento.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Desenvolvimento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipiosController : Controller
    {
        private readonly IObterMunicipiosPorUFService _obterMunicipiosPorUFService;

        public MunicipiosController(IObterMunicipiosPorUFService obterMunicipiosPorUFService)
        {
            _obterMunicipiosPorUFService = obterMunicipiosPorUFService;
        }

        [HttpGet("{uf}")]
        public async Task<IActionResult> Buscar(string uf)
        {
            try
            {
                var municipios = await _obterMunicipiosPorUFService.ObterMunicipiosPorUF(uf);

                return Json(municipios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar municípios: {ex.Message}");
            }
        }
    }
}
