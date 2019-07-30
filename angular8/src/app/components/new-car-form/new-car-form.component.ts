import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-car-form',
  templateUrl: './new-car-form.component.html',
  styleUrls: ['./new-car-form.component.css']
})
export class NewCarFormComponent implements OnInit {
makes:any;
models:any;
features:any;
selectedMake:any=true;
selectedModel:any=true;

  constructor(private service:VehicleService) { }

  selectionChanged=(newItem)=>{console.log(newItem.target.value);console.log(this.makes[parseInt(newItem.target.value)-1]);this.models=this.makes[parseInt(newItem.target.value)-1].models;}
  createNew=(newVehicle)=>console.log(newVehicle.value);

  ngOnInit() {
    this.service.getFeatures().subscribe(succ=>{console.log(succ);this.features=succ;},err=>console.log(err));
    this.service.getMakes().subscribe(succ=>{console.log(succ);this.makes=succ;},err=>console.log(err));
  }

}
