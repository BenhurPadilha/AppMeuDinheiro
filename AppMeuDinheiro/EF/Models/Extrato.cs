using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMeuDinheiro.EF.Models
{
    internal class Extrato
    {
        public int Id { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Movimentacao { get; set; }
        public decimal Valor { get; set; }

        // Relacionamento com ContaCorrente
        public int ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
    }
}
