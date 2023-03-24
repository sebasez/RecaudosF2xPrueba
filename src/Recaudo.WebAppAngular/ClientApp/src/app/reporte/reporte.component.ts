import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})
export class ReporteComponent{

  public reporte: Reporte[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Reporte[]>(baseUrl + 'reporte').subscribe(result => {
      this.reporte = result;
    }, error => console.error(error));
  }

}
interface Reporte {
    estacion: string;
    fecha: string;
    cantidad: number;
    valor: number;
}