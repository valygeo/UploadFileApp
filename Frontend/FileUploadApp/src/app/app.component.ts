import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FileUploadApp';
 name:string='';
 file:any;
 getName(name:string){
  this.name=name;
 }
 getFile(event:any){
  this.file=event.target.files[0];
  console.log(this.file);
 }
}



