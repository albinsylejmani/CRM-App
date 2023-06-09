import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  userForm!: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      // Handle user authentication if needed
    }

    this.userForm = this.fb.group({
      // Initialize the form controls
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      role: ['', Validators.required]
    });
  }

  onCreate() {
    if (this.userForm.invalid) {
      return;
    }

    const { email, password, firstname, lastname, role } = this.userForm.value;

    this.authService.createUser(email, password, firstname, lastname, role).subscribe(
      (response) => {
        console.log('User created successfully:', response);
        this.router.navigate(['/landingpage']);
      },
      (error) => {
        console.error('Failed to create user:', error);
        this.errorMessage = 'Registration failed. Email already exists.';
      }
    );
  }
}
