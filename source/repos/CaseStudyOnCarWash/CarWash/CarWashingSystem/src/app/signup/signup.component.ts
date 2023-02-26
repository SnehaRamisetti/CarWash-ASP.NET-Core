import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  type: string = "password";
  isText : boolean = false;
  eyeIcon: string = "fa-eye-slash";
  signUpForm!:FormGroup;
  
 
  
 constructor(private fb:FormBuilder,private auth:AuthService,private router:Router) {
    

}
ngOnInit():void{
  this.signUpForm=this.fb.group({
   firstname:['',Validators.required],
   lastname:['',Validators.required],
   email:['',Validators.required],
   password:['',Validators.required],
   phonenumber:['',Validators.required],
   role:['',Validators.required],
   isactive:['',Validators.required]
  })
}

 
hideShowPass(){
 this.isText = !this.isText;
 this.isText ? this.eyeIcon = "fa-eye": this.eyeIcon = "fa-eye-slash";
 this.isText ? this.type = "text" : this.type ="password";
}
onSignup(){
  if(this.signUpForm.valid){
    this.auth.signUp(this.signUpForm.value)
    .subscribe({
       next:(res)=>{alert(res.message);this.signUpForm.reset();this.router.navigate(['user-login'])},
       error:(err)=>{alert(err?.error.message)}
    })
    
    console.log(this.signUpForm.value)
   }
   else{
    this.validateAllFormFileds(this.signUpForm)
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
      this.validateAllFormFileds(control)
    }
  })
}

}
