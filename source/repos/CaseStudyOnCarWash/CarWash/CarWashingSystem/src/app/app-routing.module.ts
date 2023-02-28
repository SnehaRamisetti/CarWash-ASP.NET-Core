import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { AddcarComponent } from './Car-Dashboard/addcar/addcar.component';
import { AllcarsComponent } from './Car-Dashboard/allcars/allcars.component';
import { EditcarComponent } from './Car-Dashboard/editcar/editcar.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { AuthGuard } from './Guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { AddpackageComponent } from './Package-Dashboard/addpackage/addpackage.component';
import { AllpackageComponent } from './Package-Dashboard/allpackage/allpackage.component';
import { EditpackageComponent } from './Package-Dashboard/editpackage/editpackage.component';
import { PackageDetailsComponent } from './package-details/package-details.component';
import { SignupComponent } from './signup/signup.component';
import { AllusersComponent } from './User-Dashboard/allusers/allusers.component';
import { EdituserComponent } from './User-Dashboard/edituser/edituser.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UsersordersComponent } from './usersorders/usersorders.component';

 

const routes: Routes = [
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'signup',component: SignupComponent},
  {path:'home',component: HomeComponent},
  {path:'user-login',component:UserLoginComponent},
  {path:'adminmanagement',component:  AdminManagementComponent},
  {path:'car-details',component:CarDetailsComponent,canActivate:[AuthGuard]},
  {path:'package-details',component:PackageDetailsComponent,canActivate:[AuthGuard]},
   
  {path:'allpackage',component: AllpackageComponent,canActivate:[AuthGuard]},
  {path:'addpackage',component:  AddpackageComponent,canActivate:[AuthGuard]},
  {path:'editpackage/:id',component: EditpackageComponent,canActivate:[AuthGuard]},
  {path:'allcars',component:AllcarsComponent  ,canActivate:[AuthGuard]},
  {path:'addcar',component: AddcarComponent  ,canActivate:[AuthGuard]},
  {path:'editcar/:id',component:EditcarComponent  ,canActivate:[AuthGuard]},
  {path:'allusers',component: AllusersComponent,canActivate:[AuthGuard]},
  {path:'edituser/:id',component: EdituserComponent,canActivate:[AuthGuard]},
  {path:'usersorders',component:  UsersordersComponent,canActivate:[AuthGuard]},
  {path:'order/:id',component: OrderComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
