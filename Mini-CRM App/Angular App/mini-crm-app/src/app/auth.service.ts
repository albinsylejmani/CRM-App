import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7015/api';
  private authenticated: boolean = false;
  private storageKey = 'auth_token'; // Key for storing the authentication token in local storage
  private authenticatedUser: User | undefined; // Store the authenticated user

  constructor(private http: HttpClient, private router: Router) {
    // Check if the authentication token exists in local storage on initialization
    const storedToken = localStorage.getItem(this.storageKey);
    this.authenticated = !!storedToken;

    if (storedToken) {
      // Retrieve and decode the user information from the token
      const user = this.decodeUserFromToken(storedToken);
      this.authenticatedUser = user;
    }
  }

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
    // Clear the authentication token from local storage
    localStorage.removeItem(this.storageKey);
    // Perform necessary logout actions (e.g., clearing tokens, resetting variables)
    this.authenticated = false;
    this.authenticatedUser = undefined;
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

  setAuthenticated(token: string, user: User): void {
    // Set the authentication token in local storage
    localStorage.setItem(this.storageKey, token);
    this.authenticated = true;
    this.authenticatedUser = user;
    console.log('User authenticated:', this.authenticatedUser);
  }

  getAuthenticatedUser(): User | undefined {
    return this.authenticatedUser;
  }

  private decodeUserFromToken(token: string): User {
    // Decode and extract the user information from the token
    // Replace this with your own token decoding logic
    const decodedToken: any = {}; // Replace this with the actual decoding logic

    // Extract user properties from the decoded token
    const { id, name, role } = decodedToken;

    // Create a user object
    const user: User = {
      id,
      name,
      role
    };

    return user;
  }
}
