using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinvet.Models
{
    public partial class FornecedorProdutoServico
    {
        [Key]
        public long IdFornecedorProduto { get; set; }
        public long IdFornecedor { get; set; }
        public long IdProduto { get; set; }

        public Fornecedor IdFornecedorNavigation { get; set; }
        public ProdutoServico IdProdutoNavigation { get; set; }
    }
}
