// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateGoalRoutingModule } from './create-goal-routing.module';
import { CreateGoalComponent } from './create-goal.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { GoalEditorModule } from '@shared';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CreateGoalComponent
  ],
  imports: [
    CommonModule,
    CreateGoalRoutingModule,
    MatCardModule,
    MatButtonModule,
    GoalEditorModule,
    ReactiveFormsModule
  ]
})
export class CreateGoalModule { }

