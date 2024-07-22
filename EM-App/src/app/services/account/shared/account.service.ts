import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { CreateAccount } from 'src/app/models/create-account/create-account';
import { Login } from 'src/app/models/login/login';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = `${environment.ApiURL}/user`;

  constructor(private http: HttpClient) { }

  login(login: Login): Observable<string> {
    return this.http.post(`${this.baseUrl}/auth`, login, {
      responseType: 'text'
    })
  }

  register(createAccount: CreateAccount): Observable<CreateAccount> {
    return this.http.post<any>(`${this.baseUrl}/register`, createAccount)
  }

}