import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateGoalRoutingModule } from './create-goal-routing.module';
import { CreateGoalComponent } from './create-goal.component';


@NgModule({
  declarations: [
    CreateGoalComponent
  ],
  imports: [
    CommonModule,
    CreateGoalRoutingModule
  ]
})
export class CreateGoalModule { }
