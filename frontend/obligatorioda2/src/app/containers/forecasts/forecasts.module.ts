import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForecastsComponent } from './forecasts.component';
import { ForecastsRoutingModule } from "./forecasts-routing.module";
import { NzSpinModule } from "ng-zorro-antd/spin";
import { NzIconModule } from 'ng-zorro-antd/icon';
import { ComponentsModule } from "../../components/components.module";

@NgModule({
  declarations: [
    ForecastsComponent
  ],
  imports: [
    CommonModule, ForecastsRoutingModule, NzSpinModule, NzIconModule, ComponentsModule
  ],
  exports: [
    ForecastsComponent
  ]
})
export class ForecastsModule { }
