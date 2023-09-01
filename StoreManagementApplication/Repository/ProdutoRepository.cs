using AplicativoDeVendas.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AplicativoDeVendas.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _configuration;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SalvarProduto(Produto produto)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@DescProduto", produto.dscProduto, DbType.String);
            parametro.Add("@VlrUnitario", produto.vlrUnitario, DbType.Decimal);

            string query = @"
                INSERT INTO [Empresa].[dbo].[Produto]
                (
                    [DescProduto],
                    [VlrUnitario]
                )
                VALUES
                (
                    @DescProduto,
                    @VlrUnitario
                )";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public void EditarProduto(int IdProduto, Produto produto)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdProduto", IdProduto, DbType.Int32);
            parametro.Add("@DescProduto", produto.dscProduto, DbType.String);
            parametro.Add("@VlrUnitario", produto.vlrUnitario, DbType.Decimal);

            string query = @"
                UPDATE
                    [Empresa].[dbo].[Produto]
                SET
                    [DescProduto] = @DescProduto,
                    [VlrUnitario] = @VlrUnitario
                WHERE
                    [IdProduto] = @IdProduto";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }

        public Produto BuscarProduto(string DescProduto)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@DescProduto", DescProduto, DbType.String);

            string query = @"
                SELECT
                    [IdProduto]
                    ,[DescProduto]
                    ,[VlrUnitario]
                FROM
                    [Empresa].[dbo].[Produto]
                WHERE
                    [DescProduto] = @DescProduto";

            Produto produto = new Produto();
            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();

                var exec = connection.Query<Produto>(query, parametro);
                produto = exec.FirstOrDefault();

                return produto;
            }
        }

        public void DeletarProduto(int IdProduto)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@IdProduto", IdProduto, DbType.Int32);

            string query = @"
                DELETE FROM
                    [Empresa].[dbo].[Produto]
                WHERE
                    [IdProduto] = @IdProduto";

            using (SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseConnectionString")))
            {
                connection.Open();
                connection.Query(query, parametro);
            }
        }
    }
}
