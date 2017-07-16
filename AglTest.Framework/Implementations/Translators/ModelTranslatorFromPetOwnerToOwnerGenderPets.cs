using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Interfaces.Translators;
using AglTest.Framework.Models.BackendModel;
using AglTest.Framework.Models.UIModel;
using AglTest.Framework.Helpers;
using AglTest.Framework.Logging;

namespace AglTest.Framework.Implementations.Translators
{
    public class ModelTranslatorFromPetOwnerToOwnerGenderPets : IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>
    {
        public List<OwnerGenderPets> Translate(List<PetsOwner> inputModel)
        {
            try
            {
                List<OwnerGenderPets> outputModel = new List<OwnerGenderPets>();
                TranslateByGenderType(inputModel, outputModel);

                return outputModel;

            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "", null);
                throw ex;
            }


        }


        private void TranslateByGenderType(List<PetsOwner> inputModel, List<OwnerGenderPets> outputModel)
        {
            try
            {
                var maleList = new OwnerGenderPets();
                var femaleList = new OwnerGenderPets();
                maleList.OwnerGender = Constants.Gender.Male;
                femaleList.OwnerGender = Constants.Gender.Female;

                inputModel.RemoveAll(
                    po =>
                        po.gender.ToUpper() != Constants.Gender.Male.ToUpper() &&
                        po.gender.ToUpper() != Constants.Gender.Female.ToUpper());

                foreach (var item in inputModel)
                {
                    item.pets.RemoveAll(p => string.IsNullOrEmpty(p.name));

                    if (item.gender.ToUpper() == Constants.Gender.Male.ToUpper())
                    {
                        maleList.PetNames.AddRange(item.pets.Select(x => x.name).ToList());
                    }
                    else if (item.gender.ToUpper() == Constants.Gender.Female.ToUpper())
                    {
                        femaleList.PetNames.AddRange(item.pets.Select(x => x.name).ToList());
                    }

                }

                outputModel.Add(maleList);
                outputModel.Add(femaleList);

            }
            catch (Exception ex)
            {
                AglLogger.AddErrorLog(ex, "", null);
                throw ex;
            }


        }


    }
}
