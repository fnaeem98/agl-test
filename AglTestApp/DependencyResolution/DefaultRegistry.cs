// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using StructureMap;
using AglTest.Framework.Interfaces.Services;
using AglTest.Framework.Interfaces.Repositories;
using AglTest.Framework.Interfaces.Translators;
using AglTest.Framework.Implementations.Services;
using AglTest.Framework.Implementations.Repositories;
using AglTest.Framework.Implementations.Translators;
using AglTest.Framework.Models.BackendModel;
using AglTest.Framework.Models.UIModel;

namespace AglTest.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IExample>().Use<Example>();
            For<IOwnerPetService>().Use<OwnerPetService>();
            For<IOwnerPetRepository>().Use<OwnerPetRepository>();
            For<IModelTranslator<List<PetsOwner>, List<OwnerGenderPets>>>().Use<ModelTranslatorFromPetOwnerToOwnerGenderPets>();

        }

        #endregion
    }
}