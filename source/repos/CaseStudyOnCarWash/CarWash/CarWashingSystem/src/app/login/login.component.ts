import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
   type:string="password";
   isText:boolean=false;
   eyeIcon:string="fa-eye-slash";
   loginForm!:FormGroup;
  constructor(private fb:FormBuilder,private auth:AuthService,private router:Router) {
    

  }
  ngOnInit():void{
     this.loginForm =this.fb.group({
      email:['',Validators.required],
      password:['',Validators.required]
     })
  }
  onLogin()
  {
    if(this.loginForm.valid){
      console.log(this.loginForm.value)
      this.auth.Login(this.loginForm.value)
      .subscribe({
        next:(res)=>{
          alert(res.message);
          this.loginForm.reset();
          this.auth.storetoken(res.token);
          this.router.navigate(['adminmanagement'])
        },
        error:(err)=>{
          alert(err.error.message)

        }
      })
    }
    else{
      this.validateAllFormFileds(this.loginForm);
      alert("Your form is invalid")

    }
     
  }
  private validateAllFormFileds(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control =formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});

      }
      else if(control instanceof FormGroup){
        this.validateAllFormFileds (control)
      }
    })
  }
  hideShowPass(){
    this.isText=!this.isText;
    this.isText? this.eyeIcon="fa-eye":this.eyeIcon="fa-eye-slash";
    this.isText?this.type="text":this.type="password";
 
  }

}
