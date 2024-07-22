import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './component/account/login/login.component';
import { CreateAccountComponent } from './component/account/create-account/create-account.component';
import { HomeComponent } from './component/layout/home/home.component';
import { AuthenticationComponent } from './component/layout/authentication/authentication.component';
import { CustomerComponent } from './component/customer/customer.component';
import { SubscribeComponent } from './component/subscribe/subscribe.component';
import { EventComponent } from './component/event/event.component';
import { ListeventComponent } from './component/listevent/listevent.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthInterceptor } from './services/account/shared/auth.interceptor';
import { ConfirmDialogComponent } from './component/confirm-dialog/confirm-dialog/confirm-dialog.component';
import { ToastrModule } from 'ngx-toastr';
import { TitleComponent } from './component/title/title.component';
import { MaterialModule } from './share/material/material/material.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CreateAccountComponent,
    HomeComponent,
    AuthenticationComponent,
    CustomerComponent,
    SubscribeComponent,
    ListeventComponent,
    ConfirmDialogComponent,
    TitleComponent,
    EventComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ToastrModule.forRoot({
      positionClass: 'toast-center-center',
      preventDuplicates:true,
      timeOut:3000,
      easing:'ease-in',
      easeTime:1000
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
