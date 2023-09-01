using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Repository
{
    public interface IClienteRepository
    {
        Cliente BuscarCliente(string NomeCliente);
        void DeletarCliente(int IdCliente);
        void EditarCliente(int IdCliente, Cliente cliente);
        void SalvarCliente(Cliente cliente);
    }
}