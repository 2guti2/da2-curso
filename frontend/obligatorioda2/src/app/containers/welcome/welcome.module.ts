import { NgModule } from '@angular/core';
import { WelcomeRoutingModule } from './welcome-routing.module';
import { WelcomeComponent } from './welcome.component';
import { ComponentsModule } from "../../components/components.module";
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [WelcomeRoutingModule, ComponentsModule, CommonModule],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent]
})
export class WelcomeModule { }
