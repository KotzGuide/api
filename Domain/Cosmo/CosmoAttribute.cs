using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    [NotMapped]
    public class CosmoAttribute
    {
        public double Value { get; set; }
        public CosmoAttributeType Type{ get; set; }
        public bool IsPercentage { get; set; }
    }
}
