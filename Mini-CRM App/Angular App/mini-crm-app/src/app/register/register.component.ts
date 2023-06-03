import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/landingpage']);
    }

    this.registerForm = this.fb.group({
      // Initialize the form controls
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      role: ['', Validators.required]
    });
  }

  onRegister() {
    if (this.registerForm.invalid) {
      return;
    }
  
    const { email, password, firstname, lastname, role } = this.registerForm.value;
  
    this.authService.register(email, password, firstname, lastname, role).subscribe(
      (response) => {
        // Handle successful registration
        this.router.navigate(['/login']); // Redirect to the desired page after successful registration
      },
      (error) => {
        // Handle registration error
        console.error('Registration failed', error);
        this.errorMessage = 'Registration failed. Email already exist'; // Display an appropriate error message to the user
      }
    );
  }
}
