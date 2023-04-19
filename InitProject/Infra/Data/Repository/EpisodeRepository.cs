using InitProject.Data.Context;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Repository;

public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
{        
    public EpisodeRepository(DbPgContext context) : base(context) { }
}
