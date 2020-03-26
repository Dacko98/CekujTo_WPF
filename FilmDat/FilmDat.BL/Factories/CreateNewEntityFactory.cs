using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Factories
{
    public class CreateNewEntityFactory : IEntityFactory
    {
        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new() => new TEntity();
    }
}
