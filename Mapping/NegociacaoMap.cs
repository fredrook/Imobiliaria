using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping
{
    public class NegociacaoMap : IEntityTypeConfiguration<Negociacao>
    {
        public void Configure(EntityTypeBuilder<Negociacao> builder)
        {
            builder.HasKey(c => c.IdImovelNegociacao);

            builder.Property(c => c.ValorAluguel).HasColumnType("decimal(18,2)");
            builder.Property(c => c.ValorVenda).HasColumnType("decimal(18,2)");
            builder.Property(c => c.ValorCondominio).HasColumnType("decimal(18,2)");
            builder.Property(c => c.ValorIptu).HasColumnType("decimal(18,2)");

            builder.Property(p => p.DisponivelParaAluguel);
            builder.Property(p => p.DisponivelParaVenda);

            builder.Property(p => p.Locado);
            builder.Property(p => p.Vendido);

            builder.HasOne(c => c.Imovel)
                .WithMany(c => c.Negociacao)
                .HasForeignKey(c => c.IdImovel);

            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}
