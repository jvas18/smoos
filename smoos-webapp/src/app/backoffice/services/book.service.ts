import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class BookService {
  
    url = '';
    constructor(private http: HttpClient) {
      this.url = `https://localhost:5001/books`;
    }
    get = (id: string): Observable<any> => this.http.get<any>(`${this.url}/${id}`).pipe(map(resp => resp));
    update = (id: string, data: any): Observable<any> => this.http.put<any>(`${this.url}/${id}`, data).pipe(map(resp => resp));
    create = (data: any): Observable<any> => this.http.post<any>(`${this.url}`, data).pipe(map(resp => resp));
    remove = (id: string): Observable<any> => this.http.delete<any>(`${this.url}/${id}`).pipe(map(resp => resp));
    changeStatus = (id: string): Observable<any> => this.http.patch<any>(`${this.url}/${id}`, {}).pipe(map(resp => resp));
  
  
  }
  