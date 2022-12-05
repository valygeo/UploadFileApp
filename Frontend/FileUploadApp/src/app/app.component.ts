import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FileService } from './services/file.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FileUploadApp';
  constructor(
    private http:HttpClient,
    private fileService:FileService
  ){}
 name:string='';
file:any;
data: any[] | undefined;
url: any; //Angular 11, for stricter type
	msg = "";
 getName(name:string){
  this.name=name;
 }
 getFile(event:any){
  this.file=event.target.files[0];
  // var reader = new FileReader();
  // reader.readAsDataURL(event.target.files[0]);
		
	// 	reader.onload = (_event) => {
	// 		this.msg = "";
	// 		this.url = reader.result; 
  console.log(this.file);
 }

 submitData(){
    this.fileService.uploadCsvFile(this.file).subscribe((data)=>console.log(data));
 }
 getApiFile(){
  this.fileService.getCsvFile(this.file).subscribe((data)=>{console.log(data),
  this.data=data;}
  );
 }
}



