import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizationGuard } from "./authorization.guard";

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./containers/welcome/welcome.module').then(m => m.WelcomeModule) },
  { path: 'monitor', loadChildren: () => import('./containers/monitor/monitor.module').then(m => m.MonitorModule) },
  { path: 'forecasts', loadChildren: () => import('./containers/forecasts/forecasts.module').then(m => m.ForecastsModule), canActivate: [AuthorizationGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
