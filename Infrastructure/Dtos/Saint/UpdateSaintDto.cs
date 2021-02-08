using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos.Saint
{
    public class UpdateSaintDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Constellation { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
}
