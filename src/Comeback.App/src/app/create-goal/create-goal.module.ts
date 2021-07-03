import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateGoalRoutingModule } from './create-goal-routing.module';
import { CreateGoalComponent } from './create-goal.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { GoalEditorModule } from '@shared';


@NgModule({
  declarations: [
    CreateGoalComponent
  ],
  imports: [
    CommonModule,
    CreateGoalRoutingModule,
    MatCardModule,
    MatButtonModule,
    GoalEditorModule
  ]
})
export class CreateGoalModule { }
