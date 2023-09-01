using AplicativoDeVendas.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace AplicativoDeVendas.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IConfiguration _configuration;

        public VendaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SalvarVenda(Venda venda)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdCliente", venda.idCliente, DbType.Int32);
            parametro.Add("@IdProduto", venda.idProduto, DbType.Int32);
            parametro.Add("@QtdVenda", venda.qtdVenda, DbType.Int32);
            parametro.Add("@VlrUnitarioVenda", venda.vlrUnitarioVenda, DbType.Decimal);
            parametro.Add("@VlrTotal", venda.vlrTotalVenda, DbType.Decimal);

            string query = @"
                    INSERT INTO [Empresa].[dbo].[Venda]
                    (
                       [IdCliente]
                      ,[IdProduto]
                      ,[QtdVenda]
                      ,[VlrUnitarioVenda]
                      ,[VlrTotalVenda]
                    )
                    VALUES 
                    (
                        @IdCliente,
                        @IdProduto,
                        @QtdVenda,
                        @VlrUnitarioVenda,
                        @VlrTotal
                    )";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public void EditarVenda(int IdVenda, Venda venda)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdVenda", IdVenda, DbType.Int32);
            parametro.Add("@IdCliente", venda.idCliente, DbType.Int32);
            parametro.Add("@IdProduto", venda.idProduto, DbType.Int32);
            parametro.Add("@QtdVenda", venda.qtdVenda, DbType.Int32);
            parametro.Add("@VlrTotal", venda.vlrTotalVenda, DbType.Decimal);
            parametro.Add("@VlrUnitarioVenda", venda.vlrUnitarioVenda, DbType.Decimal);
            parametro.Add("@DthVenda", venda.dthVenda, DbType.DateTime);

            string query = @"
                    UPDATE
                        [Empresa].[dbo].[Venda]
                    SET
                        [IdCliente] = @IdCliente,
                        [IdProduto] = @IdProduto,
                        [QtdVenda] = @QtdVenda,
                        [VlrUnitarioVenda] = @VlrUnitarioVenda,
                        [DthVenda] = @DthVenda,
                        [VlrTotalVenda] = @VlrTotal
                    WHERE
                        [IdVenda] = @IdVenda";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public Venda BuscarVenda(string NomeCliente, string DescProduto)
        {
            if (!string.IsNullOrEmpty(NomeCliente))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@NmCliente", NomeCliente, DbType.String);

                string query = @"
                            SELECT
                                [IdVenda]
                                ,A.[IdCliente]
                                ,A.[IdProduto]
                                ,[QtdVenda]
                                ,[VlrUnitarioVenda]
                                ,[DthVenda]
                                ,[VlrTotalVenda]
                            FROM
                                [Empresa].[dbo].[Venda] A
                                INNER JOIN [Empresa].[dbo].[Cliente] B ON A.[IdCliente] = B.[IdCliente]
                            WHERE
                                B.[NmCliente] = @NmCliente";

                Venda venda = new Venda();
                using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
                {
                    connection.Open();

                    var exec = connection.Query<Venda>(query, parametro);
                    venda = exec.FirstOrDefault();

                    return venda;
                }
            }
            else if (!string.IsNullOrEmpty(DescProduto))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@DescProduto", DescProduto, DbType.String);

                string query = @"
                            SELECT
                                [IdVenda]
                                ,A.[IdCliente]
                                ,A.[IdProduto]
                                ,[QtdVenda]
                                ,[VlrUnitarioVenda]
                                ,[DthVenda]
                                ,[VlrTotalVenda]
                            FROM
                                [Empresa].[dbo].[Venda] A
                                INNER JOIN [Empresa].[dbo].[Produto] B ON A.[IdProduto] = B.[IdProduto]
                            WHERE
                                B.[DescProduto] = @DescProduto";

                Venda venda = new Venda();
                using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
                {
                    connection.Open();

                    var exec = connection.Query<Venda>(query, parametro);
                    venda = exec.FirstOrDefault();

                    return venda;
                }
            }
            else
            {
                return null;
            }

        }

        public void ExcluirVenda(int IdVenda)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdVenda", IdVenda, DbType.Int32);

            string query = @"
                    DELETE FROM
                        [Empresa].[dbo].[Venda]
                    WHERE
                        [IdVenda] = @IdVenda";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query<Venda>(query, parametro);
            }
        }

        public List<VendaDto> ListarVendas()
        {
            string query = @"
                        SELECT
                            [IdVenda]
                            ,B.[NmCliente]
                            ,C.[DescProduto]
                            ,[QtdVenda]
                            ,[VlrUnitarioVenda]
                            ,[DthVenda]
                            ,[VlrTotalVenda]
                        FROM
                            [Empresa].[dbo].[Venda] A
                            INNER JOIN [Empresa].[dbo].[Cliente] B ON A.[IdCliente] = B.[IdCliente]
                            INNER JOIN [Empresa].[dbo].[Produto] C ON A.[IdProduto] = C.[IdProduto]";

            List<VendaDto> listaVendas = new List<VendaDto>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();

                var exec = connection.Query<VendaDto>(query);
                listaVendas = exec.ToList();

                return listaVendas;
            }
        }
    }
}
