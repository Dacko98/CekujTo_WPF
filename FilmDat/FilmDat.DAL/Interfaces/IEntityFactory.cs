using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.DAL.Interfaces
{
     public interface IEntityFactory
    {
        TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new();
    }
}
