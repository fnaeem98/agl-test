using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglTest.Framework.Models.UIModel
{
    public class OwnerGenderPets
    {
        public string OwnerGender { get; set; }
        public List<string> PetNames { get; set; }

        public OwnerGenderPets()
        {
            PetNames = new List<string>();
        }

    }
}
