// AuthorizationService
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  constructor(private authService: AuthService) {}

  canViewProfile(userId: number): boolean {
    const authenticatedUser = this.authService.getAuthenticatedUser();

    // Check if the user is authenticated and has the necessary role
    if (authenticatedUser && authenticatedUser.role === 'User') {
      // User can only view their own profile
      return authenticatedUser.id === userId;
    }

    // User is not authenticated or does not have the necessary role
    return false;
  }

  canManageProfiles(): boolean {
    const authenticatedUser = this.authService.getAuthenticatedUser();

    // Check if the user is authenticated and has the necessary role
    return authenticatedUser !== undefined && authenticatedUser.role === 'Administrator';
  }
}
