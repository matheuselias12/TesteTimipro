using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TimproTeste.Entidade
{
    public partial class TesteTimipro : DbContext
    {
        public TesteTimipro()
            : base("name=TesteTimipro")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Imovel1)
                .WithOptional(e => e.Clientes1)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.Clientes)
                .WithOptional(e => e.Imovel)
                .HasForeignKey(e => e.ImovelId);
        }
    }
}
