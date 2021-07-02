import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateDailyMeasurementRoutingModule } from './create-daily-measurement-routing.module';
import { CreateDailyMeasurementComponent } from './create-daily-measurement.component';
import { DailyMeasurementEditorModule } from '@shared';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CreateDailyMeasurementComponent
  ],
  imports: [
    CommonModule,
    CreateDailyMeasurementRoutingModule,
    DailyMeasurementEditorModule,
    MatButtonModule,
    ReactiveFormsModule
  ]
})
export class CreateDailyMeasurementModule { }
