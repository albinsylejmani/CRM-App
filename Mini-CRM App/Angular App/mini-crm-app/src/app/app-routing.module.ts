import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { AuthGuard } from './AuthGuard.service';
import { LogoutComponent } from './logout/logout.component';
import { AuthService } from './auth.service';
import { CreateUserComponent } from './create-user/create-user.component';
import { UserViewComponent } from './user-view/user-view.component';
import { EditUserComponent } from './edit-user/edit-user.component';

const routes: Routes = [
  { path: 'homepage', component: HomepageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'landingpage', component: LandingPageComponent, canActivate: [AuthGuard] },
  { path: 'logout', component: LogoutComponent },
  { path: '', component: HomepageComponent }, // Add this redirect route
  { path: 'createuser', component: CreateUserComponent, canActivate: [AuthGuard] },
  { path: 'users/:id', component: UserViewComponent },
  { path: 'users/edit/:id', component: EditUserComponent,  canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthService, AuthGuard]
})
export class AppRoutingModule { }
