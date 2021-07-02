import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalCardComponent } from './goal-card.component';



@NgModule({
  declarations: [
    GoalCardComponent
  ],
  exports: [
    GoalCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class GoalCardModule { }
