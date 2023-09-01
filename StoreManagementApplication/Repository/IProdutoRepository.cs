using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Repository
{
    public interface IProdutoRepository
    {
        Produto BuscarProduto(string DescProduto);
        void DeletarProduto(int IdProduto);
        void EditarProduto(int IdProduto, Produto produto);
        void SalvarProduto(Produto produto);
    }
}