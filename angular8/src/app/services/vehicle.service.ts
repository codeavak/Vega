import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


class feature{
  public vehicleId:number;
  public featureId:number;
}

class model{
  
  public makeId : number;
  
  public id : number;


}

class NewCar{
  
  public model : model;
  contactEmail:string;
  contactPhone:string;
  contactName:string;
  isRegistered:boolean;
  moreInfo:string;
  vehicleFeatures:feature[];
  
}


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

 BaseUrl = 'https://localhost:44369/';
  constructor(private http: HttpClient) { }

  getFeatures = () => this.http.get(`${this.BaseUrl}api/features`);

  getMakes = () => this.http.get(`${this.BaseUrl}api/makes`);

  getVehicles = () => this.http.get(`${this.BaseUrl}api/vehicles`);

  getVehicle = (id) => this.http.get<NewCar>(`${this.BaseUrl}api/vehicles/${id}`);

  deleteVehicle = (id) => this.http.delete(`${this.BaseUrl}api/vehicles/${id}`);

  postVehicle = (newVehicle: any) => this.http.post(`${this.BaseUrl}api/vehicles`, newVehicle);

  putVehicle = (newVehicle: any) => this.http.put(`${this.BaseUrl}api/vehicles/${newVehicle.id}`, newVehicle);
}
