import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-addpackage',
  templateUrl: './addpackage.component.html',
  styleUrls: ['./addpackage.component.css']
})
export class AddpackageComponent implements OnInit{
  public packages!:any[];
  packageForm!:FormGroup;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService) {
    

  }
  ngOnInit(): void {
    this.packageForm =this.fb.group({
       name:[''],
       description:[''],
        price:[''],
        status:['']
     })
  }
  AddPackage(){
    this.api.addPackages(this.packageForm.value)
    .subscribe({
      next:(res)=>{
        alert(res.message);
        this.packageForm.reset();
        
      },
      error:(err)=>{
        alert(err.error.message)

      }
    })
  
  }

}
