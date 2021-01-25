using Domain.Enums;
using Domain.Models;

namespace Data.Dtos.Saint
{
    public class InsertSaintDto
    {
        public string Name { get; set; }
        public string Constellation { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }

        public SaintModel ToModel() => new SaintModel(Name, Description, Constellation, (Rank)Rank);
    }
}
