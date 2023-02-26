import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.css']
})
export class AdminManagementComponent {
  constructor(private router:Router) {
  }
  
  onUser(){
    this.router.navigate(['allusers'])
  }
  onCar(){
    this.router.navigate(['allcars'])
  }
  onPackage(){
    this.router.navigate(['allpackage'])
  }
}
