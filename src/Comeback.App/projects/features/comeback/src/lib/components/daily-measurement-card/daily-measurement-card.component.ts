// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createDailyMeasurementCardViewModel } from './create-daily-measurement-card-view-model';
import { PushModule } from '@ngrx/component';

@Component({
  selector: 'app-daily-measurement-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule, PushModule],
  templateUrl: './daily-measurement-card.component.html',
  styleUrls: ['./daily-measurement-card.component.scss']
})
export class DailyMeasurementCardComponent {
  public vm$ = createDailyMeasurementCardViewModel();
}
