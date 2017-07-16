using Microsoft.VisualStudio.TestTools.UnitTesting;
using AglTest.Framework.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AglTest.Framework.Interfaces.Services;
using AglTest.Framework.Models.UIModel;
using AglTest.Framework.Interfaces.Repositories;
using AglTest.Framework.Interfaces.Translators;
using AglTest.Framework.Models.BackendModel;
using Moq;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AglTest.Framework.Implementations.Services.Tests
{
    [TestClass()]
    public class OwnerPetServiceTests
    {
        private OwnerPetService _ownerPetService;



        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod()]
        public void GetOwnerPetsByPetTypeAsyncTest_Response_IsNotNull()
        {

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var petRepoMock = fixture.Freeze<Mock<IOwnerPetRepository>>();
            var translatorMock = fixture.Freeze<Mock<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>>();

            var jsonString = GetTestJsonString();

            var inputModel = fixture.Create<List<PetsOwner>>();

            var translatorOutputModel = fixture.Create<List<OwnerGenderPets>>();

            petRepoMock.Setup(pr => pr.GetPetOwnerByPetTypeAsync("Cat")).Returns(MockRepoOutputData(jsonString));

            translatorMock.Setup(tr => tr.Translate(inputModel)).Returns(translatorOutputModel);

            _ownerPetService = new OwnerPetService(petRepoMock.Object, translatorMock.Object);


            var response = _ownerPetService.GetOwnerPetsByPetTypeAsync("Cat").Result;

            Assert.IsNotNull(response);

        }


        [TestMethod()]
        public void Pet_Repo_Function_Is_Called()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var petRepoMock = fixture.Freeze<Mock<IOwnerPetRepository>>();
            var translatorMock = fixture.Freeze<Mock<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>>();

            var jsonString = GetTestJsonString();

            var inputModel = fixture.Create<List<PetsOwner>>();

            var translatorOutputModel = fixture.Create<List<OwnerGenderPets>>();

            petRepoMock.Setup(pr => pr.GetPetOwnerByPetTypeAsync("Cat")).Returns(MockRepoOutputData(jsonString));

            translatorMock.Setup(tr => tr.Translate(inputModel)).Returns(translatorOutputModel);

            _ownerPetService = new OwnerPetService(petRepoMock.Object, translatorMock.Object);


            var response = _ownerPetService.GetOwnerPetsByPetTypeAsync("Cat").Result;


            petRepoMock.Verify(p=>p.GetPetOwnerByPetTypeAsync(It.IsAny<string>()));

        }


        [TestMethod()]
        public void Pet_Repo_Function_Is_Called_1_Time()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var petRepoMock = fixture.Freeze<Mock<IOwnerPetRepository>>();
            var translatorMock = fixture.Freeze<Mock<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>>();

            var jsonString = GetTestJsonString();

            var inputModel = fixture.Create<List<PetsOwner>>();

            var translatorOutputModel = fixture.Create<List<OwnerGenderPets>>();

            petRepoMock.Setup(pr => pr.GetPetOwnerByPetTypeAsync("Cat")).Returns(MockRepoOutputData(jsonString));

            translatorMock.Setup(tr => tr.Translate(inputModel)).Returns(translatorOutputModel);

            _ownerPetService = new OwnerPetService(petRepoMock.Object, translatorMock.Object);


            var response = _ownerPetService.GetOwnerPetsByPetTypeAsync("Cat").Result;


            petRepoMock.Verify(p => p.GetPetOwnerByPetTypeAsync(It.IsAny<string>()),Times.Once());

        }


        [TestMethod()]
        public void Translator_Function_Is_Called()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var petRepoMock = fixture.Freeze<Mock<IOwnerPetRepository>>();
            var translatorMock = fixture.Freeze<Mock<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>>();

            var jsonString = GetTestJsonString();

            var inputModel = fixture.Create<List<PetsOwner>>();

            var translatorOutputModel = fixture.Create<List<OwnerGenderPets>>();

            petRepoMock.Setup(pr => pr.GetPetOwnerByPetTypeAsync("Cat")).Returns(MockRepoOutputData(jsonString));

            translatorMock.Setup(tr => tr.Translate(inputModel)).Returns(translatorOutputModel);

            _ownerPetService = new OwnerPetService(petRepoMock.Object, translatorMock.Object);


            var response = _ownerPetService.GetOwnerPetsByPetTypeAsync("Cat").Result;


            translatorMock.Verify(t => t.Translate(It.IsAny<List<PetsOwner>>()));

        }


        [TestMethod()]
        public void Transator_Function_Is_Called_1_Time()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var petRepoMock = fixture.Freeze<Mock<IOwnerPetRepository>>();
            var translatorMock = fixture.Freeze<Mock<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>>();

            var jsonString = GetTestJsonString();

            var inputModel = fixture.Create<List<PetsOwner>>();

            var translatorOutputModel = fixture.Create<List<OwnerGenderPets>>();

            petRepoMock.Setup(pr => pr.GetPetOwnerByPetTypeAsync("Cat")).Returns(MockRepoOutputData(jsonString));

            translatorMock.Setup(tr => tr.Translate(inputModel)).Returns(translatorOutputModel);

            _ownerPetService = new OwnerPetService(petRepoMock.Object, translatorMock.Object);


            var response = _ownerPetService.GetOwnerPetsByPetTypeAsync("Cat").Result;


            translatorMock.Verify(t => t.Translate(It.IsAny<List<PetsOwner>>()),Times.Once());

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
            }
        ]
    }
]";

            return str;
        }

        private Task<List<PetsOwner>> MockRepoOutputData(string jsonString)
        {
            var inputModel = JsonConvert.DeserializeObject<List<PetsOwner>>(jsonString);

            return Task.FromResult(inputModel);

        }
        
    }
}