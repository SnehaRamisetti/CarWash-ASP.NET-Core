import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { FormsModule } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {
   title='cars';
   cars:any[] | undefined;
   car:any={
    // carId:'',
    modelname:'',
    status:''
   }
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService) {
}
ngOnInit():void{
  this.api.getCars()
  .subscribe(res=>{
     this.cars=res;
  })
}
 
onSubmit(){
  // if(this.car.carId==='')
  {
    this.api.AddCar(this.car)
  .subscribe(res=>{
      this.ngOnInit();
      this.car={
        // carId:'',
        modelName:'',
        status:''
       };

  })
}
//   else{
// this.updateCar(this.car)
//   }
}
deleteCar(carId:any){
  this.api.deleteCar(carId).subscribe(res=>{
    this.ngOnInit();
  })
}
populateForm(car:any){
this.car=car;
}
updateCar(car:any)
{
   
}
}
