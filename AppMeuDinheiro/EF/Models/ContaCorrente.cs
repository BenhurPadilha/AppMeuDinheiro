using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMeuDinheiro.EF.Models
{
    internal class ContaCorrente
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public decimal Saldo { get; set; }

        // Relacionamento com Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com Extrato
        public ICollection<Extrato> Extratos { get; set; }
    }
}
