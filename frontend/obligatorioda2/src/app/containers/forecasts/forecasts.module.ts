import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForecastsComponent } from './forecasts.component';
import { ForecastsRoutingModule } from "./forecasts-routing.module";
import { NzSpinModule } from "ng-zorro-antd/spin";

@NgModule({
  declarations: [
    ForecastsComponent
  ],
  imports: [
    CommonModule, ForecastsRoutingModule, NzSpinModule
  ],
  exports: [
    ForecastsComponent
  ]
})
export class ForecastsModule { }
