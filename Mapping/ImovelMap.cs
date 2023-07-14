using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imobiliaria.Infrastructure.Mapping
{
    public class ImovelMap : BaseModelMap<Imovel>
    {
        public override void Configure(EntityTypeBuilder<Imovel> builder)
        {
            base.Configure(builder);

            builder.HasKey(c => c.IdImovel);

            builder.Property(m => m.NomeImovel).IsRequired();
            builder.Property(m => m.NQuarto);
            builder.Property(m => m.NBanheiro);
            builder.Property(m => m.NVagasGaragem);
            builder.Property(m => m.MetrosQuadrados);

            builder.Property(v => v.ValorAluguel).HasColumnType("decimal(18,2)"); ;
            builder.Property(v => v.ValorVenda).HasColumnType("decimal(18,2)"); ;
            builder.Property(v => v.ValorCondominio).HasColumnType("decimal(18,2)"); ;
            builder.Property(v => v.ValorIptu).HasColumnType("decimal(18,2)"); ;

            builder.Property(p => p.Cep);
            builder.Property(p => p.Estado);
            builder.Property(p => p.Cidade);
            builder.Property(p => p.Bairro);
            builder.Property(p => p.Logradouro);
            builder.Property(p => p.Numero);
            builder.Property(p => p.Complemento);
            builder.Property(p => p.Referencia);

            builder.Property(p => p.DisponivelParaAluguel);
            builder.Property(p => p.DisponivelParaVenda);
            builder.Property(p => p.Locado);
            builder.Property(p => p.Vendido);

            //builder.HasMany(x => x.Negociacao);
        }
    }
}
