import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Files } from '../models/Files';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private apiService:ApiService) { }
  public uploadCsvFile(fileToUpload:File):Observable<any>{
    return this.apiService.uploadFile(fileToUpload);
  }
  public getCsvFile(fileName:File):Observable<any>{
    return this.apiService.getFile(fileName);
  }
}
