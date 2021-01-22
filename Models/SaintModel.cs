using Api.Core;
using Api.Core.Models;
using Api.Enums;
using Api.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class SaintModel : BaseModel
    {
        public SaintModel(string name, string description, Rank rank)
        {
            name = Name;
            description = Description;
            rank = Rank;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Rank Rank { get; private set; }
        public int RecommendedCosmoSetId { get; private set; }
        [NotMapped]
        public virtual CosmoSetModel RecommendedCosmoSet { get; set; }
        [NotMapped]
        public virtual ICollection<CosmoSetModel> CosmoSets { get; set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new SaintValidator(), errorContext);
        }
    }
}
