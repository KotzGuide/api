using Domain.Models;

namespace Data.Dtos.Cosmo
{
    public class InsertCosmoSetDto
    {
        public int SaintId { get; set; }
        public int SolarCosmoId { get; set; }
        public int LunarCosmoId { get; set; }
        public int StarCosmoId { get; set; }
        public int LegendaryCosmoId { get; set; }
        public string Description{ get; set; }

        public CosmoSetModel ToModel() => new CosmoSetModel(SolarCosmoId,LunarCosmoId,StarCosmoId,LegendaryCosmoId,SaintId,Description);
    }
}
