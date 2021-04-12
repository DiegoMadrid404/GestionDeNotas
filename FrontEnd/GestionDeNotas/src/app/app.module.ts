import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GesionNotasComponent } from './Components/gesion-notas/gesion-notas.component';
import { NotasComponent } from './Components/gesion-notas/notas/notas.component';
import { ListaComponent } from './Components/gesion-notas/lista/lista.component';
import { FooterComponent } from './Components/footer/footer.component';
import { PromedioNotasListComponent } from './Components/gesion-notas/promedio-notas-list/promedio-notas-list.component';
import {MatSliderModule } from '@angular/material/slider';
import {MatSelectModule} from '@angular/material/select'; 

@NgModule({
  declarations: [
    AppComponent,
    GesionNotasComponent,
    NotasComponent,
    ListaComponent,
    FooterComponent,
    PromedioNotasListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatSliderModule,
    MatSelectModule, 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
