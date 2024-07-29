import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    private accountService: AccountService,
    private toastr: ToastrService
  ) {
    this.createAccountForm();
  }


  public CreateAccountForm!: FormGroup;
  public submitted: boolean = false;
  router: Router = inject(Router);

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

    if (this.CreateAccountForm.valid) {
      this.accountService.register(createNewAccount).subscribe({
        next: (data: CreateAccount) => {
          if (data.email != '') {
            this.toastr.info('Conta criada com sucesso !', 'EM Sytem');
            this.CreateAccountForm.reset();
            this.router.navigate(['login']);
          }
        },
        error: (err) => {
          this.toastr.error('Algo deu errado ! ' + err, 'EM Sytem');
        }
      })
    }
  }

}
