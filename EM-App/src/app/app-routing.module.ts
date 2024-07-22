import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/layout/home/home.component';
import { CustomerComponent } from './component/customer/customer.component';
import { SubscribeComponent } from './component/subscribe/subscribe.component';
import { EventComponent } from './component/event/event.component';
import { ListeventComponent } from './component/listevent/listevent.component';
import { AuthenticationComponent } from './component/layout/authentication/authentication.component';
import { LoginComponent } from './component/account/login/login.component';
import { CreateAccountComponent } from './component/account/create-account/create-account.component';
import { authGuard } from './guard/account/shared/auth.guard';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      { path: '', component: ListeventComponent },
      { path: 'customer', component: CustomerComponent },
      { path: 'event', component: EventComponent },
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
