using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.Id);

            builder.Property(produto => produto.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.Property(produto => produto.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(500)");

            builder.Property(produto => produto.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.OwnsOne(produto => produto.Dimensoes,
                            construtor =>
                            {
                                construtor.Property(dimensoes => dimensoes.Altura)
                                          .HasColumnName("Altura")
                                          .HasColumnType("int");

                                construtor.Property(dimensoes => dimensoes.Largura)
                                          .HasColumnName("Largura")
                                          .HasColumnType("int");

                                construtor.Property(dimensoes => dimensoes.Profundidade)
                                          .HasColumnName("Profundidade")
                                          .HasColumnType("int");
                            });

            builder.ToTable("Produtos");
        }
    }
}
