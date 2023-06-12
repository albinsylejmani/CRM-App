import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../user.model';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user!: User;
  @ViewChild('userForm') userForm!: NgForm;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const userId = this.route.snapshot.params['id'];
    this.getUser(userId);
  }

  getUser(id: string): void {
    this.userService.getUserById(id).subscribe(
      (response: any) => {
        this.user = response;
      },
      (error: any) => {
        console.error('Error retrieving user:', error);
      }
    );
  }
  showSuccess(): void {
    this.toastr.success('Message Success!', 'Title Success!');
  }

  saveUser(): void {
    const userId = String(this.user.id);
    this.userService.updateUser(userId, this.user).subscribe(
      (response: any) => {
        console.log('User updated successfully');
        this.router.navigate(['/landingpage']);
      },
      (error) => {
        console.error('Failed to update user', error);
        // Handle the error
      }
    );
  }
}