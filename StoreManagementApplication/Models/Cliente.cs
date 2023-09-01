using System.ComponentModel.DataAnnotations;

namespace AplicativoDeVendas.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string nmCliente { get; set; }

        public string Cidade { get; set; }
    }
}