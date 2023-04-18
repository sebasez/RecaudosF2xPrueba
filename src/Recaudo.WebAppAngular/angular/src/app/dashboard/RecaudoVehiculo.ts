export interface RecaudoVehiculo {
  estacion: string;
  sentido: string;
  hora: string;
  fecha: Date;
  categoria: string;
  valorTabulado: number;
}
export interface Reporte {
  estacion: string;
  fecha: Date;
  cantidad: number;
  valor: number;
}
