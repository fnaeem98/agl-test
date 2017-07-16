"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/observable/of");
var testing_1 = require("@angular/platform-browser-dynamic/testing");
var testing_2 = require("@angular/core/testing");
var pet_component_1 = require("../../../components/pet/pet.component");
var petdata_service_1 = require("../../../services/petdata.service");
describe('Pet Component', function () {
    var mockResponse = '[{"OwnerGender":"Male","PetNames":["Garfield","Tom","Max","Jim"]},{"OwnerGender":"Female","PetNames":["Garfield","Tabby","Simba"]}]';
    //    //let de: DebugElement;
    var comp;
    var fixture;
    var PetDataServiceMock = (function () {
        function PetDataServiceMock() {
        }
        PetDataServiceMock.prototype.getPetData = function (url) {
            return Observable_1.Observable.of(JSON.parse(mockResponse));
        };
        return PetDataServiceMock;
    }());
    beforeAll(function () {
        testing_2.TestBed.resetTestEnvironment();
        testing_2.TestBed.initTestEnvironment(testing_1.BrowserDynamicTestingModule, testing_1.platformBrowserDynamicTesting());
    });
    beforeEach(testing_2.async(function () {
        var petDataService;
        petDataService = new PetDataServiceMock();
        testing_2.TestBed.configureTestingModule({
            declarations: [pet_component_1.PetComponent],
            providers: [{ provide: petdata_service_1.PetDataService, useValue: petDataService }]
        });
        testing_2.TestBed.compileComponents().then(function () {
            fixture = testing_2.TestBed.createComponent(pet_component_1.PetComponent);
            fixture.detectChanges();
            comp = fixture.componentInstance;
        }).catch(function () {
            console.log("Pet components compilation failed");
        });
    }));
    it('Pet Component should be defined', function () {
        expect(comp).toBeDefined();
    });
    it('Pet Component should have 2 items in the owner array', function () {
        expect(comp.owners.length).toBe(2);
    });
    it('Pet Component should have 4 items in the owners Male array', function () {
        expect(comp.owners[0].PetNames.length).toBe(4);
    });
    it('Pet Component Male section should have garfield as the first item  in the owners Male array', function () {
        expect(comp.owners[0].PetNames[0]).toEqual('Garfield');
    });
    it('Pet Component Male section should have Tom as the first item  in the owners Male array after calling toggle for desc sort', function () {
        comp.toggleSort();
        expect(comp.owners[0].PetNames[0]).toEqual('Tom');
    });
    it('Pet Component Male section should have garfield as the first item  in the owners Male array when toggle sort is clicked twice (back to asc)', function () {
        comp.toggleSort();
        expect(comp.owners[0].PetNames[0]).toEqual('Tom');
        comp.toggleSort();
        expect(comp.owners[0].PetNames[0]).toEqual('Garfield');
    });
});
//# sourceMappingURL=pet.component.spec.js.map