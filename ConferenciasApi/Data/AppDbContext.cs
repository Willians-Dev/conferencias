using ConferenciasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Conferencia> Conferencias => Set<Conferencia>();
    public DbSet<Asistente> Asistentes => Set<Asistente>();
    public DbSet<Registro> Registros => Set<Registro>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conferencia>().ToTable("conferencias");
        modelBuilder.Entity<Asistente>().ToTable("asistentes");
        modelBuilder.Entity<Registro>().ToTable("registros");

        modelBuilder.Entity<Conferencia>()
            .Property(c => c.ConferenciaId)
            .HasColumnName("conferencia_id");

        modelBuilder.Entity<Asistente>()
            .Property(a => a.AsistenteId)
            .HasColumnName("asistente_id");

        modelBuilder.Entity<Registro>()
            .Property(r => r.RegistroId)
            .HasColumnName("registro_id");
    }
}