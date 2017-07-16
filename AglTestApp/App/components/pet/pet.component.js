"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var _ = require("lodash");
var petdata_service_1 = require("../../services/petdata.service");
var PetComponent = (function () {
    function PetComponent(petDataService) {
        this.petDataService = petDataService;
        this.url = "";
        this.sort = "asc";
    }
    PetComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.url = "/api/pet/get-pet-names-owner-gender-pet-type?petType=" + this.petType;
        this.petDataService.getPetData(this.url)
            .subscribe(function (owners) {
            _this.owners = owners;
            _.each(_this.owners, function (owner) {
                owner.PetNames = _.orderBy(owner.PetNames, [], ['asc']);
            });
        }, function (error) { console.log(error); });
    };
    PetComponent.prototype.toggleSort = function () {
        if (this.sort === 'asc') {
            _.each(this.owners, function (owner) {
                owner.PetNames = _.orderBy(owner.PetNames, [], ['desc']);
            });
            this.sort = 'desc';
        }
        else {
            _.each(this.owners, function (owner) {
                owner.PetNames = _.orderBy(owner.PetNames, [], ['asc']);
            });
            this.sort = 'asc';
        }
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], PetComponent.prototype, "petType", void 0);
    PetComponent = __decorate([
        core_1.Component({
            selector: 'pet',
            templateUrl: 'app/components/pet/pet.component.html'
        }),
        __metadata("design:paramtypes", [petdata_service_1.PetDataService])
    ], PetComponent);
    return PetComponent;
}());
exports.PetComponent = PetComponent;
//# sourceMappingURL=pet.component.js.map