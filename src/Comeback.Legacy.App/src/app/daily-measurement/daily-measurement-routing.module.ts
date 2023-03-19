// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateDailyMeasurementComponent } from './daily-measurement.component';

const routes: Routes = [{ path: '', component: CreateDailyMeasurementComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateDailyMeasurementRoutingModule { }

