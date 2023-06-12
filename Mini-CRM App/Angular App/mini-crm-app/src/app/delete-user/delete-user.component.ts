import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../user.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';


@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {
  user!: User;
  @ViewChild('userForm') userForm!: NgForm;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    const userId = this.route.snapshot.params['id'];
    this.getUser(userId);
    //this.deleteUser(userId);
  }

  getUser(userId: string) {
    console.log('Fetching user with ID:', userId);
  
    this.userService.getUserById(userId).subscribe(
      (user: User) => {
        console.log('User data:', user);
        this.user = user;
      },
      (error) => {
        console.error('Error fetching user:', error);
      }
    );
  }

  deleteUser(): void {
    const userId = String(this.user.id);
    this.userService.deleteUser(userId, this.user).subscribe(
      () => {
        console.log('User deleted successfully.');
        // Perform any additional actions or update the UI as needed
      },
      (error: any) => {
        console.error('Error deleting user:', error);
        // Handle the error and display an appropriate message to the user
      }
    );
  }

}
