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
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
var PetDataService = (function () {
    function PetDataService(http) {
        this.http = http;
    }
    PetDataService.prototype.getPetData = function (url) {
        return this.http.get(url)
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    PetDataService.prototype.handleError = function (error) {
        console.log("error in getPetData call");
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    PetDataService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], PetDataService);
    return PetDataService;
}());
exports.PetDataService = PetDataService;
//# sourceMappingURL=petdata.service.js.map