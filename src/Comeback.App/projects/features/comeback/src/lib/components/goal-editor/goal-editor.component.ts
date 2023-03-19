// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createGoalEditorViewModel } from './create-goal-editor-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-goal-editor',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './goal-editor.component.html',
  styleUrls: ['./goal-editor.component.scss']
})
export class GoalEditorComponent {
  public vm$ = createGoalEditorViewModel();
}
