// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, Input, OnInit } from '@angular/core';
import { Goal } from '@api';

@Component({
  selector: 'app-goal-card',
  templateUrl: './goal-card.component.html',
  styleUrls: ['./goal-card.component.scss']
})
export class GoalCardComponent  {
  @Input() goal: Goal;
}

