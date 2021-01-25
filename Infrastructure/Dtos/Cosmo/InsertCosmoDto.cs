using Domain.Enums;
using Domain.Models;

namespace Data.Dtos.Cosmo
{
    public class InsertCosmoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Rank Rank { get; set; }
        public CosmoType CosmoType { get; set; }
        public CosmoAttribute FirstAttribute { get; set; }
        public CosmoAttribute SecondAttribute { get; set; }


        public CosmoModel ToModel() => new CosmoModel(Name, Description, FirstAttribute, SecondAttribute, Rank, CosmoType);
    }
}
