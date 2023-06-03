import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserService } from '../user.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent {
  users: any[] = [];

  constructor(private authService: AuthService, private userService: UserService , private router: Router, private location: Location) {}

  ngOnInit(): void {
    // Disable browser's back button
    window.addEventListener('popstate', () => {
      this.location.go(this.router.url);
    });
    // this.fetchUsers();
  }

  // fetchUsers() {
  //   //console.log(this.users)
  //   this.userService.getUsers().subscribe(
  //     (response) => {
  //       this.users = response.users;
  //     },
  //     (error) => {
  //       console.error('Failed to fetch users', error);
  //       // Handle the error
  //     }
  //   );
  // }

  logout(): void {
    // Add logout logic here
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
