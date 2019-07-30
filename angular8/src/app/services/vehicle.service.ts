import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

 BaseUrl = 'https://localhost:44369/';
  constructor(private http: HttpClient) { }

  getFeatures = () => this.http.get(this.BaseUrl + 'api/features');
  getMakes = () => this.http.get(this.BaseUrl + 'api/makes');
}
