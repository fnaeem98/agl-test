using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglTest.Framework.Models.BackendModel
{
    public class PetsOwner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<PetDetail> pets { get; set; }

        public PetsOwner()
        {
            pets = new List<PetDetail>();
        }
    }
}
