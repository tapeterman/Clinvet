namespace Clinvet.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClinvetContext : DbContext {
        public ClinvetContext()
            : base("name=ClinvetContext") {
        }

        public virtual DbSet<AgendamentoConsulta> AgendamentoConsulta { get; set; }
        public virtual DbSet<Anamnese> Anamnese { get; set; }
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ContasAPagar> ContasAPagar { get; set; }
        public virtual DbSet<FichaAnimal> FichaAnimal { get; set; }
        public virtual DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<ProdutoServico> ProdutoServico { get; set; }
        public virtual DbSet<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }
        public virtual DbSet<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<TipoDeConta> TipoDeConta { get; set; }
        public virtual DbSet<TiposDeVacina> TiposDeVacina { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vacina> Vacina { get; set; }
        public virtual DbSet<VendaServico> VendaServico { get; set; }
        public virtual DbSet<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

        //-----------------------------------------------------------------------

            modelBuilder.Entity<AgendamentoConsulta>()
                .ToTable("agendamento_consulta");

            modelBuilder.Entity<AgendamentoConsulta>()
               .Property(e => e.DataDeAgendamento)
               .HasColumnName("data_de_agendamento");

            modelBuilder.Entity<AgendamentoConsulta>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<AgendamentoConsulta>()
                .Property(e => e.Status)
                .HasColumnName("status")
                .IsUnicode(false);

            modelBuilder.Entity<AgendamentoConsulta>()
               .Property(e => e.IdCliente)
               .HasColumnName("id_cliente");

            modelBuilder.Entity<AgendamentoConsulta>()
                .HasMany(e => e.ProdutoServicoAgendamentoConsultas)
                .WithRequired(e => e.Agendamentoconsulta)
                .HasForeignKey(e => e.IdAgendamentoConsulta);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Anamnese>()
                .ToTable("anamnese");

            modelBuilder.Entity<Anamnese>()
                .Property(e => e.Diagnostico)
                .HasColumnName("diagnostico")
                .IsUnicode(false);

            modelBuilder.Entity<Anamnese>()
                .Property(e => e.Anamnese1)
                .HasColumnName("anamnese")
                .IsUnicode(false);

            modelBuilder.Entity<Anamnese>()
                .Property(e => e.Medicamentos)
                .HasColumnName("medicamentos")
                .IsUnicode(false);

            modelBuilder.Entity<Anamnese>()
                .Property(e => e.ProcedimentosRealizados)
                .HasColumnName("procedimentos_realizados")
                .IsUnicode(false);

            modelBuilder.Entity<Anamnese>()
                .Property(e => e.IdFichaAnimal)
                .HasColumnName("id_ficha_animal");

            //-----------------------------------------------------------------------

            modelBuilder.Entity<Animal>()
                .ToTable("animal");

            modelBuilder.Entity<Animal>()
                .Property(e => e.Nome)
                .HasColumnName("nome")
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Raca)
                .HasColumnName("raca")
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.PesoOuPorte)
                .HasColumnName("peso_ou_porte")
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.DataNascimento)
                .HasColumnName("data_nascimento");

            modelBuilder.Entity<Animal>()
                .Property(e => e.Especie)
                .HasColumnName("especie")
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Sexo)
                .HasColumnName("sexo")
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
               .Property(e => e.IdCliente)
               .HasColumnName("id_cliente");

            modelBuilder.Entity<Animal>()
                .HasMany(e => e.FichaAnimal)
                .WithRequired(e => e.Animal)
                .HasForeignKey(e => e.IdAnimal)
                .WillCascadeOnDelete(false);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Cliente>()
                .ToTable("cliente");

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .HasColumnName("nome")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cpf)
                .HasColumnName("cpf")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone)
                .HasColumnName("telefone")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Email)
                .HasColumnName("email")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Rua)
                .HasColumnName("rua")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Numero)
                .HasColumnName("numero")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Bairro)
                .HasColumnName("bairro")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cidade)
                .HasColumnName("cidade")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cep)
                .HasColumnName("cep")
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.AgendamentoConsulta)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Animal)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.VendaServico)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<ContasAPagar>()
                .ToTable("contas_a_pagar");

            modelBuilder.Entity<ContasAPagar>()
                .Property(e => e.Data)
                .HasColumnName("data");

            modelBuilder.Entity<ContasAPagar>()
                .Property(e => e.Valor)
                .HasColumnName("valor")
                .HasPrecision(15, 2);

            modelBuilder.Entity<ContasAPagar>()
                .Property(e => e.IdFornecedor)
                .HasColumnName("id_fornecedor");

            modelBuilder.Entity<ContasAPagar>()
                .Property(e => e.IdTipoDeConta)
                .HasColumnName("id_tipo_de_conta");

        //-----------------------------------------------------------------------

            modelBuilder.Entity<FichaAnimal>()
                .ToTable("ficha_animal");

            modelBuilder.Entity<FichaAnimal>()
                .Property(e => e.PesoPorteAntesDosProcedimentos)
                 .HasColumnName("peso_porte_antes_dos_procedimentos")
                .IsUnicode(false);

            modelBuilder.Entity<FichaAnimal>()
                .Property(e => e.IdAnimal)
                .HasColumnName("id_animal");

            modelBuilder.Entity<FichaAnimal>()
                .HasMany(e => e.Anamnese)
                .WithRequired(e => e.FichaAnimal)
                .HasForeignKey(e => e.IdFichaAnimal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FichaAnimal>()
                .HasMany(e => e.Vacina)
                .WithRequired(e => e.FichaAnimal)
                .HasForeignKey(e => e.IdFichaAnimal);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<FormaDePagamento>()
                .ToTable("forma_de_pagamento");

            modelBuilder.Entity<FormaDePagamento>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<FormaDePagamento>()
                .HasMany(e => e.VendaServicoFormaDePagamento)
                .WithRequired(e => e.FormaDePagamento)
                .HasForeignKey(e => e.IdFormaDePagamento);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Fornecedor>()
                .ToTable("fornecedor");

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.NomeFantasia)
                .HasColumnName("nome_fantasia")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Cnpj)
                .HasColumnName("cnpj")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.RazaoSocial)
                .HasColumnName("razao_social")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Telefone)
                .HasColumnName("telefone")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Rua)
                .HasColumnName("rua")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Numero)
                .HasColumnName("numero")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Bairro)
                .HasColumnName("bairro")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Cidade)
                .HasColumnName("cidade")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Cep)
                .HasColumnName("cep")
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.ContasAPagar)
                .WithRequired(e => e.Fornecedor)
                .HasForeignKey(e => e.IdFornecedor);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.FornecedorProdutoServico)
                .WithRequired(e => e.Fornecedor)
                .HasForeignKey(e => e.IdFornecedor);

            //-----------------------------------------------------------------------

            modelBuilder.Entity<FornecedorProdutoServico>()
                .ToTable("fornecedor_produto_servico");

            modelBuilder.Entity<FornecedorProdutoServico>()
                .Property(e => e.IdFornecedorProduto)
                .HasColumnName("id_fornecedor_produto");

            modelBuilder.Entity<FornecedorProdutoServico>()
                .Property(e => e.IdFornecedor)
                .HasColumnName("id_fornecedor");

            modelBuilder.Entity<FornecedorProdutoServico>()
                .Property(e => e.IdProduto)
                .HasColumnName("id_produto");

            //-----------------------------------------------------------------------

            modelBuilder.Entity<Funcionario>()
                .ToTable("funcionario");

            modelBuilder.Entity<Funcionario>()
               .Property(e => e.IdUsuario)
               .HasColumnName("id_usuario");

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Nome)
                .HasColumnName("nome")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.TituloDeEleitor)
                .HasColumnName("titulo_de_eleitor")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Rg)
                .HasColumnName("rg")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Cpf)
                .HasColumnName("cpf")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Pis)
                .HasColumnName("pis")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Funcao)
                .HasColumnName("funcao")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Telefone)
                .HasColumnName("telefone")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Rua)
                .HasColumnName("rua")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Numero)
                .HasColumnName("numero")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Bairro)
                .HasColumnName("bairro")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Cidade)
                .HasColumnName("cidade")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Cep)
                .HasColumnName("cep")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Email)
                .HasColumnName("email")
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.VendasServicos)
                .WithRequired(e => e.Funcionario)
                .HasForeignKey(e => e.IdFuncionario)
                .WillCascadeOnDelete(false);

            //-----------------------------------------------------------------------

            modelBuilder.Entity<ProdutoServico>()
                .ToTable("produto_servico");

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.Nome)
                .HasColumnName("nome")
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.Marca)
                .HasColumnName("marca")
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.PrecoDeVenda)
                .HasColumnName("preco_de_venda")
                .HasPrecision(15, 2);

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.PrecoDeCompra)
                .HasColumnName("preco_de_compra")
                .HasPrecision(15, 2);

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.Lote)
                .HasColumnName("lote")
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoServico>()
                .Property(e => e.IdTipo)
                .HasColumnName("id_tipo");

            modelBuilder.Entity<ProdutoServico>()
                .HasMany(e => e.FornecedorProdutoServico)
                .WithRequired(e => e.ProdutoServico)
                .HasForeignKey(e => e.IdProduto);

            modelBuilder.Entity<ProdutoServico>()
                .HasMany(e => e.ProdutoServicoAgendamentoConsultas)
                .WithRequired(e => e.ProdutoServico)
                .HasForeignKey(e => e.IdProdutoServico);

            modelBuilder.Entity<ProdutoServico>()
                .HasMany(e => e.ProdutoServicoVendaServico)
                .WithRequired(e => e.ProdutoServico)
                .HasForeignKey(e => e.IdProdutoServico);

            //-----------------------------------------------------------------------

            modelBuilder.Entity<ProdutoServicoAgendamentoConsultas>()
                .ToTable("produto_servico_agendamento_consultas");

            modelBuilder.Entity<ProdutoServicoAgendamentoConsultas>()
               .Property(e => e.IdProdutoServicoAgendamentoConsulta)
               .HasColumnName("id_produto_servico_agendamento_consulta");

            modelBuilder.Entity<ProdutoServicoAgendamentoConsultas>()
                .Property(e => e.IdProdutoServico)
                .HasColumnName("id_produto_servico");

            modelBuilder.Entity<ProdutoServicoAgendamentoConsultas>()
               .Property(e => e.IdAgendamentoConsulta)
               .HasColumnName("id_agendamento_consulta");

            //-----------------------------------------------------------------------

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .ToTable("produto_servico_venda_servico");

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .Property(e => e.IdProdutoServicoVendaServico)
                .HasColumnName("id_produto_servico_venda_servico");

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .Property(e => e.IdProdutoServico)
                .HasColumnName("id_produto_servico");

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .Property(e => e.IdVendaServico)
                .HasColumnName("id_venda_servico");

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .Property(e => e.QuantidadeProduto)
                .HasColumnName("quantidade_produto");

            modelBuilder.Entity<ProdutoServicoVendaServico>()
                .Property(e => e.ValorProduto)
                .HasColumnName("valor_produto")
                .HasPrecision(15, 2);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Tipo>()
                .ToTable("tipo");

            modelBuilder.Entity<Tipo>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<Tipo>()
                .HasMany(e => e.ProdutoServico)
                .WithRequired(e => e.Tipo)
                .HasForeignKey(e => e.IdTipo)
                .WillCascadeOnDelete(false);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<TipoDeConta>()
                .ToTable("tipo_de_conta");

            modelBuilder.Entity<TipoDeConta>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<TipoDeConta>()
                .HasMany(e => e.ContasAPagar)
                .WithRequired(e => e.TipoDeConta)
                .HasForeignKey(e => e.IdTipoDeConta);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<TiposDeVacina>()
                .ToTable("tipos_de_vacina");

            modelBuilder.Entity<TiposDeVacina>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<TiposDeVacina>()
                .HasMany(e => e.Vacina)
                .WithRequired(e => e.TiposDeVacina)
                .HasForeignKey(e => e.IdTiposDeVacina);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Usuario>()
                .ToTable("usuario");

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Login)
                .HasColumnName("login")
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .HasColumnName("senha")
                .IsUnicode(false);
  
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Funcionarios)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario);

        //-----------------------------------------------------------------------

            modelBuilder.Entity<Vacina>()
                .ToTable("vacina");

            modelBuilder.Entity<Vacina>()
                .Property(e => e.Marca)
                .HasColumnName("marca")
                .IsUnicode(false);

            modelBuilder.Entity<Vacina>()
                .Property(e => e.Lote)
                .HasColumnName("lote")
                .IsUnicode(false);

            modelBuilder.Entity<Vacina>()
                .Property(e => e.Fornecedor)
                .HasColumnName("fornecedor")
                .IsUnicode(false);

            modelBuilder.Entity<Vacina>()
                .Property(e => e.Custo)
                .HasColumnName("custo")
                .HasPrecision(15, 2);

            modelBuilder.Entity<Vacina>()
                .Property(e => e.IdFichaAnimal)
                .HasColumnName("id_ficha_animal");

            modelBuilder.Entity<Vacina>()
                .Property(e => e.IdTiposDeVacina)
                .HasColumnName("id_tipos_de_vacina");

            //-----------------------------------------------------------------------

            modelBuilder.Entity<VendaServico>()
                .ToTable("venda_servico");

            modelBuilder.Entity<VendaServico>()
                .Property(e => e.ValorTotal)
                .HasColumnName("valor_total")
                .HasPrecision(15, 2);

            modelBuilder.Entity<VendaServico>()
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsUnicode(false);

            modelBuilder.Entity<VendaServico>()
               .Property(e => e.IdFuncionario)
               .HasColumnName("id_funcionario");

            modelBuilder.Entity<VendaServico>()
               .Property(e => e.IdCliente)
               .HasColumnName("id_cliente");

            modelBuilder.Entity<VendaServico>()
               .Property(e => e.DataServico)
               .HasColumnName("data_servico");

            modelBuilder.Entity<VendaServico>()
                .HasMany(e => e.ProdutoServicoVendaServico)
                .WithRequired(e => e.VendaServico)
                .HasForeignKey(e => e.IdVendaServico);

            modelBuilder.Entity<VendaServico>()
                .HasMany(e => e.VendaServicoFormaDePagamento)
                .WithRequired(e => e.VendaServico)
                .HasForeignKey(e => e.IdVendaServico);

            //-----------------------------------------------------------------------

            modelBuilder.Entity<VendaServicoFormaDePagamento>()
                .ToTable("venda_servico_forma_de_pagamento");

            modelBuilder.Entity<VendaServicoFormaDePagamento>()
                .Property(e => e.IdVendaServicoFormaDePagamento)
                .HasColumnName("id_venda_servico_forma_de_pagamento");

            modelBuilder.Entity<VendaServicoFormaDePagamento>()
                .Property(e => e.IdVendaServico)
                .HasColumnName("id_venda_servico");

            modelBuilder.Entity<VendaServicoFormaDePagamento>()
                .Property(e => e.IdFormaDePagamento)
                .HasColumnName("id_forma_de_pagamento");
        }
    }
}
