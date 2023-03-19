// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateDailyMeasurementRoutingModule } from './daily-measurement-routing.module';
import { CreateDailyMeasurementComponent } from './daily-measurement.component';
import { DailyMeasurementEditorModule } from '@shared';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    CreateDailyMeasurementComponent
  ],
  imports: [
    CommonModule,
    CreateDailyMeasurementRoutingModule,
    DailyMeasurementEditorModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatCardModule
  ]
})
export class DailyMeasurementModule { }

