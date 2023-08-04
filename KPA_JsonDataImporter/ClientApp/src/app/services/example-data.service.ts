import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class ExampleDataService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseApiUrl: string) { }

  getExamples(): Observable<any> {
    return this.httpClient.get<ExampleModel[]>(this.baseApiUrl + 'exampleapi/getexamplelist');
  }

  importJson(file: any, fileName: string): Observable<any> {
    console.log("importJson")
    const formData = new FormData();

    formData.append("file", file, fileName);

    return this.httpClient.post(this.baseApiUrl + 'exampleapi/importjson', formData);
  }
}

export interface ExampleModel {
  id: number;
  departmentName: string;
  notes: string;
  environmentScore: number;
  healthScore: number;
  safetyScore: number;
  jsonData: string;
}
