using InitProject.Data.Context;
using InitProject.Infra.Data.Repository;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Interfaces.Services;
using InitProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace InitProject;

public class Program
{
    public static void Main(string[] args)
    {        

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
        builder.Services.AddScoped<IAnimeService, AnimeService>();

        builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        builder.Services.AddScoped<IEpisodeService, EpisodeService>();

        builder.Services.AddScoped<ICharacterService, CharacterService>();
        builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

        builder.Services.AddScoped<IEstudioService, EstudioService>();
        builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();

        //builder.Services.AddDbContext<AnimeContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer
        //    (builder.Configuration.GetConnectionString("FilmeConnectionSQL")));

        builder.Services.AddDbContext<DbPgContext>(opt => opt.UseLazyLoadingProxies()
        .UseNpgsql(builder.Configuration.GetConnectionString("FilmeConnectionPG")));

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        

        builder.Services.AddControllers().AddNewtonsoftJson();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();            

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        
        var app = builder.Build();


        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

            
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();



        app.Run();
    }
}