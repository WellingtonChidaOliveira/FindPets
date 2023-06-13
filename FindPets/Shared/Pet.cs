using FindPets.Shared.ClassBase;

namespace FindPets.Shared
{
    public class Pet : IDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool AdType { get; set; } = false;
        public byte[]? Photo { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; }  = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ClosedAt { get; set; }
        public bool Status { get; set; } = false;
    }
}
