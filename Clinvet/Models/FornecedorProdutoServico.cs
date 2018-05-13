namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FornecedorProdutoServico
    {
        [Key]
        public long IdFornecedorProduto { get; set; }
        public long IdFornecedor { get; set; }
        public long IdProduto { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ProdutoServico ProdutoServico { get; set; }
    }
}
