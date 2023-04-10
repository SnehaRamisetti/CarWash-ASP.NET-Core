import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
// import html2canvas from 'html2canvas';
// import jsPDF from 'jspdf';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  type:string="password";
  id:any;
  showme:boolean =false;
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
    status:'Pending'
   }
   package:any={
    // carId:'',
   
    name:'',
    price:'',
    description:''
     
   }
   orderForm!:FormGroup;
   message:boolean=false;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService,
    private route:ActivatedRoute,
    
    private router:Router,
    private toastr:ToastrService) {
    

  }
  ngOnInit(): void {
    
    this.id=this.route.snapshot.params['id'];
    this.api.getpackagebyId(this.id). subscribe(data=>{
      this.package=data;
      this.order.packagename=this.package.name;
      this.order.description=this.package.description;
      this.order.price=this.package.price
    },error=>console.log(error));
      
      
    
  } 
  onSubmit(){

    this.api.addorder(this.order).subscribe
    (
      data=>{
        this.message=true;
        this.id= data.id;
      },error=>console.log(error));
       
      
    
  }
  removemsg(){
    this.message=false;
      
  }
  next(){
    this.router.navigate(['orderconfirm',this.id]);
  }
 
}
