using InitProject.Data.Context;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Repository;

public class AnimeRepository : RepositoryBase<Anime>, IAnimeRepository
{        
    public AnimeRepository(DbPgContext context) : base(context) { }
}
