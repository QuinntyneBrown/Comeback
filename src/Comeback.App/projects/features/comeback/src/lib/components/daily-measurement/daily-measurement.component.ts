// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createDailyMeasurementViewModel } from './create-daily-measurement-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-daily-measurement',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './daily-measurement.component.html',
  styleUrls: ['./daily-measurement.component.scss']
})
export class DailyMeasurementComponent {
  public vm$ = createDailyMeasurementViewModel();
}
