namespace AplicativoDeVendas.Service
{
    public interface ICargaService
    {
        Task ObterClientesAsync();
        Task ObterProdutosAsync();
        Task ObterVendasAsync();
    }
}