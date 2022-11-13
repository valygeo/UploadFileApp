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
 getName(name:string){
  this.name=name;
 }
 getFile(event:any){
  this.file=event.target.files[0];
  console.log(this.file);
 }
//  submitData(){
//   let formData=new FormData();
//   formData.set('name',this.name);
//   formData.set('file',this.file);
//   this.http.post('https://localhost:7011/api/FileUpload/UploadFile',formData).subscribe((response: any)=>console.log(formData),
// );
//  }
 submitData(){
    this.fileService.uploadCsvFile(this.file).subscribe((data)=>console.log(data));
 }
}



