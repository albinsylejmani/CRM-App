import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7015';

  constructor(private http: HttpClient) {}

  register(email: string, password: string, name: string, lastname: string): Observable<any> {
    const user = { email, password, name, lastname };
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(email: string, password: string): Observable<any> {
    const user = { email, password };
    return this.http.post(`${this.apiUrl}/login`, user);
  }
}
