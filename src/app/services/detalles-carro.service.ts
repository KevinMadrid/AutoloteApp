import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { DetalleCarro } from '../models/detalleCarro';

@Injectable({
  providedIn: 'root'
})
export class DetallesCarroService {
  apiURL='https://localhost:44357/api/DetalleCarro';

  constructor(private http: HttpClient) { }

obtenerDetallesCarro()
{
  return this.http.get<DetalleCarro[]>(this.apiURL);
}
obtenerDetalleCarro(id:Number)
{
  return this.http.get<DetalleCarro>(this.apiURL + '/' +id);
}

eliminarDetalleCarro(id: Number)
{
  return this.http.delete(this.apiURL + "/" + id);
}
}