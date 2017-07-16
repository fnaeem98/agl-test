using Microsoft.VisualStudio.TestTools.UnitTesting;
using AglTest.Framework.Implementations.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Models.UIModel;
using AglTest.Framework.Models.BackendModel;
using Moq;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;


namespace AglTest.Framework.Implementations.Translators.Tests
{
    [TestClass()]
    public class ModelTranslatorFromPetOwnerToOwnerGenderPetsTests
    {
        [TestMethod()]
        public void Translate_Response_Not_Null_Test()
        {

            var jsonString = GetTestJsonString();
            var inputModel = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);

            ModelTranslatorFromPetOwnerToOwnerGenderPets translator=new ModelTranslatorFromPetOwnerToOwnerGenderPets();

            var response = translator.Translate(inputModel);

            Assert.IsNotNull(response);


        }

        [TestMethod()]
        public void Translate_Response_Length_Is_2_Test()
        {

            var jsonString = GetTestJsonString();
            var inputModel = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);

            ModelTranslatorFromPetOwnerToOwnerGenderPets translator = new ModelTranslatorFromPetOwnerToOwnerGenderPets();

            var response = translator.Translate(inputModel);

            Assert.AreEqual(response.Count, 2);

        }

        [TestMethod()]
        public void Should_have_6_PetNames_In_Male()
        {

            var jsonString = GetTestJsonString();
            var inputModel = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);

            ModelTranslatorFromPetOwnerToOwnerGenderPets translator = new ModelTranslatorFromPetOwnerToOwnerGenderPets();

            var response = translator.Translate(inputModel);

            var petNamesCount = response.Where(o => o.OwnerGender.ToUpper() == "MALE").SingleOrDefault().PetNames.Count;

            Assert.AreEqual(petNamesCount, 6);

        }

        [TestMethod()]
        public void Should_have_4_PetNames_In_Female()
        {

            var jsonString = GetTestJsonString();
            var inputModel = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);

            ModelTranslatorFromPetOwnerToOwnerGenderPets translator = new ModelTranslatorFromPetOwnerToOwnerGenderPets();

            var response = translator.Translate(inputModel);

            var petNamesCount = response.Where(o => o.OwnerGender.ToUpper() == "FEMALE").SingleOrDefault().PetNames.Count;

            Assert.AreEqual(petNamesCount, 4);

        }



        private string GetTestJsonString()
        {
            var str = @"[
    {
        'name': 'Bob',
        'gender': 'Male',
        'age': 23,
        'pets': [
            {
                'name': 'Garfield',
                'type': 'Cat'
            },
            {
                'name': 'Fido',
                'type': 'Dog'
            }
        ]
    },
    {
        'name': 'Jennifer',
        'gender': 'Female',
        'age': 18,
        'pets': [
            {
                'name': 'Garfield',
                'type': 'Cat'
            }
        ]
    },
    {
        'name': 'Fred',
        'gender': 'Male',
        'age': 40,
        'pets': [
            {
                'name': 'Tom',
                'type': 'Cat'
            },
            {
                'name': 'Max',
                'type': 'Cat'
            },
            {
                'name': 'Sam',
                'type': 'Dog'
            },
            {
                'name': 'Jim',
                'type': 'Cat'
            }
        ]
    },
    {
        'name': 'Samantha',
        'gender': 'Female',
        'age': 40,
        'pets': [
            {
                'name': 'Tabby',
                'type': 'Cat'
            }
        ]
    },
    {
        'name': 'Alice',
        'gender': 'Female',
        'age': 64,
        'pets': [
            {
                'name': 'Simba',
                'type': 'Cat'
            },
            {
                'name': 'Nemo',
                'type': 'Fish'
            }
        ]
    }
]";

            return str;
        }
    }
}