using Api.Core;
using Api.Core.Models;
using Api.Enums;
using Api.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class CosmoModel : BaseModel
    {
        public CosmoModel(string name, string description, Rank rank, CosmoType cosmoType)
        {
            Name = name;
            Description = description;
            Rank = rank;
            CosmoType = cosmoType;
        }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Rank Rank { get; private set; }
        public CosmoType CosmoType { get; private set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new CosmoValidator(), errorContext);
        }
    }
}
