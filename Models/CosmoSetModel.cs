using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class CosmoSetModel
    {
        public CosmoSetModel()
        {

        }

        public int Id { get; set; }
        public int SolarId { get; set; }
        public int LunarId { get; set; }
        public int StarId { get; set; }
        public int LegendaryId { get; set; }
        public int SaintId { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public virtual SaintModel Saint { get; set; }
        [NotMapped]
        public virtual CosmoModel Solar { get; set; }
        [NotMapped]
        public virtual CosmoModel Lunar { get; set; }
        [NotMapped]
        public virtual CosmoModel Star { get; set; }
        [NotMapped]
        public virtual CosmoModel Legendary { get; set; }
    }
}
