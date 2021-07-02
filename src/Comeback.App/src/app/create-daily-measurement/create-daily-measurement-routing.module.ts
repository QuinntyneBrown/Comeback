import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateDailyMeasurementComponent } from './create-daily-measurement.component';

const routes: Routes = [{ path: '', component: CreateDailyMeasurementComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateDailyMeasurementRoutingModule { }
