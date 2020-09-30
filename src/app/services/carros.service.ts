import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Carro} from '../models/carro';

@Injectable({
  providedIn: 'root'
})
export class CarrosService {
  apiURL='https://localhost:44357/api/Carro';

  constructor(private http: HttpClient) {}
    obtenerCarro(id:Number)
    {
      return this.http.get<Carro>(this.apiURL + '/' +id);
    }
    obtenerCarros()
    {
      return this.http.get<Carro[]>(this.apiURL);
    }
    crearCarro(carro: Carro)
    {
      return this.http.post<Carro>(this.apiURL, carro);
    }
    editarCarro(carro: Carro)
    {
      return this.http.put<Carro>(this.apiURL + '/' + carro.id, carro);
    }
    eliminarCarro(id: Number)
    {
      return this.http.delete(this.apiURL + "/" + id);
    }
  }
