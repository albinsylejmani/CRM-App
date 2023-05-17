import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder,private snackBar: MatSnackBar , private authService: AuthService) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      name: new FormControl('', [Validators.required])
    });
  }

  onRegister() {
    if (this.registerForm.invalid) {
      return;
    }

    const { email, password, name } = this.registerForm.value;
    this.authService.register(email, password, name).subscribe(
      response => {
        // Handle successful registration (e.g., show success message, redirect)
      },
      error => {
        // Handle registration error (e.g., show error message)
      }
    );
  }
}
