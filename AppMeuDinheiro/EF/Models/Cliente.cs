using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMeuDinheiro.EF.Models
{
    internal class Cliente
    {
        [Key]

        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamento com ContaCorrente
        public ICollection<ContaCorrente> ContasCorrentes { get; set; }
    }
}
