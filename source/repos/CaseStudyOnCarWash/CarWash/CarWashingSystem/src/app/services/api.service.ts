import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl:string="https://localhost:44354/api/";
  private carbaseUrl:string="https://localhost:44354/api/Car";

  constructor( private http:HttpClient) { }
  getUsers()
  {
    return this.http.get<any>(`${this.baseUrl}User`);
  }
  getCars()
  {
    return this.http.get<any>(`${this.baseUrl}Car`);
  }
  getPackages()
  {
    return this.http.get<any>(`${this.baseUrl}Package`);
  }
  AddCar(carObj:any)
  {
    return this.http.post<any>(`${this.baseUrl}Car`,carObj);
  }
  deleteCar(carId:any)
  {
    return this.http.delete<any>(this.carbaseUrl + '/' +carId);
  }
  updateCar(id:number,car:any)
  {
    return this.http.put<any>(this.carbaseUrl + '/' +id,car);
  }
  addPackages(packageObj:any)
  {
    return this.http.post<any>(`${this.baseUrl}Package`,packageObj);
  }
  deletepackage(Id:any)
  {
    return this.http.delete<any>(`${this.baseUrl}Package` + '/' +Id);
  }
  updatePackage( id:number,packageobj:any)
  {
    return this.http.put<any>(`${this.baseUrl}Package`+ '/' +id,packageobj);
  }
  deleteuser(Id:any)
  {
    return this.http.delete<any>(`${this.baseUrl}User` + '/' +Id);
  }
  updateuser(id:number,userobj:any)
  {
    return this.http.put<any>(`${this.baseUrl}User`+ '/' +id,userobj);
  }
  getpackagebyId(id:number)
  {
    return this.http.get<any>(`${this.baseUrl}Package` + '/' +id);
  }
  getcarbyId(id:number)
  {
    return this.http.get<any>(`${this.baseUrl}Car` + '/' +id);
  }
  getuserbyId(id:number)
  {
    return this.http.get<any>(`${this.baseUrl}User` + '/' +id);
  }
}
