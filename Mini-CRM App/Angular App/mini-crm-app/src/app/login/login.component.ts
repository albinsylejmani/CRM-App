import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  errorMessage: string = '';

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    // Check if the user is already authenticated
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/landingpage']);
    } else {
      this.buildLoginForm();
    }
  }

  goToRegister(event: Event) {
    event.preventDefault(); // Prevent the default anchor tag behavior
    this.router.navigate(['/register']); // Navigate to the register page
  }
  

  buildLoginForm(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onLogin(): void {
    const { email, password } = this.loginForm.value;

    this.authService.login(email, password).subscribe(
      (response) => {
        // Handle successful login
        const { token, user } = response;
        this.authService.setAuthenticated(token, user);
        this.router.navigate(['/landingpage']);
      },
      (error) => {
        // Handle login error
        console.error('Login failed', error);
        this.errorMessage = 'Invalid email or password'; // Set the error message to be displayed
      }
    );
  }
}
