import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DailyMeasurementCardComponent } from './daily-measurement-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    DailyMeasurementCardComponent
  ],
  exports: [
    DailyMeasurementCardComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class DailyMeasurementCardModule { }
