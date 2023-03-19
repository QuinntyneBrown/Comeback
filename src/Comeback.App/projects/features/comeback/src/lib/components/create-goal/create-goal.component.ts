// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createCreateGoalViewModel } from './create-create-goal-view-model';
import { PushModule } from '@ngrx/component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { GoalEditorComponent } from '../goal-editor';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-goal',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule, 
    PushModule,
    MatCardModule,
    MatButtonModule,
    GoalEditorComponent,
    ReactiveFormsModule
  ],
  templateUrl: './create-goal.component.html',
  styleUrls: ['./create-goal.component.scss']
})
export class CreateGoalComponent {
  public vm$ = createCreateGoalViewModel();
}
