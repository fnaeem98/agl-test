using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Interfaces.Repositories;
using AglTest.Framework.Models.BackendModel;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AglTest.Framework.Logging;

namespace AglTest.Framework.Implementations.Repositories
{
    public class OwnerPetRepository : IOwnerPetRepository
    {

        public async Task<List<PetsOwner>> GetPetOwnerByPetTypeAsync(string petType)
        {
            try
            {
                var petOwnersList = new List<PetsOwner>();

                if (!IsMockData())
                {
                    petOwnersList = await GetPetOwnerUsingPetTypeAsync(petType).ConfigureAwait(false);
                }
                else
                {
                    // implement getting mock data here.

                }

                return petOwnersList;

            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "petType:" + petType, null);
                throw ex;
                
            }


        }

        public bool IsMockData()
        {
            bool returnVal = false;
            string mockConfig = ConfigurationManager.AppSettings["mock"];
            if (mockConfig.ToUpper() == "Y")
            {
                returnVal = true;
            }

            return returnVal;
        }

        private async Task<List<PetsOwner>> GetPetOwnerUsingPetTypeAsync(string petType)
        {
            List<PetsOwner> petOwnersList = null;

            try
            {
                using (HttpClient webClient = new HttpClient())
                {
                    webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Uri dataUrl = new Uri(ConfigurationManager.AppSettings["url"]);

                    HttpResponseMessage response = await webClient.GetAsync(dataUrl, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {

                        var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        petOwnersList = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);
                        petOwnersList.RemoveAll(po => po.pets == null);
                        foreach (var owner in petOwnersList)
                        {
                            owner.pets?.RemoveAll(pd => pd.type.ToUpper() != petType.ToUpper());
                        }

                    }
                    else
                    {
                        AglLogger.AddWarningLog(null, "url failed:" + ConfigurationManager.AppSettings["url"], null);
                    }
                    
                }

                return petOwnersList;

            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "petType:"+petType, null);
                throw ex;
                
            }


        }
    }
}
