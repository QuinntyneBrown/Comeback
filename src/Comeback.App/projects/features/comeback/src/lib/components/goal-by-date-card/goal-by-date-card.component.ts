// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createGoalByDateCardViewModel } from './create-goal-by-date-card-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-goal-by-date-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './goal-by-date-card.component.html',
  styleUrls: ['./goal-by-date-card.component.scss']
})
export class GoalByDateCardComponent {
  public vm$ = createGoalByDateCardViewModel();
}
