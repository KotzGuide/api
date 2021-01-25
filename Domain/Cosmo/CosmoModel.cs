using Domain.Enums;
using Domain.Models.Validations;
using NikCore;
using NikCore.Models;

namespace Domain.Models
{
    public class CosmoModel : BaseModel
    {
        public CosmoModel()
        {

        }
        public CosmoModel(string Name, string Description, CosmoAttribute FirstAttribute, CosmoAttribute SecondAttribute, Rank Rank, CosmoType CosmoType)
        {
            this.Name = Name;
            this.Description = Description;
            this.FirstAttribute = FirstAttribute;
            this.SecondAttribute = SecondAttribute;
            this.Rank = Rank;
            this.CosmoType = CosmoType;
        }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CosmoAttribute FirstAttribute { get; private set; }
        public CosmoAttribute SecondAttribute { get; private set; }
        public Rank Rank { get; private set; }
        public CosmoType CosmoType { get; private set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new CosmoValidator(), errorContext);
        }
    }


}
