import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class AuthService {
  
    url = '';
    constructor(private http: HttpClient) {
      this.url = `https://localhost:5001/auth`;
    }

    auth = (data: any): Observable<any> => this.http.post<any>(`${this.url}`, data).pipe(map(resp => resp));
  
  
  }
  