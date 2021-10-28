import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {IdentityService} from "./identity.service";

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {
  constructor(private identityService: IdentityService, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {
    console.log(route.routeConfig?.path);
    if (this.identityService.role == "admin") {
      return true;
    }
    this.router.navigate(['/monitor']);
    return false;
  }

}
