using Api.Enums;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Dtos.Cosmo
{
    public class InsertCosmoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Rank Rank { get; set; }
        public CosmoType CosmoType { get; set; }

        public CosmoModel ToModel() => new CosmoModel(Name, Description, Rank, CosmoType);
    }
}
