import { Component, OnInit } from '@angular/core';
//import { ApiService } from 'app/api.service';
import { ApiService } from '../../../api.service';
import { ConteoVehiculo } from '../../ConteoVehiculo';

@Component({
  selector: 'app-conteo',
  templateUrl: './conteo.component.html',
  styleUrls: ['./conteo.component.scss']
})
export class ConteoComponent implements OnInit {

  constructor(private apiService: ApiService) {}
  datosConteo: ConteoVehiculo[] = [];
  ngOnInit(): void {
    this.apiService.getConteo().subscribe(
      (response:ConteoVehiculo[]) => {
        this.datosConteo = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
