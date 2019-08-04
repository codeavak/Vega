import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VehicleService } from 'src/app/services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
 
makes: any;
models: any;
features: any;
selectedMake: any = true;
selectedModel: any = true;
makeValue: number;
modelValue: number;
nameValue:string;
phoneValue:string;
emailValue:string;
registeredValue:boolean;
moreinfoValue:string;
featuresValue:any;
featureValues:any=[false,false,false,false,false,false,false];
  id:number;
  constructor(private http: HttpClient, private service: VehicleService, private toastr: ToastrService, private activeRoute: ActivatedRoute) { }


  public progress: number;
  public message: string;
public pictures:any[]=[];

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', `https://localhost:44369/api/upload`, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        {this.message = event.body.toString();
        this.pictures.push(`https://localhost:44369/upload/${this.message}`);
        }
    });
  }



  ngOnInit() { 

    
    this.service.getFeatures().subscribe(succ => {console.log(succ); this.features = succ; }, err => console.log(err));
    this.service.getMakes().subscribe(succ => {console.log(succ); this.makes = succ;
    
    const routeParams = this.activeRoute.snapshot.params;


    if (typeof(routeParams.id) !== 'undefined') {
      this.id = routeParams.id;

      this.service.getVehicle(this.id).subscribe(succ => {console.log(succ);
        
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
        
          this.featureValues[element.featureId]=true;
          
        });

    }, err => console.log(err));

 }
});
  }
}
