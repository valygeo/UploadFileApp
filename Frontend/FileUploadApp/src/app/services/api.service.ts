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
  private urlGetFile='https://localhost:7011/api/FileUpload/GetFile/';

  public uploadFile(fileToUpload:File):Observable<any>{
    const formData:FormData=new FormData();
    formData.append('files',fileToUpload,fileToUpload.name);
    return this.http.post(this.urlUploadFile,formData,{responseType:'text'})
  }
  public getFile(fileToGet:File):Observable<any>{
    const formData2:FormData = new FormData();
    formData2.append('files',fileToGet,fileToGet.name);
    
      let fileReader = new FileReader();
      fileReader.onload = (e) => {
        console.log(fileReader.result);
      }
      fileReader.readAsText(fileToGet);
  
    return this.http.get<File>(this.urlGetFile+fileToGet.name);
  }
}
