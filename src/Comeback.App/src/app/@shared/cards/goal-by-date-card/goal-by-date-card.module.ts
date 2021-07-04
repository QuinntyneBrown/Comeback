import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalByDateCardComponent } from './goal-by-date-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { DailyMeasurementCardModule } from '../daily-measurement-card';
import { GoalCardModule } from '../goal-card';



@NgModule({
  declarations: [
    GoalByDateCardComponent
  ],
  exports: [
    GoalByDateCardComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    DailyMeasurementCardModule,
    GoalCardModule
  ]
})
export class GoalByDateCardModule { }
