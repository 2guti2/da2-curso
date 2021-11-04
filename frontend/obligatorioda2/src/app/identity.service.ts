import { Injectable } from '@angular/core';
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  constructor(private router: Router) {
  }

  get roles(): string {
    return localStorage.getItem("roles") || "member";
  }

  get isLoggedIn(): boolean {
    return !!localStorage.getItem("token");
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/'])
  }
}
