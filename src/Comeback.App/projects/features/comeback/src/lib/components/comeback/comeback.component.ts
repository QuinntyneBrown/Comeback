// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createComebackViewModel } from './create-comeback-view-model';
import { PushModule } from '@ngrx/component';
import { MatButtonModule } from '@angular/material/button';
import { GoalCardComponent } from '../goal-card';
import { GoalByDateCardComponent } from '../goal-by-date-card';
import { DailyMeasurementCardComponent } from '../daily-measurement-card';

@Component({
  selector: 'app-comeback',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule, 
    PushModule,
    MatButtonModule,
    GoalCardComponent,
    GoalByDateCardComponent,
    DailyMeasurementCardComponent
  ],
  templateUrl: './comeback.component.html',
  styleUrls: ['./comeback.component.scss']
})
export class ComebackComponent {
  public vm$ = createComebackViewModel();
}
