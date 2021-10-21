import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForecastsComponent } from './forecasts.component';

const routes: Routes = [
  { path: '', component: ForecastsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForecastsRoutingModule { }
