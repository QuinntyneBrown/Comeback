// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { createDailyMeasurementViewModel } from './create-daily-measurement-view-model';
import { PushModule } from '@ngrx/component';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { DailyMeasurementEditorComponent } from '../daily-measurement-editor';

@Component({
  selector: 'app-daily-measurement',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule, 
    PushModule,
    MatCardModule,
    ReactiveFormsModule,
    MatButtonModule,
    DailyMeasurementEditorComponent
  ],
  templateUrl: './daily-measurement.component.html',
  styleUrls: ['./daily-measurement.component.scss']
})
export class DailyMeasurementComponent {
  public vm$ = createDailyMeasurementViewModel();
}
