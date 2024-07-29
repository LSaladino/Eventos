import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/layout/home/home.component';
import { ListeventComponent } from './components/listevent/listevent.component';
import { CustomerComponent } from './components/customer/customer.component';
import { EventtComponent } from './components/eventt/eventt/eventt.component';
import { SubscribeComponent } from './components/subscribe/subscribe.component';
import { authGuard } from './guard/account/shared/auth.guard';
import { AuthenticationComponent } from './components/layout/authentication/authentication.component';
import { LoginComponent } from './components/account/login/login.component';
import { CreateAccountComponent } from './components/account/create-account/create-account.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      { path: '', component: ListeventComponent },
      { path: '', component: CreateAccountComponent },
      { path: 'event', component: EventtComponent },
      { path: 'subscribe', component: SubscribeComponent }
    ],
    canActivate: [authGuard]
  },
  {
    path: '', component: AuthenticationComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'create-account', component: CreateAccountComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
