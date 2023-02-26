import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-allpackage',
  templateUrl: './allpackage.component.html',
  styleUrls: ['./allpackage.component.css']
})
export class AllpackageComponent {
  public packages!:any[];
   
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService ,private router:Router ) { }
  ngOnInit(): void {
     
    this.refreshList();
  }
 delete(id:number){
  if(confirm('Are you sure?')){
    this.api.deletepackage(id).subscribe(res=>{
      console.log(res);
      this.refreshList();
    });
    location.reload();
  }
  
 } 
 refreshList(){
      this.api.getPackages().subscribe(data=>{
        this.packages=data;
        console.log(this.packages)
      });
 
 }
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
 }
 
  edit(id:number)
  {
    this.router.navigate(['editpackage',id]);


  }
}
