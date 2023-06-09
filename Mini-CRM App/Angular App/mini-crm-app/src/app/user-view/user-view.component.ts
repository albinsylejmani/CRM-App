import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { User } from '../user.model';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {
  user!: User;
  users: any[] = [];
  lista: any[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'role', 'actions'];
  constructor(private route: ActivatedRoute, private authService: AuthService, private userService: UserService , private router: Router, private location: Location) { }

  ngOnInit(): void {
     const userId = this.route.snapshot.paramMap.get('id');
     if (userId !== null) {
       this.fetchUserById(userId);
     } else {
       // Handle the case where userId is null
       console.error('User ID is null');
     }
    }

  fetchUserById(userId: string) {
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

}
