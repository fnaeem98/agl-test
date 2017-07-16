import { Component, OnInit, Input } from '@angular/core';
import * as _ from "lodash";
import { PetDataService } from '../../services/petdata.service';


@Component({
    selector: 'pet',
    templateUrl: 'app/components/pet/pet.component.html'
})

export class PetComponent implements OnInit {

    @Input() petType:string;

    owners:any[];

    url:string = "";

    sort:string="asc";
    constructor(private petDataService:PetDataService) {

    }

    ngOnInit() {
        this.url = "/api/pet/get-pet-names-owner-gender-pet-type?petType="+this.petType;

        this.petDataService.getPetData(this.url)
            .subscribe(owners => {
                this.owners = owners;
                _.each(this.owners,
                        owner => {
                            owner.PetNames=_.orderBy(owner.PetNames,[],['asc']);
                        });
                },
            error=> { console.log(error); });
    }

    toggleSort():void {

        if (this.sort === 'asc') {
            _.each(this.owners,
                owner => {
                    owner.PetNames = _.orderBy(owner.PetNames, [], ['desc']);
                });
            this.sort = 'desc';
        } else {
            _.each(this.owners,
                owner => {
                    owner.PetNames = _.orderBy(owner.PetNames, [], ['asc']);
                });
            this.sort = 'asc';

        }
    }
}