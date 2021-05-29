import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class RatingService {

    url = '';
    constructor(private http: HttpClient) {
      this.url = `https://localhost:5001/rating`;
    }
    get = (id: string): Observable<any> => this.http.get<any>(`${this.url}/${id}`).pipe(map(resp => resp));
    getAll = (): Observable<any> => this.http.get<any>(`${this.url}`).pipe(map(resp => resp));
    update = (id: string, data: any): Observable<any> => this.http.put<any>(`${this.url}/${id}`, data).pipe(map(resp => resp));
    createMovie = (data: any): Observable<any> => this.http.post<any>(`${this.url}/movie-rating`, data).pipe(map(resp => resp));
    createSong = (data: any): Observable<any> => this.http.post<any>(`${this.url}/song-rating`, data).pipe(map(resp => resp));
    createBook = (data: any): Observable<any> => this.http.post<any>(`${this.url}/book-rating`, data).pipe(map(resp => resp));
    createAlbum = (data: any): Observable<any> => this.http.post<any>(`${this.url}/album-rating`, data).pipe(map(resp => resp));
    remove = (id: string): Observable<any> => this.http.delete<any>(`${this.url}/${id}`).pipe(map(resp => resp));
    changeStatus = (id: string): Observable<any> => this.http.patch<any>(`${this.url}/${id}`, {}).pipe(map(resp => resp));
    getMovies = (movieId: string): Observable<any> => this.http.get<any>(`${this.url}/movie/${movieId}`).pipe(map(resp => resp));
    getBook = (bookId: string): Observable<any> => this.http.get<any>(`${this.url}/book/${bookId}`).pipe(map(resp => resp));
    getSong = (songId: string): Observable<any> => this.http.get<any>(`${this.url}/song/${songId}`).pipe(map(resp => resp));
    getAlbum = (albumId: string): Observable<any> => this.http.get<any>(`${this.url}/album/${albumId}`).pipe(map(resp => resp));
  }
  

