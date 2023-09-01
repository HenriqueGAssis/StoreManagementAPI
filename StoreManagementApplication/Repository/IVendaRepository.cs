using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Repository
{
    public interface IVendaRepository
    {
        Venda BuscarVenda(string NomeCliente, string DescProduto);
        void ExcluirVenda(int IdVenda);
        void EditarVenda(int IdVenda, Venda venda);
        void SalvarVenda(Venda venda);
        List<VendaDto> ListarVendas();
    }
}