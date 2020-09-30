import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DetallesCarroService } from 'src/app/services/detalles-carro.service';
import { DetalleCarro } from 'src/app/models/detalleCarro';
import { Carro } from 'src/app/models/carro';
import { CarrosService } from 'src/app/services/carros.service';

@Component({
  selector: 'app-crear-carro',
  templateUrl: './crear-carro.component.html',
  styleUrls: ['./crear-carro.component.css']
})
export class CrearCarroComponent implements OnInit {
  detallesCarro: DetalleCarro[];
  carro: Carro;

  constructor(private _detallesCarroService: DetallesCarroService, 
    private _carrosService:CarrosService,
    private router: Router) { 
      this.carro = new Carro();
    }

  ngOnInit(): void {
      this._detallesCarroService.obtenerDetallesCarro().subscribe(res =>{
        this.detallesCarro = res;
  })
}
  CrearCarro()
  {
    if(this.carro)
    {
      this._carrosService.crearCarro(this.carro).subscribe(() =>{
        this.router.navigate(['/carros'])
      })
    }
  }
  cancelar()
  {
    this.router.navigate(['/carros'])
  }

}
