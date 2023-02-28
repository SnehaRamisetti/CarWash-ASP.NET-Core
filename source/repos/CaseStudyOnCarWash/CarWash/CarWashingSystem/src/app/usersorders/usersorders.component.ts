import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-usersorders',
  templateUrl: './usersorders.component.html',
  styleUrls: ['./usersorders.component.css']
})
export class UsersordersComponent {
  public orders!:any[];
   
  /**
   *
   */
  constructor(private auth:AuthService,private api:ApiService ,private router:Router ) { }
  ngOnInit(): void {
     
    this.refreshList();
  }
 
 refreshList(){
      this.api.getOrders().subscribe(data=>{
        this.orders=data;
        console.log(this.orders)
      });
 
 }
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
 }
}
