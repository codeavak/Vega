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
editId:number;
makes: any;
models: any;
features: any;
selectedMake: any = true;
selectedModel: any = true;
makeValue: number=-1;
modelValue: number;
nameValue:string;
phoneValue:string;
emailValue:string;
registeredValue:boolean;
moreinfoValue:string;
featuresValue:any;
featureValues:any=[false,false,false,false,false,false,false];


  constructor(private service: VehicleService, private toastr: ToastrService, private activeRoute: ActivatedRoute) { }


  selectionChanged = (newItem) => { this.modelValue=-1;
    this.models = this.makes[parseInt(newItem.target.value) - 1].models; }


    createOrUpdate=(newVehicle)=>{
      if(!this.editMode) this.createNew(newVehicle);
      else this.updateCar(newVehicle);
    }
  createNew = (newVehicle) => {console.log(newVehicle.value);
                               let newV = newVehicle.value;
                               let postFeatures = [];
                               for (let i = 0; i < this.features.length; i++) {
              if (newV['feature' + i] === true) {
          postFeatures.push(i+1);

              }
              const propertyName = 'feature' + i;
              delete newV[propertyName];
  }
                               delete newV.make;
                               newV.VehicleFeatures = postFeatures;
                        
                               this.service.postVehicle(newV).subscribe(
                                 succ => {
                                        newVehicle.reset();
                                        this.toastr.success('New Vehicle Posted Successfully!', 'Success!'); }
                                 , err => {
                                        this.toastr.error('There was a problem submitting your form! Please try again!', 'Error!');
                                });


  }



  updateCar = (newVehicle) => {console.log(newVehicle.value);
    let newV = newVehicle.value;
    newV.id=this.editId;
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
console.log('new vehicle');
console.log(newV);
    this.service.putVehicle(newV).subscribe(
      succ => {
             newVehicle.reset();
             this.toastr.success('New Vehicle Updated Successfully!', 'Success!'); }
      , err => {
             this.toastr.error('There was a problem updating your vehicle! Please try again!', 'Error!');
     });


}


  ngOnInit() {


    const routeParams = this.activeRoute.snapshot.params;


    if (typeof(routeParams.id) !== 'undefined') {
      this.editMode = true;
      this.editId=routeParams.id;

    } else { this.editMode=false; }


    this.service.getFeatures().subscribe(succ => {console.log(succ); this.features = succ; }, err => console.log(err));
    this.service.getMakes().subscribe(succ => {console.log(succ); this.makes = succ;
                                               if (this.editMode) {
      this.service.getVehicle(routeParams.id).subscribe(succ => {console.log(succ);
        
        this.makeValue = succ.model.makeId;
        this.models = this.makes[this.makeValue - 1].models;
        this.modelValue = succ.model.id;
        this.nameValue=succ.contactName;
        this.phoneValue=succ.contactPhone;
        this.emailValue=succ.contactEmail;
        this.registeredValue=succ.isRegistered;
        this.moreinfoValue=succ.moreInfo;
        this.featuresValue=succ.vehicleFeatures;

        this.featuresValue.forEach(element => {
        
          this.featureValues[element.featureId-1]=true;
          
        });

    }, err => console.log(err));

 }
    }, err => console.log(err));


  }

}
