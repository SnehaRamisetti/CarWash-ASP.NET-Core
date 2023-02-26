import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-editcar',
  templateUrl: './editcar.component.html',
  styleUrls: ['./editcar.component.css']
})
export class EditcarComponent {
  id:any;
  public cars!:any[];
   car:any={
    // carId:'',
    modelName:'',
     
    status:''
   }
   carForm!:FormGroup;
   
  
  /**
   *
   */
  constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService,private route:ActivatedRoute,private router:Router) {
    

  }
  ngOnInit(): void {
    
    this.id=this.route.snapshot.params['id'];
    this.api.getcarbyId(this.id). subscribe(data=>{
      this.car=data;
    },error=>console.log(error));
      
      
    
  } 
  onSubmit(){
    this.api.updateCar(this.id,this.car).subscribe
    (
      data=>{
        this.router.navigate(['/allcars']);
      },error=>console.log(error));
       
      
    
  }
}
