import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  type:string="password";
  id:any;
  public users!:any[];
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
   package:any={
    // carId:'',
   
    name:'',
    price:'',
     
   }
   orderForm!:FormGroup;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService,private route:ActivatedRoute,private router:Router) {
    

  }
  ngOnInit(): void {
    
    this.id=this.route.snapshot.params['id'];
    this.api.getpackagebyId(this.id). subscribe(data=>{
      this.package=data;
    },error=>console.log(error));
      
      
    
  } 
  onSubmit(){
    this.api.addorder(this.order).subscribe
    (
      data=>{
        this.router.navigate(['package-details']);
      },error=>console.log(error));
       
      
    
  }
}
