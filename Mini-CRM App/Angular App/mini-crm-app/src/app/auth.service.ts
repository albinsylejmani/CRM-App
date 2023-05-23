import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'your-api-url';

  constructor(private http: HttpClient) {}

  register(email: string, password: string, name: string): Observable<any> {
    const user = { email, password, name };
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(email: string, password: string): Observable<any> {
    const user = { email, password };
    return this.http.post(`${this.apiUrl}/login`, user);
  }
  // logout(): Observable<any> {
  //   return this.http.post(`${this.apiUrl}/logout`, null);
  // }
  // isLoggedIn(): boolean {
  //   // Check if the user is logged in based on your authentication mechanism (e.g., token presence)
  //   // Return true or false accordingly
  // }
  // getUserInfo(): Observable<any> {
  //   return this.http.get(`${this.apiUrl}/user`);
  // }
}
