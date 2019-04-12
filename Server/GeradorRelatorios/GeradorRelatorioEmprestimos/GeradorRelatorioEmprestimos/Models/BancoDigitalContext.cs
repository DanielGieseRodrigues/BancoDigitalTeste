using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServerSide.Models
{
    public partial class BancoDigitalContext : DbContext
    {
        public BancoDigitalContext()
        {
        }

        public BancoDigitalContext(DbContextOptions<BancoDigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9AUJK9K\\SQLEXPRESS;Initial Catalog=BancoDigital;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.LimiteEmprestimo)
                    .HasColumnName("limiteEmprestimo")
                    .HasColumnType("money");

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Usuário)
                    .HasColumnName("usuário")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.IdEmprestimo);

                entity.Property(e => e.IdEmprestimo).HasColumnName("idEmprestimo");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.DataEmprestimo)
                    .HasColumnName("dataEmprestimo")
                    .HasColumnType("date");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("money");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Emprestimo)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK__Emprestim__clien__3F466844");
            });
        }
    }
}
