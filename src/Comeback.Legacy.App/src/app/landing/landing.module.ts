// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { MatButtonModule } from '@angular/material/button';
import { DailyMeasurementCardModule, GoalByDateCardModule, GoalCardModule } from '@shared';

@NgModule({
  declarations: [
    LandingComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    MatButtonModule,
    DailyMeasurementCardModule,
    GoalCardModule,
    GoalByDateCardModule
  ]
})
export class LandingModule { }

