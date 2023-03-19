// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing.component';
import { MatButtonModule } from '@angular/material/button';

const routes: Routes = [{ path: '', component: LandingComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MatButtonModule
  ],
  exports: [RouterModule]
})
export class LandingRoutingModule { }

