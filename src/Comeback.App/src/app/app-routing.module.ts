import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "landing" },
  { path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
  { path: 'create', loadChildren: () => import('./create-daily-measurement/create-daily-measurement.module').then(m => m.CreateDailyMeasurementModule) },
  { path: 'create-goal', loadChildren: () => import('./create-goal/create-goal.module').then(m => m.CreateGoalModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
