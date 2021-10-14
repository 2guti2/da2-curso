import { NgModule } from '@angular/core';
import { ComponentsModule } from "../../components/components.module";
import { CommonModule } from '@angular/common';
import { MonitorComponent } from './monitor.component';
import { MonitorRoutingModule } from './monitor-routing.module';

@NgModule({
  imports: [MonitorRoutingModule, ComponentsModule, CommonModule],
  declarations: [MonitorComponent],
  exports: [MonitorComponent]
})
export class MonitorModule { }
