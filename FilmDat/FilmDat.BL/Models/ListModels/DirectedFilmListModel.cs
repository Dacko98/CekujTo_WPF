using System;

namespace FilmDat.BL.Models.ListModels
{
    public class DirectedFilmListModel : BaseModel
    {
        public Guid DirectorId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Guid FilmId { get; set; }
        public String OriginalName { get; set; }
    }
}
