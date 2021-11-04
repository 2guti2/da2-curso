import { NgModule } from '@angular/core';
import { ComponentsModule } from "../../components/components.module";
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NzFormModule} from "ng-zorro-antd/form";
import { NzInputModule } from 'ng-zorro-antd/input';
import { DemoNgZorroAntdModule } from '../monitor/ng-zorro-antd.module';


@NgModule({
  imports: [LoginRoutingModule, ComponentsModule, CommonModule, FormsModule, ReactiveFormsModule, NzFormModule, NzInputModule, DemoNgZorroAntdModule],
  declarations: [LoginComponent],
  exports: [LoginComponent]
})
export class LoginModule { }
