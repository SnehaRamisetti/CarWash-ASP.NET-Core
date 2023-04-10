import { Component } from '@angular/core';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css']
})
export class MyordersComponent {
  id:any;
  
  orders:any={
    // carId:'',
    washingInstructions:'',
    date:'',
    packagename:'',
    description:'',
    price:'',
    city:'',
    pincode:'',
    status:''
   }
  api: any;
   ngOnInit(): void {
     
    this.refreshList();
  }
 
 refreshList(){
      this.api.getorderbyId(this.id).subscribe((data: any)=>{
        this.orders=data;
        console.log(this.orders)
      });
 
 }
}
