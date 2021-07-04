import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DailyMeasurementService, GoalService } from '@api';
import { forkJoin } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent  {

  public vm$ = forkJoin([
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
    })),
    tap(x => console.log(x))

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
    this._router.navigate(['create-goal']);
  }

}
