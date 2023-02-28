import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { TokenInterceptor } from './interceptors/token.interceptor';
 
import { CarDetailsComponent } from './car-details/car-details.component';
import { PackageDetailsComponent } from './package-details/package-details.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { AllpackageComponent } from './Package-Dashboard/allpackage/allpackage.component';
import { EditpackageComponent } from './Package-Dashboard/editpackage/editpackage.component';
import { AddpackageComponent } from './Package-Dashboard/addpackage/addpackage.component';
import { AllcarsComponent } from './Car-Dashboard/allcars/allcars.component';
import { AddcarComponent } from './Car-Dashboard/addcar/addcar.component';
import { EditcarComponent } from './Car-Dashboard/editcar/editcar.component';
import { AllusersComponent } from './User-Dashboard/allusers/allusers.component';
import { EdituserComponent } from './User-Dashboard/edituser/edituser.component';
import { UsersordersComponent } from './usersorders/usersorders.component';
import { OrderComponent } from './order/order.component';


@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
     
    PackageDetailsComponent,
    CarDetailsComponent,
    HomeComponent,
    AdminManagementComponent,
    PackageDetailsComponent,
    UserLoginComponent,
    AllpackageComponent,
    EditpackageComponent,
    AddpackageComponent,
    AllcarsComponent,
    AddcarComponent,
    EditcarComponent,
    AllusersComponent,
    EdituserComponent,
    UsersordersComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
