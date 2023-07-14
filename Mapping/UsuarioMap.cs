using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace Imobiliaria.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.IdUsuario);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Login).IsRequired();
            builder.Property(c => c.Senha).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Cpf).IsRequired();
            builder.Property(c => c.TipoUsuario).IsRequired();

            builder.Property(c => c.UsuarioInclusao);
            builder.Property(c => c.DataInclusao);
            builder.Property(c => c.UsuarioAlteracao);
            builder.Property(c => c.DataAlteracao);
            builder.Property(c => c.UsuarioExclusao);
            builder.Property(c => c.DataExclusao);
            builder.Property(c => c.Situacao);
            
        }
    }
}
