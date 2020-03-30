using FilmDat.BL.Interfaces;
using FilmDat.BL.Mapper;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Factories;
using FilmDat.DAL.Repositories;

namespace FilmDat.BL.Repositories
{
    public class PersonRepository : RepositoryBase<PersonEntity, PersonListModel, PersonDetailModel>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                PersonMapper.MapToEntity,
                PersonMapper.MapToListModel,
                PersonMapper.MapToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}
