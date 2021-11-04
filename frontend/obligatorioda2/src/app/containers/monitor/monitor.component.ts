import {Component} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators} from "@angular/forms";
import {Observable, Observer} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-monitor',
  templateUrl: './monitor.component.html',
  styleUrls: ['./monitor.component.scss']
})
export class MonitorComponent {
  form: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.form = this.fb.group(
      {
        name: [
          '', // default value
          {
            updateOn: 'blur',
            validators: [
              Validators.required,
              Validators.minLength(4),
              this.forbiddenNameValidator
            ],
            asyncValidators: [
              this.userNameAsyncValidator,
              this.userNameAsyncBackEndValidator
            ]
          }
        ],
      }
    );
  }

  forbiddenNameValidator(control: AbstractControl): ValidationErrors | null {
    if (control.value.toLowerCase() !== 'robert') {
      return null;
    } else {
      return {error: true, forbiddenName: true};
    }
  }

  userNameAsyncValidator = (control: FormControl) =>
    new Observable((observer: Observer<ValidationErrors | null>) => {
      setTimeout(() => {
        if (control.value === 'JasonWood') {
          // you have to return `{error: true}` to mark it as an error event
          observer.next({error: true, duplicated: true});
        } else {
          observer.next(null);
        }
        observer.complete();
      }, 1000);
    });

  userNameAsyncBackEndValidator = (control: FormControl) =>
    new Observable((observer: Observer<ValidationErrors | null>) => {
      this.http.get<any[]>(`http://localhost:5000/User?username=${control.value}`)
        .toPromise()
        .then((result) => {
          if (result.length) {
            observer.next({error: true, duplicated: true});
          } else {
            observer.next(null);
          }
          observer.complete();
        })
    });

  hasError(prop: string, error: string) {
    const actualProp = this.form?.get(prop);
    return actualProp?.touched && actualProp?.hasError(error)
  }

  hasAnyErrors(prop: string) {
    console.log(this.form?.get(prop)?.errors)
    const stuff : any = this.form?.get(prop)?.errors;
    const obj : any = stuff != null? stuff : {};
    return Object.keys(obj).length;
  }
}
