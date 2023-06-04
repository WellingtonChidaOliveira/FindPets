﻿using FindPets.Shared.ClassBase;

namespace FindPets.Shared
{
    public class User : IDocument
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty; 
    }
}
