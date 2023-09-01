using AplicativoDeVendas.Models;
using AplicativoDeVendas.Repository;

namespace AplicativoDeVendas.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void SalvarVenda(Venda venda)
        {
            try
            {
                _vendaRepository.SalvarVenda(venda);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void EditarVenda(int IdVenda, Venda venda)
        {
            try
            {
                _vendaRepository.EditarVenda(IdVenda, venda);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public Venda BuscarVenda(string NomeCliente, string DescProduto)
        {
            try
            {
                return _vendaRepository.BuscarVenda(NomeCliente, DescProduto);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }
        }

        public void ExcluirVenda(int IdVenda)
        {
            try
            {
                _vendaRepository.ExcluirVenda(IdVenda);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public List<VendaDto> ListarVendas()
        {
            try
            {
                return _vendaRepository.ListarVendas();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }
        }
    }
}
