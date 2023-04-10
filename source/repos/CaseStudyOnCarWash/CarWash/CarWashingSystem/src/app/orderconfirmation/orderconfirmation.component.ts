import { Component, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import jsPDF from 'jspdf';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
 


@Component({
  selector: 'app-orderconfirmation',
  templateUrl: './orderconfirmation.component.html',
  styleUrls: ['./orderconfirmation.component.css']
})
export class OrderconfirmationComponent {
   /**
    *
    */
   @ViewChild('content',{static:false})content!:ElementRef;
   constructor(private fb:FormBuilder,private auth:AuthService,private api:ApiService,private route:ActivatedRoute,private router:Router) {
    

   }
  id:any;
  orders:any={
    // carId:'',
    washingInstructions:'',
    date:'',
    packagename:'',
    description:'',
    price:'',
    city:'',
    pincode:'',
    status:''
   }
  ngOnInit(): void {
    
    this.id=this.route.snapshot.params['id'];
    this.api.getorderbyId(this.id). subscribe(data=>{
      this.orders=data;
    },error=>console.log(error));
      
      
    
  } 
makePDF(){
  let pdf = new jsPDF('p','pt','a3');
  pdf.html(this.content.nativeElement,{
    callback:(pdf)=>{
      pdf.save("order.pdf");
    }
  });
}

}


