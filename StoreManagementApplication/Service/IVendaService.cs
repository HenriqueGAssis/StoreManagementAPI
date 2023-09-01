using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Service
{
    public interface IVendaService
    {
        Venda BuscarVenda(string NomeCliente, string DescProduto);
        void EditarVenda(int IdVenda, Venda venda);
        void SalvarVenda(Venda venda);
        void ExcluirVenda(int IdVenda);
        List<VendaDto> ListarVendas();
    }
}