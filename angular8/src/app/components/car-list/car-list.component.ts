import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
carlist:any;
  constructor(private service:VehicleService) { }

  ngOnInit() {

    this.service.getVehicles().subscribe(succ=>this.carlist=succ,err=>console.log(err));
  }

}
