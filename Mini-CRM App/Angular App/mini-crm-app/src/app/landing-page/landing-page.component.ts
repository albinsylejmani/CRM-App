import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-homepage',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  users: any[] = [];
  displayedColumns: string[] = ['firstName', 'email', 'role', 'actions'];
  // pageSizeOptions: number[] = [5, 10, 25];
  // pageSize: number = 10;
  // pageIndex: number = 0;
  // totalUsers: number = 0;

  // @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private authService: AuthService, private userService: UserService , private router: Router, private location: Location) {}

  ngOnInit(): void {
    // Disable browser's back button
    window.addEventListener('popstate', () => {
      this.location.go(this.router.url);
    });
     this.fetchUsers();
    //  this.updatePaginator();
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
}
