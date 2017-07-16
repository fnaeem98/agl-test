import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class PetDataService {
    constructor(private http: Http) {
        
    }

    getPetData(url: string): Observable<any> {
        return this.http.get(url)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.log("error in getPetData call");
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}