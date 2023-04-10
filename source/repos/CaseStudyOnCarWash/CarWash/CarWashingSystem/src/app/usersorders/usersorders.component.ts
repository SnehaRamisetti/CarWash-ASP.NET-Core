import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-usersorders',
  templateUrl: './usersorders.component.html',
  styleUrls: ['./usersorders.component.css']
})
export class UsersordersComponent {
  id:any;
  public orders!:any[];
  order:any={
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
   update:any={
    // carId:'',
    washingInstructions:'',
    date:'',
    packagename:'',
    description:'',
    price:'',
    city:'',
    pincode:'',
    status:'Accepted'
   }
   
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService ,private router:Router ) { }
  ngOnInit(): void {
     
    this.refreshList();
  }
 
  refreshList(){
    this.api.getOrders().subscribe(data=>{
      this.orders=data;
      console.log(this.orders)
    });

}
 Accept(id:number){
  this.api.getorderbyId(id). subscribe(data=>{
    this.order=data;
    this.update.packagename=this.order.packagename;
      this.update.description=this.order.description;
      this.update.date=this.order.date;
      this.update.price=this.order.price;
      this.update.washingInstructions=this.order.washingInstructions;
      this.update.city=this.order.city;
      this.update.pincode=this.order.pincode;
      this.update.status=this.update.status
    this.api.updateorder(id,this.update).subscribe
    (
      data=>{
        this.ngOnInit();
      },error=>console.log(error));
     
    
  },error=>console.log(error));
    

 }
 
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
 }
}
