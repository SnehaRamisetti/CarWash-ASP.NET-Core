import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-package-details',
  templateUrl: './package-details.component.html',
  styleUrls: ['./package-details.component.css']
})
export class PackageDetailsComponent   {
  // title='packages';
  // packages:any[] | undefined;
  // package:any={
  //   id:'',
  //   name:'',
  //   description:'',
  //   price:'',
  //   status:''
  // }

  // constructor(private auth:AuthService,private api:ApiService)
  // {

  // }
  // ngOnInit():void{
  //   this.api.getPackages()
  //   .subscribe(res=>{
  //      this.packages=res;
  //   })
  // }
  
  // onSubmit()
  // {
  //    this.api.addPackages(this.package)
  //    .subscribe(
  //     res=>{
  //       this.ngOnInit();
  //     this.package={
  //       id:'',
  //   name:'',
  //   description:'',
  //   price:'',
  //   status:''
  //      };
  //     }
  //    )
  //   }
  // deletepackage(id:any){
  //   this.api.deletepackage(id)
  //   .subscribe(
  //     res=>{
  //       this.ngOnInit();
  //     }
  //   );

  // }
 
}
