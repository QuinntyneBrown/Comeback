import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { MatButtonModule } from '@angular/material/button';
import { DailyMeasurementCardModule } from '@shared';

@NgModule({
  declarations: [
    LandingComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    MatButtonModule,
    DailyMeasurementCardModule
  ]
})
export class LandingModule { }
