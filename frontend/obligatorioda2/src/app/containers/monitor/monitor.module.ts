import { NgModule } from '@angular/core';
import { ComponentsModule } from "../../components/components.module";
import { CommonModule } from '@angular/common';
import { MonitorComponent } from './monitor.component';
import { MonitorRoutingModule } from './monitor-routing.module';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NzFormModule} from "ng-zorro-antd/form";
import { NzInputModule } from 'ng-zorro-antd/input';
import { DemoNgZorroAntdModule } from './ng-zorro-antd.module';


@NgModule({
  imports: [MonitorRoutingModule, ComponentsModule, CommonModule, FormsModule, ReactiveFormsModule, NzFormModule, NzInputModule, DemoNgZorroAntdModule],
  declarations: [MonitorComponent],
  exports: [MonitorComponent]
})
export class MonitorModule { }
