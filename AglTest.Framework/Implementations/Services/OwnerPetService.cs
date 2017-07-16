using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Interfaces.Services;
using AglTest.Framework.Models.UIModel;
using AglTest.Framework.Interfaces.Repositories;
using AglTest.Framework.Interfaces.Translators;
using AglTest.Framework.Logging;
using AglTest.Framework.Models.BackendModel;

namespace AglTest.Framework.Implementations.Services
{
    public class OwnerPetService : IOwnerPetService
    {
        private readonly IOwnerPetRepository _ownerRepository;
        private readonly IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>> _modelTranslator;

        public OwnerPetService(IOwnerPetRepository ownerRepository,
            IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>> modelTranslator)
        {
            _ownerRepository = ownerRepository;
            _modelTranslator = modelTranslator;

        }

        public async Task<List<OwnerGenderPets>> GetOwnerPetsByPetTypeAsync(string petType)
        {

            try
            {
                var petTypeData = await _ownerRepository.GetPetOwnerByPetTypeAsync(petType).ConfigureAwait(false);
                return _modelTranslator.Translate(petTypeData);

            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "petType:" + petType, null);
                throw ex;
            }



        }
    }
}
