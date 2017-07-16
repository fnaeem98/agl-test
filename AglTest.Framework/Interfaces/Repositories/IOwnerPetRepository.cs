using AglTest.Framework.Models.BackendModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglTest.Framework.Interfaces.Repositories
{
    public interface IOwnerPetRepository
    {
        Task<List<PetsOwner>> GetPetOwnerByPetTypeAsync(string petType);
    }
}
