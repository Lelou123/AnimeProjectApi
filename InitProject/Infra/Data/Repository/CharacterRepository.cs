﻿using InitProject.Data.Context;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Repository;

public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
{
    public CharacterRepository(DbPgContext context) : base(context) { }
    
}
