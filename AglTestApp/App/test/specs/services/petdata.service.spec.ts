import {
    BrowserDynamicTestingModule,
    platformBrowserDynamicTesting
} from '@angular/platform-browser-dynamic/testing';
import {
    TestBed,
    getTestBed,
    async,
    inject,
} from '@angular/core/testing';
import {
    Headers, BaseRequestOptions,
    Response, HttpModule, Http, XHRBackend, RequestMethod
} from '@angular/http';

import { ResponseOptions } from '@angular/http';
import { MockBackend, MockConnection } from '@angular/http/testing';




import {PetDataService} from '../../../services/petdata.service';

const mockResponse =
[
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

describe('Pet Data service',
    () => {

        let mockBackend: MockBackend;

        beforeAll(() => {
            TestBed.resetTestEnvironment();
            TestBed.initTestEnvironment(BrowserDynamicTestingModule,
                platformBrowserDynamicTesting());
        });


        beforeEach(async(() => {
            TestBed.configureTestingModule({
                providers: [
                    PetDataService,
                    MockBackend,
                    BaseRequestOptions,
                    {
                        provide: Http,
                        deps: [MockBackend, BaseRequestOptions],
                        useFactory:
                            (backend: XHRBackend, defaultOptions: BaseRequestOptions) => {
                                return new Http(backend, defaultOptions);
                            }
                    }
                ],
                imports: [
                    HttpModule
                ]
            });
            mockBackend = getTestBed().get(MockBackend);
        }));


        it('Pet Data Service should be defined',
            inject([PetDataService],
                (petDataService: PetDataService) => {

                    expect(petDataService).toBeDefined();

                }));

        it('should get pet results for cat', 
            inject([
                PetDataService
            ], (petDataService:PetDataService) => {

                const expectedUrl = '/api/pet/get-pet-names-owner-gender-pet-type?petType=Cat';

                mockBackend.connections.subscribe(
                    (connection:MockConnection) => {
                        expect(connection.request.method).toBe(RequestMethod.Get);
                        expect(connection.request.url).toBe(expectedUrl);

                        connection.mockRespond(new Response(
                            new ResponseOptions({ body: mockResponse })
                        ));
                    });

                petDataService.getPetData(expectedUrl)
                    .subscribe(res => {
                        expect(res).toEqual(mockResponse);
                    });

            })
        );


    });