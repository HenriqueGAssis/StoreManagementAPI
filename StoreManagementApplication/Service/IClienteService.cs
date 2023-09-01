using AplicativoDeVendas.Models;

namespace AplicativoDeVendas.Service
{
    public interface IClienteService
    {
        void CadastrarCliente(Cliente cliente);
        void EditarCliente(int IdCliente, Cliente cliente);
        Cliente BuscarCliente(string NomeCliente);
        void DeletarCliente(int IdCliente);
    }
}