"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/platform-browser-dynamic/testing");
var testing_2 = require("@angular/core/testing");
var http_1 = require("@angular/http");
var http_2 = require("@angular/http");
var testing_3 = require("@angular/http/testing");
var petdata_service_1 = require("../../../services/petdata.service");
var mockResponse = [
    {
        "name": "Bob",
        "gender": "Male",
        "age": 23,
        "pets": [{ "name": "Garfield", "type": "Cat" }, { "name": "Fido", "type": "Dog" }]
    }, { "name": "Jennifer", "gender": "Female", "age": 18, "pets": [{ "name": "Garfield", "type": "Cat" }] },
    { "name": "Steve", "gender": "Male", "age": 45, "pets": [] },
    {
        "name": "Fred",
        "gender": "Male",
        "age": 40,
        "pets": [
            { "name": "Tom", "type": "Cat" }, { "name": "Max", "type": "Cat" }, { "name": "Sam", "type": "Dog" },
            { "name": "Jim", "type": "Cat" }
        ]
    }, { "name": "Samantha", "gender": "Female", "age": 40, "pets": [{ "name": "Tabby", "type": "Cat" }] },
    {
        "name": "Alice",
        "gender": "Female",
        "age": 64,
        "pets": [{ "name": "Simba", "type": "Cat" }, { "name": "Nemo", "type": "Fish" }]
    }
];
describe('Pet Data service', function () {
    var mockBackend;
    beforeAll(function () {
        testing_2.TestBed.resetTestEnvironment();
        testing_2.TestBed.initTestEnvironment(testing_1.BrowserDynamicTestingModule, testing_1.platformBrowserDynamicTesting());
    });
    beforeEach(testing_2.async(function () {
        testing_2.TestBed.configureTestingModule({
            providers: [
                petdata_service_1.PetDataService,
                testing_3.MockBackend,
                http_1.BaseRequestOptions,
                {
                    provide: http_1.Http,
                    deps: [testing_3.MockBackend, http_1.BaseRequestOptions],
                    useFactory: function (backend, defaultOptions) {
                        return new http_1.Http(backend, defaultOptions);
                    }
                }
            ],
            imports: [
                http_1.HttpModule
            ]
        });
        mockBackend = testing_2.getTestBed().get(testing_3.MockBackend);
    }));
    it('Pet Data Service should be defined', testing_2.inject([petdata_service_1.PetDataService], function (petDataService) {
        expect(petDataService).toBeDefined();
    }));
    it('should get pet results for cat', testing_2.inject([
        petdata_service_1.PetDataService
    ], function (petDataService) {
        var expectedUrl = '/api/pet/get-pet-names-owner-gender-pet-type?petType=Cat';
        mockBackend.connections.subscribe(function (connection) {
            expect(connection.request.method).toBe(http_1.RequestMethod.Get);
            expect(connection.request.url).toBe(expectedUrl);
            connection.mockRespond(new http_1.Response(new http_2.ResponseOptions({ body: mockResponse })));
        });
        petDataService.getPetData(expectedUrl)
            .subscribe(function (res) {
            expect(res).toEqual(mockResponse);
        });
    }));
});
//# sourceMappingURL=petdata.service.spec.js.map