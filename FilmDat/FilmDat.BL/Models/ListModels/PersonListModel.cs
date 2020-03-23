using System;

namespace FilmDat.BL.Models.ListModels
{
    public class PersonListModel : BaseModel
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
