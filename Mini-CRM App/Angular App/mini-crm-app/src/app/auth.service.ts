import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7015/api';

  constructor(private http: HttpClient) {}

  register(email: string, password: string, firstname: string, lastname: string): Observable<any> {
    const user = { email, password, firstname, lastname };
    return this.http.post(`${this.apiUrl}/register`, user, { responseType: 'text' }).pipe(
      catchError((error) => {
        console.error('An error occurred:', error);
        return throwError('Registration failed'); // Customize the error message as needed
      })
    );
  }

  login(email: string, password: string): Observable<any> {
    const user = { email, password };
    return this.http.post(`${this.apiUrl}/login`, user, { responseType: 'text' }).pipe(
      catchError((error) => {
        console.error('An error occurred:', error);
        return throwError('Login failed'); // Customize the error message as needed
      })
    );
  }
}
