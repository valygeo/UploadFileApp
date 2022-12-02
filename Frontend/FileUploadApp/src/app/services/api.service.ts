import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Files } from '../models/Files';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }
  private urlUploadFile='https://localhost:7011/api/FileUpload/UploadFile/';
  private urlGetFile='https://localhost:7011/api/FileUpload/GetFileByName/';

  public uploadFile(fileToUpload:File):Observable<any>{
    const formData:FormData=new FormData();
    formData.append('files',fileToUpload,fileToUpload.name);
    return this.http.post(this.urlUploadFile,formData,{responseType:'text'})
  }
  public getFile(fileName:File):Observable<any>{
    const formData2:FormData = new FormData();
    
      // let fileReader = new FileReader();
      // fileReader.onload = (e) => {
      //   console.log(fileReader.result);
      // }
      // fileReader.readAsText(fileToGet);
  
    return this.http.get<File>(this.urlGetFile+fileName.name);
  }
}
