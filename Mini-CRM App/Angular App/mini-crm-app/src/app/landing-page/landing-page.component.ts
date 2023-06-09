import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { ActivatedRoute ,Router } from '@angular/router';
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
    private route: ActivatedRoute ,
    private authService: AuthService, 
    private userService: UserService , 
    private router: Router, 
    private location: Location) {}
// Inside your component class
sortColumn: string = ''; // Track the current sort column
sortDirection: string = 'asc'; // Track the sort direction ('asc' or 'desc')

  ngOnInit(): void {
    this.fetchUsers();
    const userId = this.route.snapshot.paramMap.get('id');
  }

  getDisplayName(user: any): string {
    return user.firstName || user.lastName || '';
  }


  fetchUsers() {
    this.userService.getUsers().subscribe(
      (response) => {
        this.users = response;
        // this.totalUsers = this.users.length;
        // this.updatePaginator();
        //console.log(this.users)
      },
      (error) => {
        console.error('Failed to fetch users', error);
        // Handle the error
      }
    );
  }

  fetchUserById(userId: string) {
    this.userService.getUserById(userId).subscribe(
      (user: User) => {
        this.user = user;
        console.log(this.user)
        this.router.navigate(['/users', userId]);
      },
      (error) => {
        console.error(error);
        // Handle the error
      }
    );
  }

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



  logout(): void {
    // Add logout logic here
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  create() : void {
    this.router.navigate(['/createuser']);
  }

  userView(userId: string): void {
    this.router.navigate(['/users',userId]);
  }
  userEdit(id: string): void {
    this.router.navigate(['/users/edit', id,]);
  }
}
