import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-car-form',
  templateUrl: './new-car-form.component.html',
  styleUrls: ['./new-car-form.component.css']
})
export class NewCarFormComponent implements OnInit {
makes: any;
models: any;
features: any;
selectedMake: any = true;
selectedModel: any = true;

  constructor(private service: VehicleService,private toastr: ToastrService) { }

  selectionChanged = (newItem) => {
    this.models = this.makes[parseInt(newItem.target.value) - 1].models; }
  createNew = (newVehicle) => {console.log(newVehicle.value);
                               var newV = newVehicle.value;
                               var postFeatures = [];
                               for (let i = 0; i < this.features.length; i++) {
              if (newV['feature' + i] === true) {
          postFeatures.push(i + 1);

              }
              const propertyName = 'feature' + i;
              delete newV[propertyName];
  }
                               delete newV.make;
                               newV.VehicleFeatures = postFeatures;
                               console.log(newV);
                               this.service.postVehicle(newV).subscribe(
                                 succ=>{console.log(succ);
                                  newVehicle.reset();
                                  this.toastr.success('New Vehicle Posted Successfully!', 'Success!');}
                                 ,err=>{console.log(err);
                                  this.toastr.error('There was a problem submitting your form! Please try again!', 'Error!');
                                });


  }



  ngOnInit() {
    this.service.getFeatures().subscribe(succ => {console.log(succ); this.features = succ; }, err => console.log(err));
    this.service.getMakes().subscribe(succ => {console.log(succ); this.makes = succ; }, err => console.log(err));
  }

}
