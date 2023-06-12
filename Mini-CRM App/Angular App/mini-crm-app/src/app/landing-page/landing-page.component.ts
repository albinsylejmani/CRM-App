import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { User } from '../user.model';

@Component({
  selector: 'app-homepage',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  users: any[] = [];
  lista: any[] = [];
  user!: User;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'role', 'actions'];
  // pageSizeOptions: number[] = [5, 10, 25];
  // pageSize: number = 10;
  // pageIndex: number = 0;
  // totalUsers: number = 0;

  // @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private userService: UserService,
    private router: Router,
    private location: Location) { }
  // Inside your component class
  sortColumn: string = ''; // Track the current sort column
  sortDirection: string = 'asc'; // Track the sort direction ('asc' or 'desc')

  ngOnInit() {
    this.fetchUsers();
    const userId = this.route.snapshot.params['id'];
    //this.getUser(userId);
    // this.deletedUser(userId);
  }



  getDisplayName(user: any): string {
    return user.firstName || user.lastName || '';
  }

  // this.totalUsers = this.users.length;
  // this.updatePaginator(); fetchUsers()
  fetchUsers() {
    this.userService.getUsers().subscribe(
      (response) => {
        this.users = response;
  
        // Retrieve getUserById for each user
        this.users.forEach((user) => {
          this.userService.getUserById(user.id).subscribe(
            (userDetails: User) => {
              // Update the user object with additional details if needed
              user.firstName = userDetails.firstName;
              user.lastName = userDetails.lastName;
              user.email = userDetails.email;
              // Update other properties as needed
            },
            (error) => {
              console.error('Error fetching user details:', error);
            }
          );
        });
  
        if (this.users.length > 0) {
          this.user = this.users[1]; // Assign the first user to this.user
        }
  
        console.log(this.users);
      },
      (error) => {
        console.error('Failed to fetch users', error);
        // Handle the error
      }
    );
  }


  // getUser(userId: string) {
  //   console.log('Fetching user with ID:', userId);
  //   this.userService.getUserById(userId).subscribe(
  //     (user: User) => {
  //       console.log('User data:', user);
  //       this.user = user;
  //     },
  //     (error: any) => {
  //       console.error('Error fetching user:', error);
  //     }
  //   );
  // }


  deleteUser(user: User): void {
    if (user && user.id) {
      const userId = String(user.id);
      console.log('Deleting user with ID:', userId);
      console.log('User data:', user);
  
      this.userService.deleteUser(userId, user).subscribe(
        () => {
          console.log('User deleted successfully.');
          // Perform any additional actions or update the UI as needed
        },
        (error: any) => {
          console.error('Error deleting user:', error);
          // Handle the error and display an appropriate message to the user
        }
      );
    } else {
      console.error('Invalid user data or ID.');
    }
  }



  logout(): void {
    // Add logout logic here
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  create(): void {
    this.router.navigate(['/createuser']);
  }

  userView(userId: string): void {
    this.router.navigate(['/users', userId]);
  }
  userEdit(id: string): void {
    this.router.navigate(['/users/edit', id,]);
  }
  // deleteView(id: string): void {
  //   this.router.navigate(['/users/delete/', id,]);
  // }

  // onPageChange(event: PageEvent): void {
  //   console.log('Event:', event);
  //   this.pageSize = event.pageSize;
  //   this.pageIndex = event.pageIndex;
  //   this.updatePaginator();
  // }

  // updatePaginator(): void {
  //   if (this.paginator) {
  //     this.paginator.pageIndex = this.pageIndex;
  //     this.paginator.pageSize = this.pageSize;
  //     this.paginator.length = this.totalUsers;
  //     this.paginator.page.emit();
  //   }
  // }
}
