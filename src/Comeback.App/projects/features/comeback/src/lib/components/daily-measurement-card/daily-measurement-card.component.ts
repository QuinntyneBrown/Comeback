// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PushModule } from '@ngrx/component';
import { DailyMeasurement } from '../../models';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-daily-measurement-card',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule, 
    PushModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './daily-measurement-card.component.html',
  styleUrls: ['./daily-measurement-card.component.scss']
})
export class DailyMeasurementCardComponent {
  @Input() public dailyMeasurement!:DailyMeasurement;
  @Output() public edit = new EventEmitter();
  @Output() public delete = new EventEmitter();
}
