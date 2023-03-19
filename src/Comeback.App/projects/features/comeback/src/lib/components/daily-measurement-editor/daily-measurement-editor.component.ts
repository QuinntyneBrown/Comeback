// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createDailyMeasurementEditorViewModel } from './create-daily-measurement-editor-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-daily-measurement-editor',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './daily-measurement-editor.component.html',
  styleUrls: ['./daily-measurement-editor.component.scss']
})
export class DailyMeasurementEditorComponent {
  public vm$ = createDailyMeasurementEditorViewModel();
}
