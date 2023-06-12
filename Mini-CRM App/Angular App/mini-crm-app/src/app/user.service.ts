import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7015/api';
  private apiUrl2 = 'https://localhost:7015/api/users';

  constructor(private http: HttpClient,private router: Router) {}

  getUsers(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/users`);
  }
  getUserById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl2}/${id}`);
  }
  updateUser(id: string, updatedUser: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/users/${id}`, updatedUser);
  }
  deleteUser(id: string, deletedUser: User): Observable<User> {
    return this.http.delete<User>(`${this.apiUrl}/users/${id}`, {body: deletedUser});
  }
}
