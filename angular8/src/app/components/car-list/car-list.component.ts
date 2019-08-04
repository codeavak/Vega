import { ConfirmationDialogService } from './../../services/confirmation-dialog.service';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
carlist:any;
  constructor(private service:VehicleService,private bootstrapDialogService:ConfirmationDialogService) { }

  ngOnInit() {

    this.service.getVehicles().subscribe(succ=>this.carlist=succ,err=>console.log(err));
  }

  confirmDelete=(id)=>{

    console.log(this.carlist);
    this.bootstrapDialogService.confirm('Please confirm delete action', 'Do you really want to delete this car?')
    .then((confirmed) => {console.log('User confirmed:', confirmed);

    if(confirmed){
    this.carlist = this.carlist.filter(function( obj ) {
      return obj.id !== id;
    });
    this.service.deleteVehicle(id).subscribe(succ=>console.log(succ),err=>console.log(err));
  }
  })
    .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  }

}
