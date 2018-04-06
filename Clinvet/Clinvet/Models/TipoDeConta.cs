using System;
using System.Collections.Generic;

namespace Clinvet.Models
{
    public partial class TipoDeConta
    {
        public TipoDeConta()
        {
            ContasAPagar = new HashSet<ContasAPagar>();
        }

        public long Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<ContasAPagar> ContasAPagar { get; set; }
    }
}
