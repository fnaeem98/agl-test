import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { PetComponent } from './components/pet/pet.component';
import {PetDataService} from './services/petdata.service';

@NgModule({
  imports:      [ BrowserModule,HttpModule ],
  declarations: [ AppComponent,PetComponent ],
  bootstrap: [AppComponent],
  providers:[PetDataService]
})
export class AppModule {

}
