using InitProject.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace InitProject.Data.Context;

public class DbPgContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Estudio> Estudios { get; set; }
    public DbSet<AnimeEstudio> AnimeEstudio { get; set; }


    public DbPgContext(DbContextOptions<DbPgContext> opts) : base(opts)
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); 
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AnimeEstudio>().HasKey(AnimeEstudio => new 
        { AnimeEstudio.AnimeId, AnimeEstudio.EstudioId });

        builder.Entity<AnimeEstudio>()
            .HasOne(x => x.Anime)
            .WithMany(x => x.AnimesEstudios)
            .HasForeignKey(x => x.AnimeId);

        builder.Entity<AnimeEstudio>()
            .HasOne(x => x.Estudio)
            .WithMany(x => x.AnimesEstudios)
            .HasForeignKey(x => x.EstudioId);

        builder.Entity<Anime>()
            .HasOne(endereco => endereco.Episode)
            .WithOne(cinema => cinema.Anime)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
