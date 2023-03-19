// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DailyMeasurement, Goal } from '@api';

@Component({
  selector: 'app-goal-by-date-card',
  templateUrl: './goal-by-date-card.component.html',
  styleUrls: ['./goal-by-date-card.component.scss']
})
export class GoalByDateCardComponent {

  @Output() editClick: EventEmitter<DailyMeasurement> = new EventEmitter();

  @Input() goal: Goal;

  @Input() dailyMeasurement: DailyMeasurement;

}

