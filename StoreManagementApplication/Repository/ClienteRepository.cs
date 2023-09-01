using AplicativoDeVendas.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AplicativoDeVendas.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SalvarCliente(Cliente cliente)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Nome", cliente.nmCliente, DbType.String);
            parametro.Add("@Cidade", cliente.Cidade, DbType.String);

            string query = @"
                INSERT INTO [Empresa].[dbo].[Cliente]
                (
                    [NmCliente],
                    [Cidade]
                )
                VALUES 
                (
                    @Nome,
                    @Cidade
                )";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public void EditarCliente(int IdCliente, Cliente cliente)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Nome", cliente.nmCliente, DbType.String);
            parametro.Add("@Cidade", cliente.Cidade, DbType.String);

            string query = @"
                    UPDATE
                        [Empresa].[dbo].[Cliente]
                    SET
                        [NmCliente] = @Nome,
                        [Cidade] = @Cidade
                    WHERE
                        [Id] = @IdCliente";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public Cliente BuscarCliente(string NomeCliente)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@NomeCliente", NomeCliente, DbType.String);

            string query = @"
                    SELECT
                        [IdCliente]
                        ,[NmCliente]
                        ,[Cidade]
                    FROM
                        [Empresa].[dbo].[Cliente]
                    WHERE
                        [NmCliente] = @NomeCliente";

            Cliente cliente = new Cliente();
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();

                var exec = connection.Query<Cliente>(query, parametro);
                cliente = exec.FirstOrDefault();

                return cliente;
            }
        }

        public void DeletarCliente(int IdCliente)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdCliente", IdCliente, DbType.String);

            string query = @"
                DELETE FROM
                    [Empresa].[dbo].[Cliente]
                WHERE
                    [IdCliente] = @IdCliente";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }
    }
}
