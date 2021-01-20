using Api.Core;
using Api.Core.Models;
using Api.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class SaintModel : BaseModel
    {
        public SaintModel(string Name, string Description, Rank Rank)
        {
            this.Name = Name;
            this.Description = Description;
            this.Rank = Rank;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Rank Rank { get; private set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new SaintValidator(), errorContext);
        }
    }

    public enum Rank
    {
        C,
        B,
        A,
        S,
        SS,
        EX
    }
}
