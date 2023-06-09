import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../user.model';
// Import other necessary components and services

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user!: User;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
    // Inject other necessary services
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

  // saveUser(): void {
  //   this.userService.updateUser(this.user.id, this.user).subscribe(
  //     (response: any) => {
  //       console.log('User updated successfully');
  //       // Redirect to the user details page or any other desired location
  //       this.router.navigate(['/users', this.user.id]);
  //     },
  //     (error) => {
  //       console.error('Failed to update user', error);
  //       // Handle the error
  //     }
  //   );
  // }

  // updateUser(): void {
  //   const userId = String(this.user.id);
  //   this.userService.updateUser(userId, this.user).subscribe(
  //     (response: any) => {
  //       // User updated successfully
  //       console.log('User updated:', response);
  //       // Redirect to the user details page or any other appropriate page
  //       this.router.navigate(['/user', this.user.id]);
  //     },
  //     (error: any) => {
  //       console.error('Error updating user:', error);
  //     }
  //   );
  // }

  // Add other methods as needed
}