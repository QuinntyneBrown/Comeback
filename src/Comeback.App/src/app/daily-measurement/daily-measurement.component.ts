import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DailyMeasurement } from '@api';
import { DailyMeasurementService } from '@api/services';
import { Destroyable, NavigationService } from '@core';
import { of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-daily-measurement',
  templateUrl: './daily-measurement.component.html',
  styleUrls: ['./daily-measurement.component.scss']
})
export class CreateDailyMeasurementComponent extends Destroyable  {
  
  formControl = new FormControl();

  vm$ = this._activatedRoute.paramMap
  .pipe(
    map(paramMap => paramMap.get("id")),
    switchMap(dailyMeasurementId => {
      return dailyMeasurementId ? this._dailyMeasurementService.getById({ dailyMeasurementId })
        : of(null);
    }),
    map(dailyMeasurement => {
      return {
        formControl: new FormControl(dailyMeasurement,[])
      }
    })
  )

  constructor(
    private readonly _dailyMeasurementService: DailyMeasurementService,
    private readonly _navigationService: NavigationService,
    private readonly _activatedRoute: ActivatedRoute
  ) { 
    super();
  }

  save(dailyMeasurement: DailyMeasurement): void {

    const obs$ = dailyMeasurement.dailyMeasurementId
    ? this._dailyMeasurementService.update({ dailyMeasurement})
    : this._dailyMeasurementService.create({
      dailyMeasurement
    });

    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._navigationService.redirectToDefault())
    )
    .subscribe();
  }

  cancel() {
    this._navigationService.redirectToDefault();
  }
}
