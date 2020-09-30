import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {CarrosService} from 'src/app/services/carros.service';
import {Carro} from 'src/app/models/carro';

@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.css']
})
export class CarrosComponent implements OnInit {
  carros: Carro[];

  constructor(private _carrosService: CarrosService, private router: Router) {  }

  ngOnInit() 
  {
    this.obtenerCarros();
  }
 
  obtenerCarros()
  {
    this._carrosService.obtenerCarros().subscribe(data => 
      {this.carros=data;
    });
  }
  crearCarro()
  {
    this.router.navigate(['/carros/crear'])
  }
  editarCarro(id:Number)
  {
    this.router.navigate(['/carros/editar', id])
  }
  eliminarCarro(id: Number)
  {
    const res = confirm("Desea eliminar el carro?");
    if(res){
      this._carrosService.eliminarCarro(id).subscribe(() => {
        this.obtenerCarros();
      })
    }
  }
 }
