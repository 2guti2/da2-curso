import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  validateForm!: FormGroup;

  async submitForm(): Promise<void> {
    for (const i in this.validateForm.controls) {
      if (this.validateForm.controls.hasOwnProperty(i)) {
        this.validateForm.controls[i].markAsDirty();
        this.validateForm.controls[i].updateValueAndValidity();
      }
    }

    if (!this.validateForm.valid) {
      return;
    }

    const body = {
      username: this.username,
      password: this.password
    }

    try {
      const result: any = await this.http.post('http://localhost:5000/Session', body).toPromise();
      console.log(result);
      localStorage.setItem("username", result.username);
      localStorage.setItem("token", result.token);
      localStorage.setItem("userId", result.id);
      localStorage.setItem("roles", result.roles);
      alert("login successful")
      this.router.navigate(['/welcome']);
    } catch (e) {
      alert("bad login")
    }
  }

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  get username(): string {
    return this.validateForm.controls["userName"].value;
  }

  get password(): string {
    return this.validateForm.controls["password"].value;
  }
}
