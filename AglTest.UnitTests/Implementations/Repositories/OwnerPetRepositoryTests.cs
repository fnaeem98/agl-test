using Microsoft.VisualStudio.TestTools.UnitTesting;
using AglTest.Framework.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using AglTest.Framework.Models.BackendModel;

namespace AglTest.Framework.Implementations.Repositories.Tests
{
    [TestClass()]
    public class OwnerPetRepositoryTests
    {


        [TestInitialize]
        public void Initialize()
        {
            


        }



        [TestMethod()]
        public void GetPetOwnerByPetTypeAsync_call_should_return_list_of_6()
        {
            OwnerPetRepository ownerPetRepository = new OwnerPetRepository();
            List<PetsOwner> list = new List<PetsOwner>();
            int actual = 0;
            
            if (ownerPetRepository.IsMockData() == false)
            {
                list = ownerPetRepository.GetPetOwnerByPetTypeAsync("Cat").Result;
                actual = 5;

            }
            Assert.AreEqual(list.Count,actual);

        }



    }
}