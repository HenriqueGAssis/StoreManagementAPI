namespace AplicativoDeVendas.Models
{
    public class VendaDto
    {
        public int idVenda { get; set; }

        public string nmCliente { get; set; }

        public string descProduto { get; set; }

        public int qtdVenda { get; set; }

        public decimal vlrUnitarioVenda { get; set; }

        public DateTime dthVenda { get; set; }

        public decimal vlrTotalVenda { get { return qtdVenda * vlrUnitarioVenda; } }
    }
}
