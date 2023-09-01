using AplicativoDeVendas.Models;
using AplicativoDeVendas.Repository;

namespace AplicativoDeVendas.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void SalvarProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.dscProduto) || string.IsNullOrEmpty(produto.vlrUnitario.ToString()))
            {
                throw new ArgumentException("Campo Descição do Produto e Valor Unitário são obrigatórios!");
            }

            try
            {
                _produtoRepository.SalvarProduto(produto);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void EditarProduto(int IdProduto, Produto produto)
        {
            if (string.IsNullOrEmpty(produto.dscProduto) || string.IsNullOrEmpty(produto.vlrUnitario.ToString()))
            {
                throw new ArgumentException("Campo Descição do Produto e Valor Unitário são obrigatórios!");
            }

            try
            {
                _produtoRepository.EditarProduto(IdProduto, produto);
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public Produto BuscarProduto(string DescProduto)
        {
            try
            {
                return _produtoRepository.BuscarProduto(DescProduto);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }
        }

        public void DeletarProduto(int IdProduto)
        {
            try
            {
                _produtoRepository.DeletarProduto(IdProduto);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
