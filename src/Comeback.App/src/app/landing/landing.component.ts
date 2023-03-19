// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DailyMeasurement, DailyMeasurementService, GoalService } from '@api';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent  {

  readonly vm$ = combineLatest([
    this._dailyMeasurementService.get(),
    this._goalService.get(),
    this._goalService.getToday(),
    this._dailyMeasurementService.getToday()
  ])
  .pipe(
    map(([dailyMeasurements, goals, goalToday, dailyMeasurementToday]) => ({
      dailyMeasurements,
      goals,
      goalToday,
      dailyMeasurementToday
    }))
  );

  constructor(
    private readonly _dailyMeasurementService: DailyMeasurementService,
    private readonly _goalService: GoalService,
    private readonly _router: Router
  ) { }

  create(): void {
    this._router.navigate(['create']);
  }

  createGoal(): void {
    this._router.navigate(['goal','create']);
  }

  handleEdit($event: DailyMeasurement) {
    this._router.navigate(['edit',$event.dailyMeasurementId]);
  }

  handleDelete(dailyMeasurement: DailyMeasurement) {
    alert("?");

    this._dailyMeasurementService.remove({ dailyMeasurement })
    .subscribe();
  }
}

