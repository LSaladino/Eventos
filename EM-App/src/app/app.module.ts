import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/account/login/login.component';
import { CreateAccountComponent } from './components/account/create-account/create-account.component';
import { HomeComponent } from './components/layout/home/home.component';
import { AuthenticationComponent } from './components/layout/authentication/authentication.component';
import { MaterialModule } from './shared/material/material/material.module';
import { ToastrModule } from 'ngx-toastr';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog/confirm-dialog.component';
import { EventtComponent } from './components/eventt/eventt/eventt.component';
import { TitleComponent } from './components/title/title.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListeventComponent } from './components/listevent/listevent.component';
import { CustomerComponent } from './components/customer/customer.component';
import { SubscribeComponent } from './components/subscribe/subscribe.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './services/account/shared/interceptor/auth.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CreateAccountComponent,
    HomeComponent,
    AuthenticationComponent,
    ConfirmDialogComponent,
    EventtComponent,
    TitleComponent,
    ListeventComponent,
    CustomerComponent,
    SubscribeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    ToastrModule.forRoot({
      positionClass: 'toast-center-center',
      preventDuplicates: true,
      timeOut: 3000,
      easing: 'ease-in',
      easeTime: 1000
    }),
    ReactiveFormsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
