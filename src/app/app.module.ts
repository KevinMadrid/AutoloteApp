import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarrosComponent } from './features/carros/carros.component';
import { InicioComponent } from './features/inicio/inicio.component';
import { CrearCarroComponent } from './features/crear-carro/crear-carro.component';
import { EditarCarroComponent } from './features/editar-carro/editar-carro.component';
import { PaginaNoSeEncuentraComponent } from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';
import { NavegacionComponent } from './features/navegacion/navegacion.component';
import { DetallesCarroComponent } from './features/detalles-carro/detalles-carro.component';


@NgModule({
  declarations: [
    AppComponent,
    CarrosComponent,
    InicioComponent,
    CrearCarroComponent,
    EditarCarroComponent,
    PaginaNoSeEncuentraComponent,
    NavegacionComponent,
    DetallesCarroComponent,
 
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
