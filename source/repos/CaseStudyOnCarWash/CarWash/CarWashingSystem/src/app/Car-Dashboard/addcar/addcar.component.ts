import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-addcar',
  templateUrl: './addcar.component.html',
  styleUrls: ['./addcar.component.css']
})
export class AddcarComponent {
  public cars!:any[];
  carForm!:FormGroup;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService) {
    

  }
  ngOnInit(): void {
    this.carForm =this.fb.group({
       modelName:[''],
        
        status:['']
     })
  }
  AddCar(){
    this.api.AddCar(this.carForm.value)
    .subscribe({
      next:(res)=>{
        alert(res.message);
        this.carForm.reset();
        
      },
      error:(err)=>{
        alert(err.error.message)

      }
    })
  
  }

}
