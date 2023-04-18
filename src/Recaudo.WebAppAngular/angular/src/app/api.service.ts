import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RecaudoVehiculo, Reporte } from './dashboard/RecaudoVehiculo';
import { ConteoVehiculo } from './dashboard/ConteoVehiculo';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

 
  private apiUrl = 'https://localhost:7126/api/'; // Configura la URL de tu API

  constructor(private http: HttpClient) { }

  getRecaudo(): Observable<RecaudoVehiculo[]>{
    return this.http.get<RecaudoVehiculo[]>(this.apiUrl+'Recaudo');
  }

  getConteo(): Observable<ConteoVehiculo[]>{
    return this.http.get<ConteoVehiculo[]>(this.apiUrl+'Conteo');
  }

  getReporte(fechaInicio:Date,fechaFin:Date): Observable<Reporte[]>{
    return this.http.post<Reporte[]>(this.apiUrl+'Reporte',{fechaInicio,fechaFin});
  }
}
