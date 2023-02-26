import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-editpackage',
  templateUrl: './editpackage.component.html',
  styleUrls: ['./editpackage.component.css']
})
export class EditpackageComponent implements OnInit{
  id:any;
  public packages!:any[];
  package:any={
    // carId:'',
    name:'',
    description:'',
    price:'',
    status:''
   }
  packageForm!:FormGroup;
   
  
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
    this.api.updatePackage(this.id,this.package).subscribe
    (
      data=>{
        this.router.navigate(['/allpackage']);
      },error=>console.log(error));
       
      
    
  }

}

