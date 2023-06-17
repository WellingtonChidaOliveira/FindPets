using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPets.Shared.Pets
{
    public class SearchPet
    {

        public string Search { get; set; } = string.Empty;
        public bool Type { get; set; }
        public bool Status { get; set; }
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 5;

        public SearchPet(string search, bool type, bool status, int page, int take)
        {
            Search = search;
            Type = type;
            Status = status;
            Page = page;
            Take = take;
        }

        public SearchPet()
        {
    
        }

       
    }
}
