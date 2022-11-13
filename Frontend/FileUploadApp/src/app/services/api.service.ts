import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }
  private urlUploadFile='https://localhost:7011/api/FileUpload/UploadFile/';
  public uploadFile(fileToUpload:File):Observable<any>{
    const formData:FormData=new FormData();
    formData.append('fileKey',fileToUpload,fileToUpload.name);
    return this.http.post(this.urlUploadFile,formData,{responseType:'text'})
  }
}
