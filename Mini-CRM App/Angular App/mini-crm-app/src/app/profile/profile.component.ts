import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorizationService } from '../authorization-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  userId: number;
  canViewProfile: boolean;
  canManageProfiles: boolean;

  constructor(
    private route: ActivatedRoute,
    private authorizationService: AuthorizationService
  ) {
    this.userId = +this.route.snapshot.params['id'];
    this.canViewProfile = this.authorizationService.canViewProfile(this.userId);
    this.canManageProfiles = this.authorizationService.canManageProfiles();
  }
}