using InitProject.Data.Context;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Repository;

public class EstudioRepository : RepositoryBase<Estudio>, IEstudioRepository
{
    public EstudioRepository(DbPgContext context) : base(context) { }
}
