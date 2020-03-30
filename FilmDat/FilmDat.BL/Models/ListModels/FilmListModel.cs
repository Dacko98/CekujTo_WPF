using System.Collections.Generic;

namespace FilmDat.BL.Models.ListModels
{
    public class FilmListModel : BaseModel
    {
        public string OriginalName { get; set; }

        private sealed class OriginalNameEqualityComparer : IEqualityComparer<FilmListModel>
        {
            public bool Equals(FilmListModel x, FilmListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.OriginalName == y.OriginalName;
            }

            public int GetHashCode(FilmListModel obj)
            {
                return (obj.OriginalName != null ? obj.OriginalName.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<FilmListModel> OriginalNameComparer { get; } =
            new OriginalNameEqualityComparer();
    }
}