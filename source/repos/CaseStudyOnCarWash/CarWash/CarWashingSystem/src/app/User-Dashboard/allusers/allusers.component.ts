import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-allusers',
  templateUrl: './allusers.component.html',
  styleUrls: ['./allusers.component.css']
})
export class AllusersComponent {
  public users!:any[];
   
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService ,private router:Router ) { }
  ngOnInit(): void {
     
    this.refreshList();
  }
 delete(id:number){
  if(confirm('Are you sure?')){
    this.api.deleteuser(id).subscribe(res=>{
      console.log(res);
      this.refreshList();
    });
    location.reload();
  }
  
 } 
 refreshList(){
      this.api.getUsers().subscribe(data=>{
        this.users=data;
        console.log(this.users)
      });
 
 }
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
 }
 populateForm(packages:any){
  this.users=this.users;
  }
  edit(id:number)
  {
    this.router.navigate(['edituser',id]);
  }
}
