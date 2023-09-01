using AplicativoDeVendas.Models;
using AplicativoDeVendas.Repository;
using Newtonsoft.Json;

namespace AplicativoDeVendas.Service
{
    public class CargaService : ICargaService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVendaRepository _vendaRepository;

        public CargaService(IProdutoRepository produtoRepository, IClienteRepository clienteRepository, IVendaRepository vendaRepository)
        {
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _vendaRepository = vendaRepository;
        }

        public async Task ObterClientesAsync()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Carga de dados - Apenas para teste
                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();

                        listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(JsonConvert.DeserializeObject<string>(jsonContent));
                    }
                    else
                    {
                        throw new HttpRequestException();
                    }

                    foreach (var cliente in listaClientes)
                    {
                        _clienteRepository.SalvarCliente(cliente);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        public async Task ObterProdutosAsync()
        {
            List<Produto> listaProdutos= new List<Produto>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Carga de dados - Apenas para teste
                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();

                        listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(JsonConvert.DeserializeObject<string>(jsonContent));
                    }
                    else
                    {
                        throw new HttpRequestException();
                    }

                    foreach (var produto in listaProdutos)
                    {
                        _produtoRepository.SalvarProduto(produto);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        public async Task ObterVendasAsync()
        {
            List<Venda> listaVendas = new List<Venda>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Carga de dados - Apenas para teste
                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();

                        listaVendas = JsonConvert.DeserializeObject<List<Venda>>(JsonConvert.DeserializeObject<string>(jsonContent));
                    }
                    else
                    {
                        throw new HttpRequestException();
                    }

                    foreach (var venda in listaVendas)
                    {
                        _vendaRepository.SalvarVenda(venda);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
