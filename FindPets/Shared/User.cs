using FindPets.Shared.ClassBase;

namespace FindPets.Shared
{
    public class User : IDocument
    {
        public string Id { get ; set ; }
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty; 
    }
}
