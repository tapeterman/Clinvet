using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinvet.Models
{
    public class SistemaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SistemaContext() : base("name=SistemaContext")
        {
        }

        public System.Data.Entity.DbSet<Clinvet.Models.AgendamentoConsulta> AgendamentoConsultas { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Anamnese> Anamnese { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.ContasAPagar> ContasAPagars { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.FichaAnimal> FichaAnimals { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.FormaDePagamento> FormaDePagamentoes { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Fornecedor> Fornecedors { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.FornecedorProdutoServico> FornecedorProdutoServicoes { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.ProdutoServico> ProdutoServicoes { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Tipo> Tipoes { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.TipoDeConta> TipoDeContas { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.TiposDeVacina> TiposDeVacinas { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Vacina> Vacinas { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.VendaServico> VendaServicoes { get; set; }
    }
}
