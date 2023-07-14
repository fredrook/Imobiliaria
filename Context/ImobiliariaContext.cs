using Entities;
using Imobiliaria.Infrastructure.Mapping;
using Mapping;
using Microsoft.EntityFrameworkCore;


namespace Imobiliaria.Infra
{
    public class ImobiliariaContext : DbContext
    {
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Imovel> Imoveis { get; set; }
        public virtual DbSet<Negociacao> Negociacao { get; set; }

        public ImobiliariaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Imovel>(new ImovelMap().Configure);
            modelBuilder.Entity<Negociacao>(new NegociacaoMap().Configure);
        }
    }
}