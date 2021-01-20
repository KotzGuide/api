
namespace Api.Core.Models
{
    public class PropertyField
    {
        public PropertyField(string field, string description)
        {
            Field = field;
            Description = description;
        }
        public string Field { get; private set; }
        public string Description { get; private set; }
    }
}
