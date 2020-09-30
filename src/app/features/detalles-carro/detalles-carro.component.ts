import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { DetallesCarroService } from 'src/app/services/detalles-carro.service';
import {DetalleCarro} from 'src/app/models/detalleCarro';

@Component({
  selector: 'app-detalles-carro',
  templateUrl: './detalles-carro.component.html',
  styleUrls: ['./detalles-carro.component.css']
})
export class DetallesCarroComponent implements OnInit {
  detallesCarro: DetalleCarro[];

  constructor(private _detallesCarroService: DetallesCarroService, private router: Router) { }

  ngOnInit() 
  {
    this.obtenerDetallesCarro();
  }
  obtenerDetallesCarro()
  {
    this._detallesCarroService.obtenerDetallesCarro().subscribe(data => 
      {this.detallesCarro=data;
    });
  }
  crearDetalleCarro()
  {
    this.router.navigate(['/detallesCarro/crear'])
  }
  editarDetalleCarro(id:Number)
  {
    this.router.navigate(['/detallesCarro/editar', id])
  }
  eliminarDetalleCarro(id: Number)
  {
    const res = confirm("Desea eliminar el Detalle del Carro?");
    if(res){
      this._detallesCarroService.eliminarDetalleCarro(id).subscribe(() => {
        this.obtenerDetallesCarro();
      })
    }
  }
}
