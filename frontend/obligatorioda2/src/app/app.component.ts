import { Component } from '@angular/core';
import {IdentityService} from "./identity.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isCollapsed = false;

  constructor(private service: IdentityService) {
  }

  isAdmin() {
    return this.service.roles.includes("Admin");
  }

  logout() {
    this.service.logout();
  }
}
