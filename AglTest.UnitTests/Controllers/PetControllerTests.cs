using Microsoft.VisualStudio.TestTools.UnitTesting;
using AglTest.App.Controllers;
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




namespace AglTest.App.Controllers.Tests
{
    [TestClass()]
    public class PetControllerTests
    {
        [TestMethod()]
        public void GetPetNamesByOwnerGenderAndPetType_Response_Is_Valid_Test()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var petOwnerServiceMock= fixture.Freeze<Mock<IOwnerPetService>>();

            petOwnerServiceMock.Setup(po => po.GetOwnerPetsByPetTypeAsync("Cat")).Returns(GetMockData());

            PetController controller = new PetController(petOwnerServiceMock.Object);


            var response = controller.GetPetNamesByOwnerGenderAndPetType("Cat");

            Assert.IsNotNull(response);


        }

        [TestMethod()]
        public void PetOwnerServiceMock_Called_1_Time()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var petOwnerServiceMock = fixture.Freeze<Mock<IOwnerPetService>>();

            petOwnerServiceMock.Setup(po => po.GetOwnerPetsByPetTypeAsync("Cat")).Returns(GetMockData());

            PetController controller = new PetController(petOwnerServiceMock.Object);


            var response = controller.GetPetNamesByOwnerGenderAndPetType("Cat");

            petOwnerServiceMock.Verify(po => po.GetOwnerPetsByPetTypeAsync("Cat"), Times.Once());

            Assert.IsNotNull(response);


        }

        private Task<List<OwnerGenderPets>> GetMockData()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockData = fixture.Create<List<OwnerGenderPets>>();

            return Task.FromResult(mockData);

        }
    }
}