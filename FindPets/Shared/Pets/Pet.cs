using FindPets.Shared.ClassBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FindPets.Shared.Enum;

namespace FindPets.Shared.Pets
{
    public class Pet : IDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Campo obrigatório.")]
        public EnumTypeSearch AdType { get; set; } = EnumTypeSearch.Todos;
        public byte[]? Photo { get; set; }
        [NotMapped]
        public string PhotoExtension { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ClosedAt { get; set; }
        public bool Status { get; set; } = false;

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Location))
            {
                return false;
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return false;
            }

            return true;
        }
    }
}
