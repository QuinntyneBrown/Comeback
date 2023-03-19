// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createGoalCardViewModel } from './create-goal-card-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-goal-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './goal-card.component.html',
  styleUrls: ['./goal-card.component.scss']
})
export class GoalCardComponent {
  public vm$ = createGoalCardViewModel();
}
