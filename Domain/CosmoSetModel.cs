using Domain.Models.Validations;
using Newtonsoft.Json;
using NikCore;
using NikCore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CosmoSetModel : BaseModel
    {
        public CosmoSetModel(int SolarId, int LunarId, int StarId, int LegendaryId, int SaintId, string Description)
        {
            this.SolarId = SolarId;
            this.LunarId = LunarId;
            this.StarId = StarId;
            this.LegendaryId = LegendaryId;
            this.SaintId = SaintId;
            this.Description = Description;
        }

        public int Id { get; set; }
        public int SolarId { get; set; }
        public int LunarId { get; set; }
        public int StarId { get; set; }
        public int LegendaryId { get; set; }
        public int SaintId { get; set; }
        public string Description { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual SaintModel Saint { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CosmoModel Solar { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CosmoModel Lunar { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CosmoModel Star { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CosmoModel Legendary { get; set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new CosmoSetValidator(), errorContext);
        }
    }
}
