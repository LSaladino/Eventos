import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  
    const token = window.localStorage.getItem('authToken');
    const router: Router = inject(Router);
    console.log("I am in Auth Guard " + token);
    if (token) {
      return true;
    } else {
      router.navigate(['login']);
      return false;
    }
  };