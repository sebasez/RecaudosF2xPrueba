import { Component, OnInit } from "@angular/core";
import { ApiService } from '../../../api.service';
import { RecaudoVehiculo } from "../../RecaudoVehiculo"

@Component({
  selector: "app-recaudo",
  templateUrl: "./recaudo.component.html",
  styleUrls: ["./recaudo.component.scss"],
})
export class RecaudoComponent implements OnInit {
  constructor(private apiService: ApiService) {}
  datosRecaudo: RecaudoVehiculo[] = [];
  ngOnInit() {
    this.apiService.getRecaudo().subscribe(
      (response:RecaudoVehiculo[]) => {
        this.datosRecaudo = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}

