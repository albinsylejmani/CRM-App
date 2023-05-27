import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { last } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder,private snackBar: MatSnackBar ,private router: Router , private authService: AuthService) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required])
    });
  }

  onRegister() {
    const { email, password, firstname, lastname} = this.registerForm.value;
    
    this.authService.register(email, password, firstname, lastname).subscribe(
      (response) => {
        // Handle successful register
        console.log('Register successful', response);
        this.router.navigate(['/']);
      },
      (error) => {
        // Handle register error
        console.error('Register failed', error);
        
      }
    );
  }
}
