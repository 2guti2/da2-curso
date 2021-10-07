import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomButtonComponent } from './button/custom-button.component';
import { NzButtonModule } from "ng-zorro-antd/button";

@NgModule({
  declarations: [
    CustomButtonComponent
  ],
  exports: [
    CustomButtonComponent
  ],
  imports: [
    CommonModule,
    NzButtonModule
  ]
})
export class ComponentsModule { }
