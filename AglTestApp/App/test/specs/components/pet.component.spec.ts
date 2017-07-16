import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {
    BrowserDynamicTestingModule,
    platformBrowserDynamicTesting
} from '@angular/platform-browser-dynamic/testing';
import {
    TestBed,
    getTestBed,
    async,
    inject,
    ComponentFixture
} from '@angular/core/testing';

import { PetComponent } from '../../../components/pet/pet.component';
import { PetDataService } from '../../../services/petdata.service';

describe('Pet Component',
    () => {


        const mockResponse ='[{"OwnerGender":"Male","PetNames":["Garfield","Tom","Max","Jim"]},{"OwnerGender":"Female","PetNames":["Garfield","Tabby","Simba"]}]';

//    //let de: DebugElement;
        let comp: PetComponent;
        let fixture: ComponentFixture<PetComponent>;

        
        class PetDataServiceMock  {
            getPetData(url: string) {
                return Observable.of(JSON.parse(mockResponse));
            }
        }
        
        beforeAll(() => {
            TestBed.resetTestEnvironment();
            TestBed.initTestEnvironment(BrowserDynamicTestingModule,
                platformBrowserDynamicTesting());
        });


        beforeEach(async(() => {


            let petDataService: PetDataServiceMock;
            petDataService = new PetDataServiceMock();
            TestBed.configureTestingModule({
                declarations: [PetComponent],
                providers: [{ provide: PetDataService, useValue: petDataService }]
            });


            TestBed.compileComponents().then(() => {
                    fixture = TestBed.createComponent(PetComponent);
                    fixture.detectChanges();
                    comp = fixture.componentInstance;
                }).catch(() => {
                console.log("Pet components compilation failed");
            });

        }));

        it('Pet Component should be defined',
            () => {
                expect(comp).toBeDefined();
            });

        it('Pet Component should have 2 items in the owner array',
            () => {
                
                expect(comp.owners.length).toBe(2);
            });

        it('Pet Component should have 4 items in the owners Male array',
            () => {
                
                expect(comp.owners[0].PetNames.length).toBe(4);
            });

        it('Pet Component Male section should have garfield as the first item  in the owners Male array',
            () => {
                
                expect(comp.owners[0].PetNames[0]).toEqual('Garfield');
            });

        it('Pet Component Male section should have Tom as the first item  in the owners Male array after calling toggle for desc sort',
            () => {

                comp.toggleSort();
                expect(comp.owners[0].PetNames[0]).toEqual('Tom');
            });

        it('Pet Component Male section should have garfield as the first item  in the owners Male array when toggle sort is clicked twice (back to asc)',
            () => {
                comp.toggleSort();
                expect(comp.owners[0].PetNames[0]).toEqual('Tom');
                comp.toggleSort();
                expect(comp.owners[0].PetNames[0]).toEqual('Garfield');
            });


    });