using AplicativoDeVendas.Models;
using AplicativoDeVendas.Repository;

namespace AplicativoDeVendas.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            if(string.IsNullOrEmpty(cliente.nmCliente) || string.IsNullOrEmpty(cliente.Cidade))
            {
                throw new ArgumentException("Campo Nome do Cliente e Cidade são obrigatórios!");
            }

            try
            {
                _clienteRepository.SalvarCliente(cliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void EditarCliente(int IdCliente, Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.nmCliente) || string.IsNullOrEmpty(cliente.Cidade))
            {
                throw new ArgumentException("Campo Nome do Cliente e Cidade são obrigatórios!");
            }

            try
            {
                _clienteRepository.EditarCliente(IdCliente, cliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public Cliente BuscarCliente(string NomeCliente)
        {
            try
            {
                return _clienteRepository.BuscarCliente(NomeCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }
        }

        public void DeletarCliente(int IdCliente)
        {
            try
            {
                _clienteRepository.DeletarCliente(IdCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
