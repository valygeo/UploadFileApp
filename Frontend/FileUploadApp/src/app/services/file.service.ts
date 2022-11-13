import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private apiService:ApiService) { }
  public uploadCsvFile(fileToUpload:File):Observable<any>{
    return this.apiService.uploadFile(fileToUpload);
  }
}
