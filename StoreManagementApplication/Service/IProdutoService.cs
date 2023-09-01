using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Service
{
    public interface IProdutoService
    {
        void SalvarProduto(Produto produto);
        void EditarProduto(int IdProduto, Produto produto);
        Produto BuscarProduto(string DescProduto);
        void DeletarProduto(int IdProduto);
    }
}