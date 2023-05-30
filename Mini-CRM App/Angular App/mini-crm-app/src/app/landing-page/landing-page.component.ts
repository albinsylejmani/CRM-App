import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-homepage',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent {
  constructor(private authService: AuthService, private router: Router, private location: Location) {}

  ngOnInit(): void {
    // Disable browser's back button
    window.addEventListener('popstate', () => {
      this.location.go(this.router.url);
    });
  }

  logout(): void {
    // Add logout logic here
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
