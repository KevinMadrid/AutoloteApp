import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { DetallesCarroService } from 'src/app/services/detalles-carro.service';
import { DetalleCarro } from 'src/app/models/detalleCarro';
import { Carro } from 'src/app/models/carro';
import { CarrosService } from 'src/app/services/carros.service';

@Component({
  selector: 'app-editar-carro',
  templateUrl: './editar-carro.component.html',
  styleUrls: ['./editar-carro.component.css']
})
export class EditarCarroComponent implements OnInit {
  detalleCarro: DetalleCarro[];
  carro: Carro;
  
  constructor(
    private _detallesCarroService: DetallesCarroService,
    private _carrosService: CarrosService,
    private router: Router,
    private route: ActivatedRoute) {
      this.carro = new Carro();
     }

  ngOnInit() {

    const id = +this.route.snapshot.paramMap.get("id");

    this._detallesCarroService.obtenerDetallesCarro().subscribe(res =>{
      this.detalleCarro = res;
    })

    this._carrosService.obtenerCarro(id).subscribe(res =>{
      this.carro = res;
    });
  }
  editarCarro()
  {
    this._carrosService.editarCarro(this.carro)
    .subscribe(() => {
      this.router.navigate(['/carros']);
    })
  }
  cancelar()
  {
    this.router.navigate(['/carros'])
  }

}
