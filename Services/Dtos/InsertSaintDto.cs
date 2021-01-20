using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Dtos
{
    public class InsertSaintDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }

        public SaintModel ToModel() => new SaintModel(Name, Description, (Rank)Rank);
    }
}
