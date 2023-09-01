namespace AplicativoDeVendas.Models
{
    public class Venda
    {
        public int idVenda { get; set; }

        public int idCliente { get; set; }

        public int idProduto { get; set; }

        public int qtdVenda { get; set; }

        public decimal vlrUnitarioVenda { get; set; }

        public DateTime dthVenda { get; set; }

        public decimal vlrTotalVenda { get { return qtdVenda * vlrUnitarioVenda; } }
    }
}
