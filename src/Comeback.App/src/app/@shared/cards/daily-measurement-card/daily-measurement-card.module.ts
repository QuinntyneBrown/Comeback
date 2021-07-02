import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DailyMeasurementCardComponent } from './daily-measurement-card.component';



@NgModule({
  declarations: [
    DailyMeasurementCardComponent
  ],
  exports: [
    DailyMeasurementCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DailyMeasurementCardModule { }
