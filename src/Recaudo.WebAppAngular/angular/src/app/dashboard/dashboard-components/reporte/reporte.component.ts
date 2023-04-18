import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../api.service';
import { Reporte } from "../../RecaudoVehiculo"

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.scss']
})
export class ReporteComponent implements OnInit {
  fechaInicio: string;
  fechaFin: string;
  constructor(private apiService: ApiService) {
    this.fechaInicio = "2021-08-01"
    this.fechaFin = "2021-08-01"
  }
  datosReporte: Reporte[] = [];
  ngOnInit(): void {
    this.apiService.getReporte(new Date(this.fechaInicio),new Date(this.fechaFin)).subscribe(
      (response:Reporte[]) => {
        this.datosReporte = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  filtrar(){
    this.apiService.getReporte(new Date(this.fechaInicio),new Date(this.fechaFin)).subscribe(
      (response:Reporte[]) => {
        this.datosReporte = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  sumarCantidad(arreglo: Reporte[]): number {
    let suma:number=0;
    arreglo.forEach((it)=>{
      suma += it.cantidad
    })
    return suma
  }

  sumarValor(arreglo: Reporte[]): number {
    let suma:number=0;
    arreglo.forEach((it)=>{
      suma += it.valor
    })
    return suma
  }
}
