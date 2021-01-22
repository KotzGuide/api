using Api.Enums;
using Api.Models;

namespace Api.Services.Dtos.Saint
{
    public class InsertSaintDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }

        public SaintModel ToModel() => new SaintModel(Name, Description, (Rank)Rank);
    }
}
