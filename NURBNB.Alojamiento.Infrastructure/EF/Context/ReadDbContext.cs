using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;

namespace NURBNB.Alojamiento.Infrastructure.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<PaisReadModel> Pais { set; get; }
        public virtual DbSet<CiudadReadModel> Ciudad { set; get; }
        public virtual DbSet<PropiedadReadModel> Propiedad { set; get; }
        public virtual DbSet<DireccionReadModel> Direccion { set; get; }
        public virtual DbSet<ComodidadReadModel> Comodidad { set; get; }
        public virtual DbSet<PropiedadComodidadReadModel> PropiedadComodidad { set; get; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PropiedadReadModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Fotos)
                      .WithOne()
                      .HasForeignKey(e => e.PropiedadId)
                      .IsRequired();
            });

            modelBuilder.Entity<PropiedadReadModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Reglas)
                      .WithOne()
                      .HasForeignKey(e => e.PropiedadId)
                      .IsRequired();
            });

        }
    }
}
