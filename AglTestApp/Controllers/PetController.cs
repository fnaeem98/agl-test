using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AglTest.Framework.Models.UIModel;
using AglTest.Framework.Interfaces.Services;
using System.Threading.Tasks;
using AglTest.Framework.Logging;

namespace AglTest.App.Controllers
{
    [RoutePrefix("api/pet")]
    public class PetController : ApiController
    {
        private readonly IOwnerPetService _ownerPetService;

        public PetController()
        {
            

        }


        public PetController(IOwnerPetService ownerPetService)
        {
            _ownerPetService = ownerPetService;
        }

        [Route("get-pet-names-owner-gender-pet-type")]
        [HttpGet]
        public async Task<List<OwnerGenderPets>> GetPetNamesByOwnerGenderAndPetType(string petType)
        {
            try
            {
                return await _ownerPetService.GetOwnerPetsByPetTypeAsync(petType);
            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "", null);
                throw ex;
            }

            
            

        }

    }
}