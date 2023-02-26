import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent {
  type:string="password";
  id:any;
  public users!:any[];
   user:any={
    // carId:'',
    firstName:'',
    lastName:'',
    email:'',
    password:'',
    phoneNumber:'',
    role:'',
    isActive:''
   }
   userForm!:FormGroup;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService,private route:ActivatedRoute,private router:Router) {
    

  }
  ngOnInit(): void {
    
    this.id=this.route.snapshot.params['id'];
    this.api.getuserbyId(this.id). subscribe(data=>{
      this.user=data;
    },error=>console.log(error));
      
      
    
  } 
  onSubmit(){
    this.api.updateuser(this.id,this.user).subscribe
    (
      data=>{
        this.router.navigate(['/allusers']);
      },error=>console.log(error));
       
      
    
  }
}
