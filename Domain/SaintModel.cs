using Domain.Enums;
using Domain.Models.Validations;
using Newtonsoft.Json;
using NikCore;
using NikCore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SaintModel : BaseModel
    {
        public SaintModel(string Name, string Description, string Constellation, Rank Rank)
        {
            this.Name = Name;
            this.Description = Description;
            this.Constellation = Constellation;
            this.Rank = Rank;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Constellation { get; private set; }
        public string Description { get; private set; }
        public Rank Rank { get; private set; }
        public int RecommendedCosmoSetId { get; private set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CosmoSetModel RecommendedCosmoSet { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<CosmoSetModel> CosmoSets { get; set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new SaintValidator(), errorContext);
        }
    }
}
