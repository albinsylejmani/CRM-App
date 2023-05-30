// AuthService

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7015/api';
  private authenticated: boolean = false;

  constructor(private http: HttpClient, private router: Router) {}

  register(email: string, password: string, firstname: string, lastname: string): Observable<any> {
    const user = { email, password, firstname, lastname };
    return this.http.post(`${this.apiUrl}/register`, user, { responseType: 'text' }).pipe(
      catchError((error) => {
        console.error('An error occurred:', error);
        return throwError('Registration failed'); // Customize the error message as needed
      })
    );
  }

  isAuthenticated(): boolean {
    return this.authenticated;
  }

  logout(): void {
    // Perform necessary logout actions (e.g., clearing tokens, resetting variables)
    this.authenticated = false;
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

  // Call this method when the user successfully logs in
  setAuthenticated() {
    this.authenticated = true;
  }
}
