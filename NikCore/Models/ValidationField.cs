namespace NikCore.Models
{
    public class PropertyField
    {
        public PropertyField(string property, string description)
        {
            Property = property;
            Description = description;
        }
        public string Property { get; private set; }
        public string Description { get; private set; }
    }
}
