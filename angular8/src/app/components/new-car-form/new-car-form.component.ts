import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-car-form',
  templateUrl: './new-car-form.component.html',
  styleUrls: ['./new-car-form.component.css']
})
export class NewCarFormComponent implements OnInit {
editMode: any;
makes: any;
models: any;
features: any;
selectedMake: any = true;
selectedModel: any = true;
makeValue: number;
modelValue: number;
  constructor(private service: VehicleService, private toastr: ToastrService, private activeRoute: ActivatedRoute) { }


  selectionChanged = (newItem) => {
    this.models = this.makes[parseInt(newItem.target.value) - 1].models; }

  createNew = (newVehicle) => {console.log(newVehicle.value);
                               let newV = newVehicle.value;
                               let postFeatures = [];
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
                                 succ => {console.log(succ);
                                        newVehicle.reset();
                                        this.toastr.success('New Vehicle Posted Successfully!', 'Success!'); }
                                 , err => {console.log(err);
                                        this.toastr.error('There was a problem submitting your form! Please try again!', 'Error!');
                                });


  }



  ngOnInit() {


    const routeParams = this.activeRoute.snapshot.params;
    console.log(routeParams);

    if (typeof(routeParams.id) !== 'undefined') {
      this.editMode = true;


    } else { this.editMode=false; }


    this.service.getFeatures().subscribe(succ => {console.log(succ); this.features = succ; }, err => console.log(err));
    this.service.getMakes().subscribe(succ => {console.log(succ); this.makes = succ;
                                               if (this.editMode) {
      this.service.getVehicle(routeParams.id).subscribe(succ => {console.log(succ);
                                                                 this.makeValue = succ.model.makeId;
                                                                 this.models = this.makes[this.makeValue - 1].models;
                                                                 this.modelValue = succ.model.id;
                                                                 console.log('model id:' + succ.model.id);

    }, err => console.log(err));

 }
    }, err => console.log(err));


  }

}
