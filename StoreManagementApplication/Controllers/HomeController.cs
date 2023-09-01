using AplicativoDeVendas.Models;
using AplicativoDeVendas.Service;
using Microsoft.AspNetCore.Mvc;

namespace AplicativoDeVendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVendaService _vendasService;
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly ICargaService _cargaService;

        public HomeController(ILogger<HomeController> logger, IVendaService vendaService, IClienteService clienteService, IProdutoService produtoService, ICargaService cargaService)
        {
            _logger = logger;
            _vendasService = vendaService;
            _clienteService = clienteService;
            _produtoService = produtoService;
            _cargaService = cargaService;
        }

        public IActionResult Index()
        {
            List<VendaDto> resultados = _vendasService.ListarVendas();

            return View(resultados);
        }

        public async Task<IActionResult> RealizarCargaDados()
        {
            // Realiza uma nova carga de dados
            await _cargaService.ObterClientesAsync();
            await _cargaService.ObterProdutosAsync();
            await _cargaService.ObterVendasAsync();

            return RedirectToAction("Index");
        }

        public IActionResult SalvarProduto()
        {
            return View();
        }

        public IActionResult SalvarVenda()
        {
            return View();
        }

        public IActionResult EditarVenda()
        {
            return View();
        }

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        public IActionResult ExcluirVenda(int id)
        {
            _vendasService.ExcluirVenda(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SalvarProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _produtoService.SalvarProduto(produto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _clienteService.CadastrarCliente(cliente);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SalvarVenda(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _vendasService.SalvarVenda(venda);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarVenda(int id, Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _vendasService.EditarVenda(id, venda);

            return RedirectToAction("Index");
        }
    }
}