import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class AuthService {
   private baseUrl:string ="https://localhost:44354/api/"
  constructor(private http : HttpClient) {} 
  signUp(userObj:any)
  {
    return this.http.post<any>(`${this.baseUrl}User/register`,userObj)
  }
  Login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}Admin/Login`,loginObj)

  }
  UserLogin(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}User/Login`,loginObj)

  }
  storetoken(tokenvalue:string){
    localStorage.setItem('token',tokenvalue)
  }
  getToken()
  {
    return localStorage.getItem('token')
  }
  isLoggedIn(){
    return !!localStorage.getItem('token')
  }
}
