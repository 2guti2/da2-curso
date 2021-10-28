import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  get role(): string {
    return localStorage.getItem("role") || "member";
  }
}
