import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: 'homepage.component.html',
  styleUrls: ['homepage.component.css']
})
export class HomepageComponent {
  constructor(private router: Router) {}

  onLogin(): void {
    // Redirect to the login page
    this.router.navigate(['/login']);
  }

  onRegister(): void {
    // Redirect to the register page
    this.router.navigate(['/register']);
  }

  onViewContacts(): void {
    // Redirect to the contacts page
    this.router.navigate(['/contacts']);
  }

  onViewTasks(): void {
    // Redirect to the tasks page
    this.router.navigate(['/tasks']);
  }

  onViewReports(): void {
    // Redirect to the reports page
    this.router.navigate(['/reports']);
  }
}
