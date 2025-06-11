using Microsoft.EntityFrameworkCore;
using INFRA.Models;

namespace INFRA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produtor> Produtores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(c => c.Senha)
                      .IsRequired();
            });

            modelBuilder.Entity<Produtor>(entity =>
            {
                entity.ToTable("Produtores");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.Cnpj)
                      .IsRequired()
                      .HasMaxLength(18);
                entity.HasIndex(p => p.Cnpj)
                      .IsUnique();
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey(p => p.ProdutoId);

                entity.Property(p => p.NomeProduto)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Quantidade)
                      .IsRequired();

                entity.Property(p => p.Preco)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Produtor)
                      .WithMany()
                      .HasForeignKey(p => p.ProdutorId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.OwnsMany(p => p.Imagens, b =>
                {
                    b.ToTable("ProdutoImagens");
                    b.Property<int>("Id");
                    b.HasKey("Id");
                    b.Property<byte[]>("Value")
                     .HasColumnName("Imagem");
                    b.WithOwner()
                     .HasForeignKey("ProdutoId");
                });
            });

            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.ToTable("Carrinhos");
                entity.HasKey(c => c.CarrinhoId);

                entity.Property(c => c.Total)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne<Cliente>()
                      .WithMany()
                      .HasForeignKey(c => c.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.Produtos)
                      .WithMany()
                      .UsingEntity<Dictionary<string, object>>( 
                          "CarrinhoProdutos",
                          j => j.HasOne<Produto>()
                                .WithMany()
                                .HasForeignKey("ProdutoId")
                                .OnDelete(DeleteBehavior.Cascade),
                          j => j.HasOne<Carrinho>()
                                .WithMany()
                                .HasForeignKey("CarrinhoId")
                                .OnDelete(DeleteBehavior.Cascade),
                          j =>
                          {
                              j.HasKey("CarrinhoId", "ProdutoId");
                              j.ToTable("CarrinhoProdutos");
                          }
                      );
            });
        }
    }
}