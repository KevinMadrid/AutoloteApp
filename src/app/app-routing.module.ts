import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarrosComponent } from './features/carros/carros.component';
import { InicioComponent } from './features/inicio/inicio.component';
import {CrearCarroComponent} from './features/crear-carro/crear-carro.component';
import {EditarCarroComponent} from './features/editar-carro/editar-carro.component';
import {PaginaNoSeEncuentraComponent} from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';
import { DetallesCarroComponent } from './features/detalles-carro/detalles-carro.component';

const routes: Routes = [
  { path :'carros',component:CarrosComponent},
  { path: 'carros/crear', component:CrearCarroComponent },
  { path: 'carros/editar/:id', component:EditarCarroComponent},
  { path: 'detallesCarro', component:DetallesCarroComponent},
  { path:'',component:InicioComponent  },
  {path :'**', component:PaginaNoSeEncuentraComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
