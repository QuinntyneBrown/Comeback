// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PushModule } from '@ngrx/component';
import { DailyMeasurementCardComponent } from '../daily-measurement-card';
import { GoalCardComponent } from '../goal-card';
import { DailyMeasurement, Goal } from '../../models';

@Component({
  selector: 'app-goal-by-date-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule, 
    PushModule,
    DailyMeasurementCardComponent,
    GoalCardComponent
  ],
  templateUrl: './goal-by-date-card.component.html',
  styleUrls: ['./goal-by-date-card.component.scss']
})
export class GoalByDateCardComponent {
  @Output() public editClick = new EventEmitter();
  @Input() public dailyMeasurement!:DailyMeasurement;
  @Input() public goal!:Goal;
}
