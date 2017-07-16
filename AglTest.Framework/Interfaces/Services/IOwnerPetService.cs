using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Models.UIModel;


namespace AglTest.Framework.Interfaces.Services
{
    public interface IOwnerPetService
    {
        Task<List<OwnerGenderPets>> GetOwnerPetsByPetTypeAsync(string petType);
    }
}
