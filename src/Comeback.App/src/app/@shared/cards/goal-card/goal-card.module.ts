import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalCardComponent } from './goal-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    GoalCardComponent
  ],
  exports: [
    GoalCardComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class GoalCardModule { }
