import { Component, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DailyMeasurement } from '@api';
import { DailyMeasurementService } from '@api/services';
import { NavigationService } from '@core';
import { of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-daily-measurement',
  templateUrl: './daily-measurement.component.html',
  styleUrls: ['./daily-measurement.component.scss']
})
export class CreateDailyMeasurementComponent implements OnDestroy  {

  private readonly _destoryed$: Subject<void> = new Subject();

  public formControl = new FormControl();

  public vm$ = this._activatedRoute.paramMap
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
  ) { }

  public save(dailyMeasurement: DailyMeasurement): void {

    const obs$ = dailyMeasurement.dailyMeasurementId
    ? this._dailyMeasurementService.update({ dailyMeasurement})
    : this._dailyMeasurementService.create({
      dailyMeasurement
    });

    obs$
    .pipe(
      takeUntil(this._destoryed$),
      tap(_ => this._navigationService.redirectToDefault())
    )
    .subscribe();
  }

  public cancel() {
    this._navigationService.redirectToDefault();
  }

  public ngOnDestroy() {
    this._destoryed$.next();
    this._destoryed$.complete();
  }
}
