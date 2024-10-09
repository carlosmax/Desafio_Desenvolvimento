using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Queries;
using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;
using Desafio_Desenvolvimento.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Desafio_Desenvolvimento.Web
{
    public class HomeController : Controller
    {
        private readonly IHandler<CadastrarProcessoCommand> _cadastrarProcessoHandler;
        private readonly IHandler<ConfirmarVisualizacaoCommand> _confirmarVisualizacaoHandler;
        private readonly IQueryHandler<ObterProcessosQuery, PaginatedList<ProcessoViewModel>> _obterProcessosHandler;
        private readonly IQueryHandler<ObterProcessoPorIdQuery, ProcessoViewModel?> _obterProcessoPorIdHandler;

        public HomeController(
            IHandler<CadastrarProcessoCommand> cadastrarProcessoHandler,
            IHandler<ConfirmarVisualizacaoCommand> confirmarVisualizacaoHandler,
            IQueryHandler<ObterProcessosQuery, PaginatedList<ProcessoViewModel>> obterProcessosHandler,
            IQueryHandler<ObterProcessoPorIdQuery, ProcessoViewModel?> obterProcessoPorIdHandler)
        {
            _cadastrarProcessoHandler = cadastrarProcessoHandler;
            _confirmarVisualizacaoHandler = confirmarVisualizacaoHandler;
            _obterProcessosHandler = obterProcessosHandler;
            _obterProcessoPorIdHandler = obterProcessoPorIdHandler;
            _obterProcessoPorIdHandler = obterProcessoPorIdHandler;
        }

        public async Task<IActionResult> Index([FromQuery] ObterProcessosQuery query)
        {
            var processos = await _obterProcessosHandler.HandleAsync(query);
            return View(processos);
        }

        public IActionResult Cadastrar()
        {
            CarregarUFs();

            return View(new CadastrarProcessoCommand());
        }               

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(CadastrarProcessoCommand command)
        {
            if (!ModelState.IsValid)
            {
                CarregarUFs();
                return View(command);
            }

            var result = await _cadastrarProcessoHandler.HandleAsync(command);

            if (!result.Success)
            {
                if (result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                else if (!string.IsNullOrEmpty(result.Message))
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }

                CarregarUFs();

                return View(command);
            }
                        
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Visualizar(ObterProcessoPorIdQuery query)
        {
            var processo = await _obterProcessoPorIdHandler.HandleAsync(query);

            if (processo == null)
                return NotFound();

            return View(processo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarVisualizacao(ConfirmarVisualizacaoCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = await _confirmarVisualizacaoHandler.HandleAsync(command);

            if (!result.Success)
            {
                if (result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                else if (!string.IsNullOrEmpty(result.Message))
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }

                return View(command);
            }


            return RedirectToAction(nameof(Visualizar), new { Id = command.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CarregarUFs()
        {
            ViewBag.UFs = new List<SelectListItem>
            {
                new SelectListItem { Value = "AC", Text = "Acre" },
                new SelectListItem { Value = "AL", Text = "Alagoas" },
                new SelectListItem { Value = "AP", Text = "Amapá" },
                new SelectListItem { Value = "AM", Text = "Amazonas" },
                new SelectListItem { Value = "BA", Text = "Bahia" },
                new SelectListItem { Value = "CE", Text = "Ceará" },
                new SelectListItem { Value = "DF", Text = "Distrito Federal" },
                new SelectListItem { Value = "ES", Text = "Espírito Santo" },
                new SelectListItem { Value = "GO", Text = "Goiás" },
                new SelectListItem { Value = "MA", Text = "Maranhão" },
                new SelectListItem { Value = "MT", Text = "Mato Grosso" },
                new SelectListItem { Value = "MS", Text = "Mato Grosso do Sul" },
                new SelectListItem { Value = "MG", Text = "Minas Gerais" },
                new SelectListItem { Value = "PA", Text = "Pará" },
                new SelectListItem { Value = "PB", Text = "Paraíba" },
                new SelectListItem { Value = "PR", Text = "Paraná" },
                new SelectListItem { Value = "PE", Text = "Pernambuco" },
                new SelectListItem { Value = "PI", Text = "Piauí" },
                new SelectListItem { Value = "RJ", Text = "Rio de Janeiro" },
                new SelectListItem { Value = "RN", Text = "Rio Grande do Norte" },
                new SelectListItem { Value = "RS", Text = "Rio Grande do Sul" },
                new SelectListItem { Value = "RO", Text = "Rondônia" },
                new SelectListItem { Value = "RR", Text = "Roraima" },
                new SelectListItem { Value = "SC", Text = "Santa Catarina" },
                new SelectListItem { Value = "SP", Text = "São Paulo" },
                new SelectListItem { Value = "SE", Text = "Sergipe" },
                new SelectListItem { Value = "TO", Text = "Tocantins" }
            };
        }
    }
}
