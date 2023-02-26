import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-allcars',
  templateUrl: './allcars.component.html',
  styleUrls: ['./allcars.component.css']
})
export class AllcarsComponent {
  public cars!:any[];
   
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService ,private router:Router ) { }
  ngOnInit(): void {
     
    this.refreshList();
  }
 delete(id:number){
  if(confirm('Are you sure?')){
    this.api.deleteCar(id).subscribe(res=>{
      console.log(res);
      this.refreshList();
    });
    location.reload();
  }
  
 } 
 refreshList(){
      this.api.getCars().subscribe(data=>{
        this.cars=data;
        console.log(this.cars)
      });
 
 }
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
 }
 
  edit(id:number)
  {
    this.router.navigate(['editcar',id]);
  }
}
