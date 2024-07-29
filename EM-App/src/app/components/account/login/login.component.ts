import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateAccount } from 'src/app/models/create-account/create-account';
import { Login } from 'src/app/models/login/login';
import { AccountService } from 'src/app/services/account/shared/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router) {

    this.createLoginForm();

  }

  ngOnInit(): void {

  }

  public LoginForm!: FormGroup;
  public submitted: boolean = false;

 user = new Login();

  createLoginForm() {
    this.LoginForm = this.fb.group({
      email: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: ['', [Validators.required]]
    });
  }

  onLogin(user: Login) {
    this.submitted = true;

    if (this.LoginForm.valid) {
      this.accountService.login(user).subscribe({
        next: (token: string) => {
          localStorage.setItem('authToken', token);
          this.router.navigate(['']);
        },
        error: (err) => {
          console.log(`GET => Error Login: ${err}`);
        }
      })
    }
  }

  onRegister(createAccount: CreateAccount) {
    this.submitted = true;

    if (this.LoginForm.valid) {
      this.accountService.register(createAccount).subscribe({
        next: (obj: any) => {
          console.log(`Usuario registrado ${obj}`);
        },
        error: (err) => {
          console.log(`GET => Error Login: ${err}`);
        }
      })
    }
  }

  createAccount(account: any) {
    return new Promise((resolve) => {
      resolve(true);
    })
  }


}
