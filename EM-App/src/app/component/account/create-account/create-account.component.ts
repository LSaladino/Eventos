import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateAccount } from 'src/app/models/create-account/create-account';
import { AccountService } from 'src/app/services/account/shared/account.service';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  ngOnInit(): void {

  }

  constructor(private fb: FormBuilder,
    private accountService: AccountService
  ) {
    this.createAccountForm();
  }

  public CreateAccountForm!: FormGroup;
  public submitted: boolean = false;

  createAccount = new CreateAccount();

  createAccountForm() {
    this.CreateAccountForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: ['', [Validators.required]]
    });
  }

  onCreateAccount(createNewAccount: CreateAccount) {
    this.submitted = true;

    // if (this.CreateAccountForm.valid) {
    //   try {
    //     this.submitted = true;
    //     const result = await this.accountService.login(this.LoginForm);
    //     console.log(`Logged: ${result}`);
    //     this.router.navigate(['']);

    //   } catch (error) {
    //     console.error(error);
    //   }
    // }

    if (this.CreateAccountForm.valid) {
      this.accountService.register(createNewAccount).subscribe({
        next: (newAccount: CreateAccount) => {
          console.log("Conta criada =>" + newAccount);
        },
        error: (err) => {
          console.error("Erro na criação da conta => " + err);
        }
      })
    }
  }


}
